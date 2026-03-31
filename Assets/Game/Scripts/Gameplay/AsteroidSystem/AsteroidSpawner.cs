using UnityEngine;
using Zenject;

namespace Gameplay.AsteroidSystem
{
    public class AsteroidSpawner : ITickable
    {
        private readonly IInstantiator _instantiator;
        private readonly Asteroid _asteroidPrefab;
        private readonly Vector2[] _spawnPoints;
        private readonly float _spawnDelay;
        private float _timer;

        public bool IsActive { get; set; }

        public AsteroidSpawner(IInstantiator instantiator, Asteroid asteroidPrefab, Vector2[] spawnPoints,
            float spawnDelay)
        {
            _instantiator = instantiator;
            _asteroidPrefab = asteroidPrefab;
            _spawnPoints = spawnPoints;
            _spawnDelay = spawnDelay;
        }

        public void Tick()
        {
            if (!IsActive || _spawnPoints == null || _spawnPoints.Length == 0)
            {
                return;
            }

            _timer += Time.deltaTime;

            if (_timer >= _spawnDelay)
            {
                Spawn();
                _timer = 0;
            }
        }

        private void Spawn()
        {
            int randomIndex = Random.Range(0, _spawnPoints.Length);
            Vector2 spawnPosition = _spawnPoints[randomIndex];

            _instantiator.InstantiatePrefab(_asteroidPrefab, spawnPosition, Quaternion.identity, null);
        }
    }
}