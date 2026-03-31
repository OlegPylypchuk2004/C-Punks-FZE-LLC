using Scenes.Main.UI;
using Scenes.Main.UI.Screens;

namespace Scenes.Main.StateMachine.States
{
    public class MenuState : MainSceneState
    {
        private readonly UIScreenNavigator _uiScreenNavigator;
        private MenuScreen _menuScreen;

        public MenuState(MainSceneStateMachine stateMachine, UIScreenNavigator uiScreenNavigator)
            : base(stateMachine)
        {
            _uiScreenNavigator = uiScreenNavigator;
        }

        public override void Enter()
        {
            base.Enter();

            _menuScreen = _uiScreenNavigator.Show<MenuScreen>();

            if (_menuScreen != null)
            {
                _menuScreen.PlayButtonClicked += OnPlayButtonClicked;
            }
        }

        public override void Exit()
        {
            base.Exit();

            if (_menuScreen != null)
            {
                _menuScreen.PlayButtonClicked -= OnPlayButtonClicked;
            }
        }

        private void OnPlayButtonClicked()
        {
            _stateMachine.ChangeState<PlayState>();
        }
    }
}