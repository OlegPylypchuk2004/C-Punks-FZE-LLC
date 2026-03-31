using Scenes.Main.UI;
using Scenes.Main.UI.Screens;

namespace Scenes.Main.StateMachine.States
{
    public class PlayState : MainSceneState
    {
        private readonly UIScreenNavigator _uiScreenNavigator;
        private PlayScreen _playScreen;

        public PlayState(MainSceneStateMachine stateMachine, UIScreenNavigator uiScreenNavigator)
            : base(stateMachine)
        {
            _uiScreenNavigator = uiScreenNavigator;
        }

        public override void Enter()
        {
            base.Enter();

            _playScreen = _uiScreenNavigator.Show<PlayScreen>();
        }
    }
}