using UnityEngine;

namespace RunnerGame.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float _sideSpeed = 5f;

        [SerializeField]
        private float _clampX = 3f;

        [SerializeField]
        private float _jumpForce = 5f;

        private Rigidbody _rigidbody;
        private bool _isGrounded;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            Vector3 moveDelta = Vector3.right * (horizontalInput * _sideSpeed * Time.deltaTime);
            _rigidbody.MovePosition(_rigidbody.position + moveDelta);

            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _isGrounded = false;
            }

            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, -_clampX, _clampX);
            transform.position = clampedPosition;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGrounded = true;
            }
        }
    }
}