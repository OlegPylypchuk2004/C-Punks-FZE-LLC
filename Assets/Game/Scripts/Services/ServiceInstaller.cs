using Services.Facebook;
using Services.Firebase;
using Zenject;

namespace Services
{
    public class ServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<FirebaseService>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<FacebookService>()
                .AsSingle();
        }
    }
}