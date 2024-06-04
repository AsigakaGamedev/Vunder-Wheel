using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Money
{
    public class UIGameMoneyText : MonoBehaviour
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
            moneyText.text = moneyManager.GameInMoney.ToString();
            moneyManager.onGameMoney += OnMoneyChange;
        }

        private void OnDestroy()
        {
            moneyManager.onGameMoney -= OnMoneyChange;
        }

        private void OnMoneyChange(int curMoney)
        {
            moneyText.text = curMoney.ToString();
        }
    }
}