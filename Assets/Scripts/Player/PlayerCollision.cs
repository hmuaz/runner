using UnityEngine;
using Zenject;
using RunnerGame.Signals;

namespace RunnerGame.Player
{
    public class PlayerCollision : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Obstacle"))
            {
                _signalBus.Fire(new PlayerHitSignal());
            }
        }
    }
}

