using Patterns.StateMachine;
using UnityEngine;

namespace Scenes.Main.StateMachine
{
    public abstract class MainSceneState : IState
    {
        protected readonly MainSceneStateMachine _stateMachine;

        protected MainSceneState(MainSceneStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public virtual void Enter()
        {
            Debug.Log($"Location scene state changed: {GetType().Name}");
        }

        public virtual void Exit()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void FixedUpdate()
        {
        }

        public virtual void LateUpdate()
        {
        }
    }
}