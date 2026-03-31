using Scenes.Main.UI;
using Scenes.Main.UI.Screens;

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

            _defeatScreen = _uiScreenNavigator.Show<DefeatScreen>();
        }
    }
}