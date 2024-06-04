using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GunManager gunManager;
    [SerializeField] private GameManager gameManager;

    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromInstance(gameManager);
        Container.Bind<GunManager>().FromInstance(gunManager);
        Container.Bind<UIManager>().FromInstance(uiManager);
        uiManager.Init();
    }
}
