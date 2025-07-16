using UnityEngine;

namespace RunnerGame.Platform
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 2f;

        void Update()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
                transform.position.z - _speed * Time.deltaTime);
        }
    }
}