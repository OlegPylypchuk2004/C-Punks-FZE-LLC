using UnityEngine;
using Zenject;

namespace Gameplay.ScoreSystem
{
    public class ScoreCounterInstaller : MonoInstaller
    {
        [SerializeField, Min(0f)] private float scoreInterval;
        [SerializeField, Min(0)] private int scorePerInterval;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ScoreCounter>()
                .AsSingle()
                .WithArguments(scoreInterval, scorePerInterval);
        }
    }
}