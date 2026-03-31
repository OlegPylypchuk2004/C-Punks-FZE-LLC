using Scenes.Main.StateMachine;
using Scenes.Main.StateMachine.States;
using Zenject;

namespace Scenes.Main
{
    public class MainSceneEntryPoint : SceneEntryPoint
    {
        private MainSceneStateMachine _sceneStateMachine;

        [Inject]
        private void Construct(MainSceneStateMachine sceneStateMachine)
        {
            _sceneStateMachine = sceneStateMachine;
        }

        protected override void Start()
        {
            _sceneStateMachine.ChangeState<IntroState>();
        }
    }
}