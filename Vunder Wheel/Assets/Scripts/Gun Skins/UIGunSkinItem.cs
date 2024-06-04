using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGunSkinItem : MonoBehaviour
{
    [SerializeField] private Image visualImg;
    [SerializeField] private Image downImg;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private GameObject costCoin;
    [SerializeField] private GameObject buyIcon;
    [SerializeField] private GameObject equipIcon;
    [SerializeField] private GameObject equiped;
    [SerializeField] private Button equipBtn;
    [SerializeField] private GameObject realmoney;

    private GunSkinInfo skinInfo;
    private int skinInfoIndex;

    public Action<int> onEquip;

    private void Awake()
    {
        equipBtn.onClick.AddListener(() =>
        {
            onEquip?.Invoke(skinInfoIndex);
        });
    }

    public void SetSkin(int index, bool isEquiped, GunSkinInfo skinInfo)
    {
        skinInfoIndex = index;
        this.skinInfo = skinInfo;

        visualImg.sprite = skinInfo.SkinVisual;
        downImg.sprite = skinInfo.SkinDown;
        nameText.text = skinInfo.SkinName;

        if (skinInfo.Buyed)
        {
            costText.text = "";
            costCoin.SetActive(false);
            equipIcon.SetActive(true);
            buyIcon.SetActive(false);
            realmoney.SetActive(false);
        }
        else
        {
            costText.text = skinInfo.Cost.ToString();
            costCoin.SetActive(!skinInfo.RealMoney);
            costText.gameObject.SetActive(!skinInfo.RealMoney);
            equipIcon.SetActive(false);
            buyIcon.SetActive(true);
            realmoney.SetActive(skinInfo.RealMoney);
        }

        equiped.SetActive(isEquiped);
    }
}
