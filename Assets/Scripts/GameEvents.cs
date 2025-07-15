using System;
using UnityEngine;

public static class GameEvents
{
    public static event Action OnPlayerHit;

    public static void PlayerHit()
    {
        OnPlayerHit?.Invoke();
    }
}

