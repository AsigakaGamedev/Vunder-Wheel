using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableActivator : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
