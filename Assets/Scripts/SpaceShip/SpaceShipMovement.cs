using UnityEngine;

namespace PH.SpaceShip
{
    [RequireComponent(typeof(Rigidbody))]
    public class SpaceShipMovement : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] [Min(0)] private float speed;

        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var xMovement = Input.GetAxisRaw("Horizontal");
            var yMovement = Input.GetAxisRaw("Vertical");
            
            var movement = Vector3.ClampMagnitude(new Vector3(xMovement, yMovement, 1f), 1f) * speed * Time.fixedDeltaTime;

            rb.MovePosition(rb.position + movement);
        }
    }
}