using System.Runtime.Serialization;
using UnityEngine;
using PH.MessengerSystem.MessageTargets;
using PH.MessengerSystem;
using System;

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

            rb.MovePosition(rb.position + movement);
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