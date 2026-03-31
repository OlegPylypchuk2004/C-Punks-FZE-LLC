using System;
using UI.ScreenSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Main.UI.Screens
{
    public class MenuScreen : UIScreen
    {
        [SerializeField] private Button playButton;

        public event Action PlayButtonClicked;

        protected override void OnEnable()
        {
            base.OnEnable();

            playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            playButton.onClick.RemoveListener(OnPlayButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            PlayButtonClicked?.Invoke();
        }
    }
}