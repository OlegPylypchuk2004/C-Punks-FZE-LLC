using Gameplay.SpaceshipSystem;
using Scenes.Main.UI;
using Scenes.Main.UI.Screens;

namespace Scenes.Main.StateMachine.States
{
    public class PlayState : MainSceneState
    {
        private readonly UIScreenNavigator _uiScreenNavigator;
        private readonly Spaceship _spaceship;

        private PlayScreen _playScreen;

        public PlayState(MainSceneStateMachine stateMachine, UIScreenNavigator uiScreenNavigator, Spaceship spaceship)
            : base(stateMachine)
        {
            _uiScreenNavigator = uiScreenNavigator;
            _spaceship = spaceship;
        }

        public override void Enter()
        {
            base.Enter();

            _playScreen = _uiScreenNavigator.Show<PlayScreen>();
        }
    }
}