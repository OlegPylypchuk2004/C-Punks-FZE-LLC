using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace InputSystem
{
    public class SwipeInputHandler : IInputHandler, ITickable
    {
        public event Action<InputDirection> Performed;

        public bool IsActive { get; set; }

        private readonly float _threshold;
        private Vector2 _touchStartPosition;
        private bool _isSwiping;

        public SwipeInputHandler(float threshold)
        {
            _threshold = threshold;
        }

        public void Tick()
        {
            if (!IsActive)
            {
                return;
            }

            HandleTouch();
        }

        private void HandleTouch()
        {
            var touchscreen = Touchscreen.current;
            if (touchscreen == null)
            {
                return;
            }

            var touch = touchscreen.primaryTouch;

            if (touch.press.wasPressedThisFrame)
            {
                _touchStartPosition = touch.position.ReadValue();
                _isSwiping = true;
            }

            if (touch.press.wasReleasedThisFrame && _isSwiping)
            {
                DetectSwipe(touch.position.ReadValue() - _touchStartPosition);
                _isSwiping = false;
            }
        }

        private void DetectSwipe(Vector2 delta)
        {
            if (delta.magnitude < _threshold)
            {
                return;
            }

            if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            {
                Performed?.Invoke(delta.x > 0 ? InputDirection.Right : InputDirection.Left);
            }
            else
            {
                Performed?.Invoke(delta.y > 0 ? InputDirection.Up : InputDirection.Down);
            }
        }
    }
}