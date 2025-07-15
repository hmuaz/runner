using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int health = 3;
    public static event Action<int> OnHealthChanged;

    private void OnEnable()
    {
        GameEvents.OnPlayerHit += ReduceHealth;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerHit -= ReduceHealth;
    }

    private void ReduceHealth()
    {
        health--;
        OnHealthChanged?.Invoke(health);

    }
}
