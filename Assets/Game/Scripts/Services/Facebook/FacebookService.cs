using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Facebook.Unity;
using UnityEngine;

namespace Services.Facebook
{
    public class FacebookService : IService
    {
        public async UniTask InitializeAsync(CancellationToken cancellationToken)
        {
            try
            {
                if (FB.IsInitialized)
                {
                    FB.ActivateApp();
                    return;
                }

                var utcs = new UniTaskCompletionSource();

                FB.Init(() =>
                    {
                        if (FB.IsInitialized)
                        {
                            FB.ActivateApp();
                            utcs.TrySetResult();
                        }
                        else
                        {
                            utcs.TrySetException(new Exception("Facebook SDK initialization failed"));
                        }
                    },
                    isGameShown =>
                    {
                        Time.timeScale = isGameShown ? 1 : 0;
                    });

                await utcs.Task.AttachExternalCancellation(cancellationToken);

                Debug.Log("Facebook SDK initialized successfully");
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
        }
    }
}