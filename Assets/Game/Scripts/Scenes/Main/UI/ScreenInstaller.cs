using Scenes.Main.UI.Screens;
using UnityEngine;
using Zenject;

namespace Scenes.Main.UI
{
    public class ScreenInstaller : MonoInstaller
    {
        [SerializeField] private MenuScreen menuScreenPrefab;
        [SerializeField] private PlayScreen playScreenPrefab;
        [SerializeField] private DefeatScreen defeatScreenPrefab;

        public override void InstallBindings()
        {
            Container.Bind<UIScreenNavigator>()
                .AsSingle();

            Container.Bind<MenuScreen>()
                .FromComponentInNewPrefab(menuScreenPrefab)
                .AsSingle();

            Container.Bind<PlayScreen>()
                .FromComponentInNewPrefab(playScreenPrefab)
                .AsSingle();

            Container.Bind<DefeatScreen>()
                .FromComponentInNewPrefab(defeatScreenPrefab)
                .AsSingle();
        }
    }
}