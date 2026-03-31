using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GoogleMobileAds.Api;
using UnityEngine;

namespace Services.AdMob
{
    public class AdMobService : IService
    {
        private readonly string _interstitialUnitId;
        private InterstitialAd _interstitialAd;

        public AdMobService(string interstitialUnitId)
        {
            _interstitialUnitId = interstitialUnitId;
        }

        public async UniTask InitializeAsync(CancellationToken cancellationToken)
        {
            try
            {
                MobileAds.RaiseAdEventsOnUnityMainThread = true;
                var initializationTcs = new UniTaskCompletionSource();

                MobileAds.Initialize(initStatus =>
                {
                    Debug.Log("AdMob: SDK Initialized");
                    initializationTcs.TrySetResult();
                });

                await initializationTcs.Task.AttachExternalCancellation(cancellationToken);
                await LoadInterstitialAsync(cancellationToken);
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception exception)
            {
                Debug.LogError($"AdMob: Initialization Failed - {exception.Message}");
                Debug.LogException(exception);
            }
        }

        public async UniTask LoadInterstitialAsync(CancellationToken cancellationToken)
        {
            if (_interstitialAd != null)
            {
                _interstitialAd.Destroy();
                _interstitialAd = null;
            }

            var adRequest = new AdRequest();
            var loadTcs = new UniTaskCompletionSource<InterstitialAd>();

            InterstitialAd.Load(_interstitialUnitId, adRequest, (ad, error) =>
            {
                if (error != null || ad == null)
                {
                    string errorMsg = error != null ? error.GetMessage() : "Ad is null";
                    Debug.LogError($"AdMob: Load Failed - {errorMsg}");
                    loadTcs.TrySetException(new Exception(errorMsg));
                    return;
                }

                Debug.Log("AdMob: Interstitial Loaded Successfully");
                loadTcs.TrySetResult(ad);
            });

            try
            {
                _interstitialAd = await loadTcs.Task.AttachExternalCancellation(cancellationToken);
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                Debug.LogWarning($"AdMob: Async Load Warning - {ex.Message}");
            }
        }

        public void ShowInterstitial()
        {
            if (_interstitialAd != null && _interstitialAd.CanShowAd())
            {
                Debug.Log("AdMob: Showing Interstitial");
                _interstitialAd.Show();
                LoadInterstitialAsync(CancellationToken.None).Forget();
            }
            else
            {
                Debug.LogWarning("AdMob: Show Failed - Ad not ready. Starting reload...");
                LoadInterstitialAsync(CancellationToken.None).Forget();
            }
        }
    }
}