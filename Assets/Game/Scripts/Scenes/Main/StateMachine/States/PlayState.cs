using Gameplay.SpaceshipSystem;
using InputSystem;
using Scenes.Main.UI;
using Scenes.Main.UI.Screens;

namespace Scenes.Main.StateMachine.States
{
    public class PlayState : MainSceneState
    {
        private readonly UIScreenNavigator _uiScreenNavigator;
        private readonly Spaceship _spaceship;
        private readonly IInputHandler _inputHandler;

        private PlayScreen _playScreen;

        public PlayState(MainSceneStateMachine stateMachine, UIScreenNavigator uiScreenNavigator, Spaceship spaceship,
            IInputHandler inputHandler)
            : base(stateMachine)
        {
            _uiScreenNavigator = uiScreenNavigator;
            _spaceship = spaceship;
            _inputHandler = inputHandler;
        }

        public override void Enter()
        {
            base.Enter();

            _playScreen = _uiScreenNavigator.Show<PlayScreen>();
            _inputHandler.IsActive = true;
        }

        public override void Exit()
        {
            base.Exit();

            _inputHandler.IsActive = false;
        }
    }
}