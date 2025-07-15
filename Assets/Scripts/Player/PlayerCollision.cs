using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private SignalCenter _signals;

    public void Inject(SignalCenter signals)
    {
        _signals = signals;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            _signals.Fire(new PlayerHitEvent());
        }
    }
}