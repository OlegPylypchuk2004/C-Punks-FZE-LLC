using Scenes.Main.UI;
using Scenes.Main.UI.Screens;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.Main.StateMachine.States
{
    public class DefeatState : MainSceneState
    {
        private readonly UIScreenNavigator _uiScreenNavigator;
        private DefeatScreen _defeatScreen;

        public DefeatState(MainSceneStateMachine stateMachine, UIScreenNavigator uiScreenNavigator)
            : base(stateMachine)
        {
            _uiScreenNavigator = uiScreenNavigator;
        }

        public override void Enter()
        {
            base.Enter();

            Time.timeScale = 0f;
            _defeatScreen = _uiScreenNavigator.Show<DefeatScreen>();

            if (_defeatScreen != null)
            {
                _defeatScreen.ContinueButtonClicked += OnContinueButtonClicked;
            }
        }

        public override void Exit()
        {
            base.Exit();
            
            if (_defeatScreen != null)
            {
                _defeatScreen.ContinueButtonClicked -= OnContinueButtonClicked;
            }
        }

        private void OnContinueButtonClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}