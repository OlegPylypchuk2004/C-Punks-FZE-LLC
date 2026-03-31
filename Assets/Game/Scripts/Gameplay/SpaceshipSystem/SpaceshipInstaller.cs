using UnityEngine;
using Zenject;

namespace Gameplay.SpaceshipSystem
{
    public class SpaceshipInstaller : MonoInstaller
    {
        [SerializeField] private Spaceship spaceshipPrefab;

        public override void InstallBindings()
        {
            Container.Bind<Spaceship>()
                .FromComponentInNewPrefab(spaceshipPrefab)
                .AsSingle();
        }
    }
}