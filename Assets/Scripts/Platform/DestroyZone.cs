using UnityEngine;

namespace RunnerGame.Platform
{
    public class DestroyZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Obstacle"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}

