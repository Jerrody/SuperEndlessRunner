using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5.0f;

        private const float MoveOffsetSize = 2.75f;

        private Rigidbody _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.velocity = new Vector3(0.0f, 0.0f, moveSpeed);
        }

        public void Move(InputAction.CallbackContext context)
        {
            if (!context.started) return;

            var axisValue = context.ReadValue<float>();
            var playerPosition = transform.position;
            var newPosition = Mathf.Clamp(playerPosition.x + axisValue * MoveOffsetSize, -MoveOffsetSize,
                MoveOffsetSize);

            transform.position = new Vector3(newPosition, playerPosition.y, playerPosition.z);
        }

        public void StopPlayer(bool isStopped)
        {
            _rb.velocity = isStopped ? new Vector3(0.0f, 0.0f, moveSpeed) : Vector3.zero;
        }
    }
}