using Patterns.StateMachine;
using Zenject;

namespace Scenes.Main.StateMachine
{
    public class MainSceneStateMachine : StateMachine<MainSceneState>, ITickable, IFixedTickable, ILateTickable
    {
        public MainSceneStateMachine(IStateFactory<MainSceneState> stateFactory)
            : base(stateFactory)
        {
        }

        public void Tick()
        {
            CurrentState?.Update();
        }

        public void FixedTick()
        {
            CurrentState?.FixedUpdate();
        }

        public void LateTick()
        {
            CurrentState?.LateUpdate();
        }
    }
}