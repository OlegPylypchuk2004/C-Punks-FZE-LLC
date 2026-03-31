using Scenes.Main.StateMachine;
using Scenes.Main.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Scenes.Main
{
    public class MainSceneEntryPoint : SceneEntryPoint
    {
        private const double DefaultFrameRate = 60;

        private MainSceneStateMachine _sceneStateMachine;

        [Inject]
        private void Construct(MainSceneStateMachine sceneStateMachine)
        {
            _sceneStateMachine = sceneStateMachine;
        }

        protected override void Start()
        {
            QualitySettings.vSyncCount = 0;

            double targetFrameRate = DefaultFrameRate;

            foreach (Resolution screenResolution in Screen.resolutions)
            {
                if (screenResolution.refreshRateRatio.value > DefaultFrameRate)
                {
                    targetFrameRate = screenResolution.refreshRateRatio.value;
                }
            }

            Application.targetFrameRate = (int)targetFrameRate;

            _sceneStateMachine.ChangeState<IntroState>();
        }
    }
}