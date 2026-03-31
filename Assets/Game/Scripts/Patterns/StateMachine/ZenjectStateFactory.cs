using Zenject;

namespace Patterns.StateMachine
{
    public class ZenjectStateFactory<TState> : IStateFactory<TState> where TState : IState
    {
        private readonly DiContainer _container;

        public ZenjectStateFactory(DiContainer container)
        {
            _container = container;
        }

        public TConcrete Create<TConcrete>() where TConcrete : TState
        {
            return _container.Resolve<TConcrete>();
        }
    }
}