using UI.ScreenSystem;
using Zenject;

namespace Scenes.Main.UI
{
    public class UIScreenNavigator
    {
        private readonly DiContainer _diContainer;

        public UIScreen CurrentScreen { get; private set; }

        public UIScreenNavigator(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public T Show<T>() where T : UIScreen
        {
            T targetScreen = _diContainer.Resolve<T>();

            UIScreen previousScreen = CurrentScreen;
            CurrentScreen = targetScreen;

            if (previousScreen != null)
            {
                previousScreen.Disappear();
                targetScreen.Appear();
            }
            else
            {
                targetScreen.Appear();
            }

            return targetScreen;
        }
    }
}