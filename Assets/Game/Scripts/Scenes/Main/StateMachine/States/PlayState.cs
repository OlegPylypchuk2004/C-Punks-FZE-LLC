using Gameplay.AsteroidSystem;
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
        private readonly AsteroidSpawner _asteroidSpawner;
        private readonly IInputHandler _inputHandler;

        private PlayScreen _playScreen;

        public PlayState(MainSceneStateMachine stateMachine, UIScreenNavigator uiScreenNavigator, Spaceship spaceship,
            AsteroidSpawner asteroidSpawner, IInputHandler inputHandler)
            : base(stateMachine)
        {
            _uiScreenNavigator = uiScreenNavigator;
            _spaceship = spaceship;
            _asteroidSpawner = asteroidSpawner;
            _inputHandler = inputHandler;
        }

        public override void Enter()
        {
            base.Enter();

            _playScreen = _uiScreenNavigator.Show<PlayScreen>();
            _asteroidSpawner.IsActive = true;
            _inputHandler.IsActive = true;
        }

        public override void Exit()
        {
            base.Exit();

            _asteroidSpawner.IsActive = false;
            _inputHandler.IsActive = false;
        }
    }
}