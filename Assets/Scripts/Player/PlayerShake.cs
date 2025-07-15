using UnityEngine;

public class PlayerShake : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnPlayerHit += Shake;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerHit -= Shake;
    }

    private void Shake()
    {
        LeanTween.moveX(gameObject, transform.position.x + 0.2f, 0.1f).setLoopPingPong(1);
    }
}
