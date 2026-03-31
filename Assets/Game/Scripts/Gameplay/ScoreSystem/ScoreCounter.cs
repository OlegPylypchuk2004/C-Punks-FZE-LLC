using System;
using UnityEngine;
using Zenject;

namespace Gameplay.ScoreSystem
{
    public class ScoreCounter : ITickable
    {
        private float _timer;
        private float _scoreInterval;
        private int _scorePerInterval;

        public event Action<int> ScoreChanged;

        public int CurrentScore { get; private set; }
        public bool IsActive { get; set; }

        public ScoreCounter(float scoreInterval, int scorePerInterval)
        {
            _scoreInterval = scoreInterval;
            _scorePerInterval = scorePerInterval;
        }

        public void Tick()
        {
            if (!IsActive)
            {
                return;
            }

            _timer += Time.deltaTime;

            if (_timer >= _scoreInterval)
            {
                AddScore(_scorePerInterval);
                _timer = 0;
            }
        }

        private void AddScore(int amount)
        {
            CurrentScore += amount;
            ScoreChanged?.Invoke(CurrentScore);
        }
    }
}