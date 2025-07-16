using System;
using UnityEngine;
using Zenject;
using RunnerGame.Signals;

namespace RunnerGame.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [Inject] SignalBus _signalBus;
        private int _health = 3;

        private void OnEnable()
        {
            _signalBus.Subscribe<PlayerHitSignal>(ReduceHealth);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<PlayerHitSignal>(ReduceHealth);
        }

        private void ReduceHealth()
        {
            _health--;
            _signalBus.Fire(new HealthChangedSignal{health = _health});

        }
    }
}


