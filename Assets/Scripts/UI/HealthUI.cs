using TMPro;
using UnityEngine;
using Zenject;
using RunnerGame.Signals;

namespace RunnerGame.UI
{
    public class HealthUI : MonoBehaviour
    {
        [Inject] SignalBus _signalBus;
        private void OnEnable()
        {
            _signalBus.Subscribe<HealthChangedSignal>(UpdateUI);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<HealthChangedSignal>(UpdateUI);

        }

        private void UpdateUI(HealthChangedSignal signal)
        {
            GetComponent<TextMeshProUGUI>().text = $"Health: {signal.health}";
        }
    }
}

