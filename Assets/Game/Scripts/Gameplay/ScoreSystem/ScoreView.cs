using TMPro;
using UnityEngine;
using Zenject;

namespace Gameplay.ScoreSystem
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text textMesh;

        private ScoreCounter _scoreCounter;

        [Inject]
        private void Construct(ScoreCounter scoreCounter)
        {
            _scoreCounter = scoreCounter;
        }

        private void OnEnable()
        {
            UpdateView(_scoreCounter.CurrentScore);
            _scoreCounter.ScoreChanged += OnScoreChanged;
        }

        private void OnDisable()
        {
            _scoreCounter.ScoreChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int amount)
        {
            UpdateView(amount);
        }

        private void UpdateView(int scoreAmount)
        {
            textMesh.text = $"Scere: {scoreAmount}";
        }
    }
}