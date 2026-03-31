using UnityEngine;
using Zenject;

namespace InputSystem
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField, Min(0f)] private float swipeThreshold;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SwipeInputHandler>()
                .AsSingle()
                .WithArguments(swipeThreshold);
        }
    }
}