using System;
using UI.ScreenSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Main.UI.Screens
{
    public class DefeatScreen : UIScreen
    {
        [SerializeField] private Button continueButton;

        public event Action ContinueButtonClicked;

        protected override void OnEnable()
        {
            base.OnEnable();

            continueButton.onClick.AddListener(OnContinueButtonClicked);
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            continueButton.onClick.RemoveListener(OnContinueButtonClicked);
        }

        private void OnContinueButtonClicked()
        {
            ContinueButtonClicked?.Invoke();
        }
    }
}