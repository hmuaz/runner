using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private SignalCenter _signals;
    private int health = 3;

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
        health--;
        _signals.Fire(new HealthChangedEvent { health = health });
    }
}

