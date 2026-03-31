using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Services;
using UnityEngine;

namespace Scenes.Main.StateMachine.States
{
    public class IntroState : MainSceneState
    {
        private readonly IService[] _services;
        private CancellationTokenSource _cancellationTokenSource;

        public IntroState(MainSceneStateMachine stateMachine, IService[] services)
            : base(stateMachine)
        {
            _services = services;
        }

        public async override void Enter()
        {
            base.Enter();

            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await InitializeServicesAsync(_cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception exception)
            {
                Debug.LogError($"{GetType().Name}. {exception}");
            }

            _stateMachine.ChangeState<MenuState>();
        }

        public override void Exit()
        {
            base.Exit();

            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
        }

        private async UniTask InitializeServicesAsync(CancellationToken cancellationToken)
        {
            List<UniTask> tasks = new List<UniTask>();

            foreach (IService service in _services)
            {
                tasks.Add(service.InitializeAsync(cancellationToken));
            }

            await UniTask.WhenAll(tasks);
        }
    }
}