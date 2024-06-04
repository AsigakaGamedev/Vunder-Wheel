using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private int startMoney = 1000;
    [SerializeField] private int curMoney;

    private int gameInMoney;
    public int Record;

    public Action<int> onMoneyChange;
    public Action<int> onGameMoney;

    public static MoneyManager instance;

    private void OnEnable()
    {
        gameInMoney = 0;
    }

    private void Awake()
    {
        instance = this;
    }

    private void OnDestroy()
    {
        instance = null;
    }

    public int CurMoney { get => curMoney; 
        set
        {
            curMoney = value;
            PlayerPrefs.SetInt("money", curMoney);
            onMoneyChange?.Invoke(curMoney);
            PlayerPrefs.Save();
        }
    }

    public int GameInMoney { get => gameInMoney;
        set 
        {
            gameInMoney = value;
            onGameMoney?.Invoke(gameInMoney);

            if (PlayerPrefs.GetInt("record", 0) < gameInMoney)
            {
                PlayerPrefs.SetInt("record", gameInMoney);
                PlayerPrefs.Save();
            }
        }
    }

    [Inject]
    private void Construct()
    {
        CurMoney = PlayerPrefs.GetInt("money", startMoney);
    }

    private void Start()
    {
        print(curMoney);
    }
}
