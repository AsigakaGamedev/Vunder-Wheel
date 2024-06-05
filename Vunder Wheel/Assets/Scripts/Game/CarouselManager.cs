using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CarouselManager : MonoBehaviour
{
    [SerializeField] private Transform carouselBody;
    [SerializeField] private float carouselSpeed = 10;

    [Space]
    [SerializeField] private CarouselInfo defaultSkin;
    [SerializeField] private SpriteRenderer borderRender;
    [SerializeField] private SpriteRenderer centerRender;
    [SerializeField] private SpriteRenderer[] iconsRenders;

    [Space]
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Ball[] carouselBalls;

    private CarouselsSkinsManager skinsManager;
    private Transform parent;

    [Inject]
    private void Construct(CarouselsSkinsManager skinsManager)
    {
        this.skinsManager = skinsManager;
    }

    private void Start()
    {
        if (skinsManager.CurrentSkin != defaultSkin)
        {
            borderRender.sprite = skinsManager.CurrentSkin.SkinBorder;
            centerRender.sprite = skinsManager.CurrentSkin.SkinCenter;

            foreach (SpriteRenderer icon in iconsRenders)
            {
                icon.sprite = skinsManager.CurrentSkin.SkinIcon;
            }
        }

        foreach (var p in spawnPoints)
        {
            Ball newBall = Instantiate(carouselBalls[Random.Range(0, carouselBalls.Length)], p);
            newBall.onShooted += OnShooted;
        }
    }

    private void Update()
    {
        carouselBody.eulerAngles += new Vector3(0, 0, Time.deltaTime * carouselSpeed);
    }

    private void OnDestroy()
    {
        foreach (var p in spawnPoints)
        {
            try
            {
                Ball newBall = p.GetChild(0).GetComponent<Ball>();
                newBall.onShooted -= OnShooted;
            }
            catch
            {
                continue;
            }
        }
    }

    private void OnShooted(Transform parent)
    {
        this.parent = parent;
        Invoke(nameof(SpawnDelay), 1);
    }

    private void SpawnDelay()
    {
        Ball newBall = Instantiate(carouselBalls[Random.Range(0, carouselBalls.Length)], parent);
        newBall.onShooted += OnShooted;
    }
}
