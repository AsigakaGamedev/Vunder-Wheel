using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Ball : MonoBehaviour
{
    [SerializeField] private string color;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D col;
    [SerializeField] private PlatformPart partPrefab;

    public System.Action<Transform> onShooted;

    private void OnEnable()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlatformPart platformPart))
        {
            if (platformPart.Color == color)
            {
                MoneyManager.instance.GameInMoney += 100;
                Destroy(platformPart.gameObject);
            }
            else
            {
                platformPart.Container.AddLastPart(partPrefab, platformPart.transform);
            }

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onShooted?.Invoke(transform.parent);
        rb.bodyType = RigidbodyType2D.Dynamic;
        col.isTrigger = true;
        transform.SetParent(null);
        Destroy(gameObject, 10);
    }
}
