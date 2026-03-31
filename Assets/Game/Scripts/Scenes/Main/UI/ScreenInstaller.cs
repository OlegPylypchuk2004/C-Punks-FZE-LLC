using Scenes.Main.UI.Screens;
using UnityEngine;
using Zenject;

namespace Scenes.Main.UI
{
    public class ScreenInstaller : MonoInstaller
    {
        [SerializeField] private MenuScreen menuScreenPrefab;

        public override void InstallBindings()
        {
            Container.Bind<UIScreenNavigator>()
                .AsSingle();
            
            Container.Bind<MenuScreen>()
                .FromComponentInNewPrefab(menuScreenPrefab)
                .AsSingle();
        }
    }
}