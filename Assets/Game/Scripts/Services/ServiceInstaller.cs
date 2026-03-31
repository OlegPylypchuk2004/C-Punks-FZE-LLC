using Services.Firebase;
using UnityEngine;
using Zenject;

namespace Services
{
    public class ServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<FirebaseService>()
                .AsSingle();
        }
    }
}