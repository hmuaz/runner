using UnityEngine;
using Zenject;
using RunnerGame.Signals;

namespace RunnerGame.Platform
{
    public class PlatformColorChanger : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<PlayerHitSignal>(ChangeColor);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<PlayerHitSignal>(ChangeColor);
        }

        private void ChangeColor()
        {
            _renderer.material.color = Random.ColorHSV();
        }
    }
}

