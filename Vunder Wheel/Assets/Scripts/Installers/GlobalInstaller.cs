using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    [SerializeField] private GunSkinsManager gunSkinsMnager;
    [SerializeField] private CarouselsSkinsManager carouselsSkins;
    [SerializeField] private MoneyManager moneyManager;

    public override void InstallBindings()
    {
        Container.Bind<CarouselsSkinsManager>().FromInstance(carouselsSkins);
        carouselsSkins.EquipNew(0);
        Container.Bind<MoneyManager>().FromInstance(moneyManager);
        Container.Bind<GunSkinsManager>().FromInstance(gunSkinsMnager);
        gunSkinsMnager.EquipNew(0);
    }
}
