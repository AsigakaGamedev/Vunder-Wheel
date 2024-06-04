using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarouselManager : MonoBehaviour
{
    [SerializeField] private Transform carouselBody;
    [SerializeField] private float carouselSpeed = 10;

    [Space]
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Ball[] carouselBalls;

    private Transform parent;

    private void Start()
    {
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
