using Gameplay.AsteroidSystem;
using Gameplay.ScoreSystem;
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
        private readonly ScoreCounter _scoreCounter;

        private PlayScreen _playScreen;

        public PlayState(MainSceneStateMachine stateMachine, UIScreenNavigator uiScreenNavigator, Spaceship spaceship,
            AsteroidSpawner asteroidSpawner, IInputHandler inputHandler, ScoreCounter scoreCounter)
            : base(stateMachine)
        {
            _uiScreenNavigator = uiScreenNavigator;
            _spaceship = spaceship;
            _asteroidSpawner = asteroidSpawner;
            _inputHandler = inputHandler;
            _scoreCounter = scoreCounter;
        }

        public override void Enter()
        {
            base.Enter();

            _playScreen = _uiScreenNavigator.Show<PlayScreen>();
            _spaceship.Destroyed += OnSpaceshipDestroyed;
            _asteroidSpawner.IsActive = true;
            _inputHandler.IsActive = true;
            _scoreCounter.IsActive = true;
        }

        public override void Exit()
        {
            base.Exit();

            _spaceship.Destroyed -= OnSpaceshipDestroyed;
            _asteroidSpawner.IsActive = false;
            _inputHandler.IsActive = false;
            _scoreCounter.IsActive = false;
        }

        private void OnSpaceshipDestroyed()
        {
            Firebase.Analytics.FirebaseAnalytics.LogEvent("enemy_destroyed", "score", _scoreCounter.CurrentScore);

            _stateMachine.ChangeState<DefeatState>();
        }
    }
}