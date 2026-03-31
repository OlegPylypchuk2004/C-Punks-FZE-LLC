using System;
using UnityEngine;

namespace Gameplay.SpaceshipSystem
{
    public class Spaceship : MonoBehaviour
    {
        public event Action Destroyed;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<IObstacle>() != null)
            {
                Destroyed?.Invoke();
            }
        }
    }
}