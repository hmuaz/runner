using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private SignalCenter _signals;

    public void Inject(SignalCenter signals)
    {
        _signals = signals;
    }

    private void OnEnable()
    {
        if (_signals == null) return;
        _signals.Subscribe<HealthChangedEvent>(UpdateUI);
    }

    private void OnDisable()
    {
        if (_signals == null) return;
        _signals.Unsubscribe<HealthChangedEvent>(UpdateUI);
    }

    private void UpdateUI(HealthChangedEvent evt)
    {
        GetComponent<TextMeshProUGUI>().text = $"Health: {evt.health}";
    }
}