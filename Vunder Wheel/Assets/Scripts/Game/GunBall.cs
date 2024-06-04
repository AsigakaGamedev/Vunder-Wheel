using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBall : MonoBehaviour
{
    [SerializeField] private Collider2D col;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        col.isTrigger = true;
        Destroy(gameObject);
    }
}
