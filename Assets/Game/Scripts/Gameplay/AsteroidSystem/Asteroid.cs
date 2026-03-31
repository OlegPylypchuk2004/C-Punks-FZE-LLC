using UnityEngine;

namespace Gameplay.AsteroidSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviour
    {
        [SerializeField, Min(0)] private float speed;

        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rigidbody2D.linearVelocity = Vector2.down * speed;
        }
    }
}