using UnityEngine;

namespace UI.ScreenSystem
{
    public class UIScreen : MonoBehaviour
    {
        protected virtual void Awake()
        {
            gameObject.SetActive(false);
        }

        protected virtual void OnEnable()
        {
        }

        protected virtual void OnDisable()
        {
        }

        public virtual void Appear()
        {
            gameObject.SetActive(true);
        }

        public virtual void Disappear()
        {
            gameObject.SetActive(false);
        }
    }
}