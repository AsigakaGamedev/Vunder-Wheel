using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPart : MonoBehaviour
{
    [SerializeField] private string color;

    public PlatformsContainer Container;

    public string Color { get => color; }

    private void OnEnable()
    {
        //spriteRenderer.color = allColors[Random.Range(0, allColors.Length)];
    }
}
