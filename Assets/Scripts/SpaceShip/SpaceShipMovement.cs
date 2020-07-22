using UnityEngine;
using PH.Infrastructure.Preferences;
using PH.Infrastructure.Managers;

namespace PH.SpaceShip
{
    [RequireComponent(typeof(Rigidbody))]
    public class SpaceShipMovement : MonoBehaviour
    {
        [Header("Speed")]
        [SerializeField] private float maxSpeed;
        [SerializeField] private float minSpeed;
        [SerializeField] [Min(1f)] private float rotationSpeed;

        [Header("Acceleration")]
        [SerializeField] [Min(0f)] private float acceleration;

        private GamePreferences gamePreferences;

        private Rigidbody rb;

        private float currentSpeed;

        public float CurrentSpeed
        {
            get => currentSpeed;
            set => currentSpeed = Mathf.Clamp(value, minSpeed, maxSpeed);
        }

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            gamePreferences = FindObjectOfType<GameManager>().GamePreferences;

        }

        private void FixedUpdate()
        {
            Acceleration();
            Move();
            Rotate();
        }

        public void Hit(float stoppingForce)
        {
            CurrentSpeed -= stoppingForce;
        }

        private void Move()
        {
            var xMovement = Input.GetAxisRaw("Horizontal");
            var yMovement = Input.GetAxisRaw("Vertical");

            var movement = Vector3.ClampMagnitude(new Vector3(xMovement, yMovement, 1f), 1f) * CurrentSpeed * Time.fixedDeltaTime;

            var horizontalConstrains = gamePreferences.HorizontalConstrains;
            var verticalConstrains = gamePreferences.VerticalConstrains;

            var newPosition = rb.position + movement;

            newPosition.x = (Mathf.Abs(newPosition.x) >= horizontalConstrains) ? Mathf.Sign(newPosition.x) * horizontalConstrains : newPosition.x;
            newPosition.y = (Mathf.Abs(newPosition.y) >= verticalConstrains) ? Mathf.Sign(newPosition.y) * verticalConstrains : newPosition.y;

            rb.MovePosition(newPosition);
        }

        private void Rotate()
        {
            var xRotation = rotationSpeed * Input.GetAxis("Roll");
            var rotation = Quaternion.Euler(new Vector3(0f, 0f, xRotation * rotationSpeed * Time.fixedDeltaTime));
            rb.MoveRotation(rb.rotation * rotation);
        }

        private void Acceleration()
        {
            CurrentSpeed += acceleration;
        }
    }
}