using UnityEngine;

public class PlayerShake : MonoBehaviour
{
    private SignalCenter _signals;

    public void Inject(SignalCenter signals)
    {
        _signals = signals;
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
        LeanTween.moveX(gameObject, transform.position.x + 0.2f, 0.1f).setLoopPingPong(1);
    }
}