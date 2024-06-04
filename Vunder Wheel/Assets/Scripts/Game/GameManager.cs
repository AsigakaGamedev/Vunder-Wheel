using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlatformPart[] allParts;
    [SerializeField] private int startLayers = 2;
    [SerializeField] private PlatformsContainer[] platformsContainers;
    [SerializeField] private float movePlatfromsTime = 4;

    public static GameManager instance;

    public PlatformPart[] AllParts { get => allParts; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        foreach (var layer in platformsContainers)
        {
            for (int i = 0; i < startLayers; i++)
            {
                PlatformPart partPrefab = allParts[Random.Range(0, allParts.Length)];
                layer.SpawnNew(partPrefab);
            }
        }

        StartCoroutine(EMovePlatforms());
    }

    private void OnDestroy()
    {
        instance = null;
    }

    private void Update()
    {
        foreach (var layer in platformsContainers)
        {
            layer.MoveAll();
        }
    }

    private IEnumerator EMovePlatforms()
    {
        while (true)
        {
            yield return new WaitForSeconds(movePlatfromsTime);

            foreach (var layer in platformsContainers)
            {
                try
                {
                    PlatformPart partPrefab = allParts[Random.Range(0, allParts.Length)];
                    layer.SpawnNew(partPrefab);
                }
                catch { }
            }
        }
    }
}