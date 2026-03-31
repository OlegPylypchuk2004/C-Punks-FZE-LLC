using System;
using UnityEngine;
using Zenject;

namespace InputSystem
{
    public class SwipeInputHandler : IDirectionInputHandler, ITickable
    {
        public event Action<InputDirection> DirectionPerformed;

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
            if (Input.touchCount == 0)
            {
                return;
            }

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _touchStartPosition = touch.position;
                _isSwiping = true;
            }

            if ((touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) && _isSwiping)
            {
                DetectSwipe(touch.position - _touchStartPosition);
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
                DirectionPerformed?.Invoke(delta.x > 0 ? InputDirection.Right : InputDirection.Left);
            }
            else
            {
                DirectionPerformed?.Invoke(delta.y > 0 ? InputDirection.Up : InputDirection.Down);
            }
        }
    }
}