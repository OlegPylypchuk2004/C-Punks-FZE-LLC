using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Firebase;
using UnityEngine;

namespace Services.Firebase
{
    public class FirebaseService : IService
    {
        public async UniTask InitializeAsync(CancellationToken cancellationToken)
        {
            try
            {
                var dependencyStatus = await FirebaseApp.CheckAndFixDependenciesAsync()
                    .AsUniTask()
                    .AttachExternalCancellation(cancellationToken);

                if (dependencyStatus == DependencyStatus.Available)
                {
                    Debug.Log("Firebase initialized successfully");
                }
                else
                {
                    Debug.LogError($"Firebase initialization failed: {dependencyStatus}");
                }
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