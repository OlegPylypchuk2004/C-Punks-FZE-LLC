namespace Patterns.StateMachine
{
    public interface IStateFactory<TState> where TState : IState
    {
        public TConcrete Create<TConcrete>() where TConcrete : TState;
    }
}