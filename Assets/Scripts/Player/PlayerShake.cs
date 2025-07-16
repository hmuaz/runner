using UnityEngine;
using Zenject;

public class PlayerShake : MonoBehaviour
{
    [Inject] private SignalBus _signalBus;
    private void OnEnable()
    {
        _signalBus.Subscribe<PlayerHitSignal>(Shake);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<PlayerHitSignal>(Shake);

    }

    private void Shake()
    {
        LeanTween.moveX(gameObject, transform.position.x + 0.2f, 0.1f).setLoopPingPong(1);
    }
}
