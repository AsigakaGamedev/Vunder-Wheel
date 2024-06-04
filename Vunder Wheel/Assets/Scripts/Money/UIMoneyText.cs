using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class UIMoneyText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    private MoneyManager moneyManager;

    [Inject]
    private void Construct(MoneyManager moneyManager)
    {
        this.moneyManager = moneyManager;
    }

    private void Start()
    {
        moneyText.text = moneyManager.CurMoney.ToString();
        moneyManager.onMoneyChange += OnMoneyChange;
    }

    private void OnDestroy()
    {
        moneyManager.onMoneyChange -= OnMoneyChange;
    }

    private void OnMoneyChange(int curMoney)
    {
        moneyText.text = curMoney.ToString();
    }
}
