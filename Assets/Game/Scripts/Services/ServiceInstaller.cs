using Services.AdMob;
using Services.Facebook;
using Services.Firebase;
using UnityEngine;
using Zenject;

namespace Services
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private string interstitialUnitId;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<FirebaseService>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<FacebookService>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<AdMobService>()
                .AsSingle()
                .WithArguments(interstitialUnitId);
        }
    }
}