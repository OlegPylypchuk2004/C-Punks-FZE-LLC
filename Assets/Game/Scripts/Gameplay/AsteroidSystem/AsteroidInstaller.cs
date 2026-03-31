using UnityEngine;
using Zenject;

namespace Gameplay.AsteroidSystem
{
    public class AsteroidInstaller : MonoInstaller
    {
        [SerializeField] private Asteroid asteroidPrefab;
        [SerializeField] private Vector2[] spawnPoints;
        [SerializeField, Min(0f)] private float spawnDelay;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AsteroidSpawner>()
                .AsSingle()
                .WithArguments(asteroidPrefab, spawnPoints, spawnDelay);
        }
    }
}