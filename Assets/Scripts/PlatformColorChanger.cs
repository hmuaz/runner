using UnityEngine;

public class PlatformColorChanger : MonoBehaviour
{
    private Renderer rend;
    private SignalCenter _signals;

    public void Inject(SignalCenter signals)
    {
        _signals = signals;
    }

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        if (_signals == null) return;
        _signals.Subscribe<PlayerHitEvent>(OnPlayerHit);
    }

    private void OnDisable()
    {
        if (_signals == null) return;
        _signals.Unsubscribe<PlayerHitEvent>(OnPlayerHit);
    }

    private void OnPlayerHit(PlayerHitEvent _)
    {
        rend.material.color = Random.ColorHSV();
    }
}