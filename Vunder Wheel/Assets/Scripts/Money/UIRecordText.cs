﻿using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Money
{
    public class UIRecordText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        private void OnEnable()
        {
            text.text = PlayerPrefs.GetInt("record", 0).ToString();
        }
    }
}