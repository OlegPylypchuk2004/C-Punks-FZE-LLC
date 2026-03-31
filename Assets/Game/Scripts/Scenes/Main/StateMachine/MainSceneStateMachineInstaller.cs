using Patterns.StateMachine;
using Scenes.Main.StateMachine.States;
using Zenject;

namespace Scenes.Main.StateMachine
{
    public class MainSceneStateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MainSceneStateMachine>()
                .AsSingle();

            Container.Bind<IStateFactory<MainSceneState>>()
                .To<ZenjectStateFactory<MainSceneState>>()
                .AsSingle();

            Container.Bind<IntroState>()
                .AsSingle();
        }
    }
}