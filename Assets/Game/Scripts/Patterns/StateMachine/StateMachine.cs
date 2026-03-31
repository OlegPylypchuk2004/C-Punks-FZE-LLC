using System;

namespace Patterns.StateMachine
{
    public abstract class StateMachine<TState> where TState : IState
    {
        private readonly IStateFactory<TState> _stateFactory;

        protected StateMachine(IStateFactory<TState> stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public event Action<TState, TState> StateChanged;

        public TState CurrentState { get; private set; }

        public void ChangeState<TConcrete>() where TConcrete : TState
        {
            var newState = _stateFactory.Create<TConcrete>();

            if (ReferenceEquals(CurrentState, newState))
            {
                return;
            }

            var previousState = CurrentState;

            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();

            StateChanged?.Invoke(previousState, CurrentState);
        }
    }
}