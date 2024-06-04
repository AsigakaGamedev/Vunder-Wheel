using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIGunSkinsManager : MonoBehaviour
{
    [SerializeField] private UIGunSkinItem itemPrefab;
    [SerializeField] private Transform itemsContent;

    private GunSkinsManager gunSkinsManager;

    private List<UIGunSkinItem> spawnedItems;

    [Inject]
    private void Construct(GunSkinsManager gunSkinsManager)
    {
        this.gunSkinsManager = gunSkinsManager;
        spawnedItems = new List<UIGunSkinItem>();
        UpdatePanel();
    }

    private void OnEnable()
    {
        if (gunSkinsManager != null)
        {
            UpdatePanel();
        }
    }

    private void OnDestroy()
    {
        foreach (var item in spawnedItems)
        {
            item.onEquip -= OnSkinClick;
        }
    }

    private void UpdatePanel()
    {
        foreach (var item in spawnedItems)
        {
            item.onEquip -= OnSkinClick;
            Destroy(item.gameObject);
        }

        spawnedItems.Clear();

        for (int i = 0; i < gunSkinsManager.AllSkins.Length; i++)
        {
            GunSkinInfo skinInfo = gunSkinsManager.AllSkins[i];
            UIGunSkinItem newItem = Instantiate(itemPrefab, itemsContent);
            newItem.SetSkin(i, skinInfo == gunSkinsManager.CurrentSkin, skinInfo);
            newItem.onEquip += OnSkinClick;
            spawnedItems.Add(newItem);
        }
    }

    private void OnSkinClick(int index)
    {
        gunSkinsManager.EquipNew(index, true);
        UpdatePanel();
    }
}
