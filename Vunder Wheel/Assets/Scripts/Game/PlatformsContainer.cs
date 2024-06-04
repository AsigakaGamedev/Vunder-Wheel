using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsContainer : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private float offset;
    [SerializeField] private List<PlatformPart> spawnedParts;

    [SerializeField] private float moveDelay = 4;

    public Transform StartPoint { get => startPoint; }
    public float Offset { get => offset; }
    public List<PlatformPart> SpawnedParts { get => spawnedParts; }

    public void AddLastPart(PlatformPart prefab, Transform collidedPart)
    {
        for (int i = 0; i < spawnedParts.Count; i++)
        {
            if (spawnedParts[i] == null)
            {
                spawnedParts.RemoveAt(i);
            }
        }

        Vector2 lastSpawnPoint;

        lastSpawnPoint = collidedPart.transform.position + new Vector3(0, offset);

        PlatformPart newPart = Instantiate(prefab, lastSpawnPoint, Quaternion.identity, transform);
        //newPart.transform.DOMove(lastSpawnPoint, moveDelay);
        newPart.Container = this;
        spawnedParts.Add(newPart);
    }

    public void SpawnNew(PlatformPart prefab)
    {
        PlatformPart newPart = Instantiate(prefab, transform.position, Quaternion.identity, transform);
        newPart.Container = this;
        spawnedParts.Add(newPart);
    }

    public void MoveAll()
    {
        for (int i = 0; i < spawnedParts.Count; i++)
        {
            if (spawnedParts[i] == null)
            {
                spawnedParts.RemoveAt(i);
                continue;
            }

            spawnedParts[i].transform.position += new Vector3(0, moveDelay * Time.deltaTime);
        }
    }
}
