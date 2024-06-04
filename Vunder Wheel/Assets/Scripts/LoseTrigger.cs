using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LoseTrigger : MonoBehaviour
{
    [SerializeField] private GameObject losePopup;

    private UIManager uiManager;

    [Inject]
    private void Construct(UIManager uiManager)
    {
        this.uiManager = uiManager;
        losePopup.SetActive(false);
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 300);
        if (hit.collider && hit.collider.GetComponent<PlatformPart>())
        {
            if (MoneyManager.instance.GameInMoney >= PlayerPrefs.GetInt("record", 0))
            {
                PlayerPrefs.SetInt("record", MoneyManager.instance.GameInMoney);
                PlayerPrefs.Save();
            }

            losePopup.SetActive(true);
            MoneyManager.instance.CurMoney += MoneyManager.instance.GameInMoney;
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }
}
