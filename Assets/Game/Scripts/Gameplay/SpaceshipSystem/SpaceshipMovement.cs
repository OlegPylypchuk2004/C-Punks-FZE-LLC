using InputSystem;
using UnityEngine;
using Zenject;

namespace Gameplay.SpaceshipSystem
{
    public class SpaceshipMovement : MonoBehaviour
    {
        [SerializeField] private Vector2[] points;
        [SerializeField, Min(0)] private int initialPointIndex;

        private IInputHandler _inputHandler;
        private int _pointIndex;

        [Inject]
        private void Construct(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        private void Awake()
        {
            _pointIndex = Mathf.Clamp(initialPointIndex, 0, points.Length - 1);
            MoveToPoint();
        }

        private void OnEnable()
        {
            _inputHandler.Performed += OnInputPerformed;
        }

        private void OnDisable()
        {
            _inputHandler.Performed -= OnInputPerformed;
        }

        private void OnInputPerformed(InputDirection direction)
        {
            switch (direction)
            {
                case InputDirection.Right:
                    _pointIndex++;
                    break;

                case InputDirection.Left:
                    _pointIndex--;
                    break;
            }

            _pointIndex = Mathf.Clamp(_pointIndex, 0, points.Length - 1);
            MoveToPoint();
        }

        private void MoveToPoint()
        {
            transform.localPosition = points[_pointIndex];
        }
    }
}