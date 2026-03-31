using System.Collections.Generic;
using AdjustSdk;
using Facebook.Unity;
using Gameplay.ScoreSystem;
using Scenes.Main.UI;
using Scenes.Main.UI.Screens;
using Services.AdMob;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.Main.StateMachine.States
{
    public class DefeatState : MainSceneState
    {
        private readonly UIScreenNavigator _uiScreenNavigator;
        private readonly ScoreCounter _scoreCounter;
        private readonly AdMobService _adMobService;

        private DefeatScreen _defeatScreen;

        public DefeatState(MainSceneStateMachine stateMachine, UIScreenNavigator uiScreenNavigator,
            ScoreCounter scoreCounter, AdMobService adMobService)
            : base(stateMachine)
        {
            _uiScreenNavigator = uiScreenNavigator;
            _scoreCounter = scoreCounter;
            _adMobService = adMobService;
        }

        public override void Enter()
        {
            base.Enter();

            Time.timeScale = 0f;

            SendEvents();
            _adMobService.ShowInterstitial();
            _defeatScreen = _uiScreenNavigator.Show<DefeatScreen>();

            if (_defeatScreen != null)
            {
                _defeatScreen.ContinueButtonClicked += OnContinueButtonClicked;
            }
        }

        public override void Exit()
        {
            base.Exit();

            Time.timeScale = 1f;
            
            if (_defeatScreen != null)
            {
                _defeatScreen.ContinueButtonClicked -= OnContinueButtonClicked;
            }
        }

        private void OnContinueButtonClicked()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void SendEvents()
        {
            //Firebase
            Firebase.Analytics.FirebaseAnalytics.LogEvent("enemy_destroyed", "score", _scoreCounter.CurrentScore);

            //Adjust
            AdjustEvent adjustEvent = new AdjustEvent("test_event_token");
            adjustEvent.AddCallbackParameter("score", _scoreCounter.CurrentScore.ToString());
            Adjust.TrackEvent(adjustEvent);

            //Meta
            var parameters = new Dictionary<string, object>();
            parameters["score"] = _scoreCounter.CurrentScore;
            FB.LogAppEvent("game_over", parameters: parameters);
        }
    }
}