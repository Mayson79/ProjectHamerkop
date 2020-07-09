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
        [SerializeField] [Min(0f)] private float baseSpeed;
        [SerializeField] [Min(1f)] private float rotationSpeed;

        [Header("Acceleration")]
        [SerializeField] [Min(1f)] private float maxAcceleration;
        [SerializeField] [Min(0f)] private float accelerationStep;

        private Rigidbody rb;

        private float speed;
        private float acceleration;
        private float stopForce;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            speed = baseSpeed;
        }

        private void FixedUpdate()
        {
            Move();
            Rotate();
            Acceleration();
        }

        public void Hit(float stoppingForce)
        {
            stopForce = stoppingForce;
        }

        private void Move()
        {
            var xMovement = Input.GetAxisRaw("Horizontal");
            var yMovement = Input.GetAxisRaw("Vertical");
            
            var movement = Vector3.ClampMagnitude(new Vector3(xMovement, yMovement, 1f), 1f) * speed * Time.fixedDeltaTime;

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
            var accelerationMode = Input.GetAxisRaw("Acceleration") * 2 - 1;

            acceleration = Mathf.Clamp(acceleration + accelerationStep * accelerationMode, 0f, maxAcceleration);

            if (stopForce > 0)
            {
                stopForce = Mathf.Clamp(stopForce - 1, 0f, baseSpeed);
            }

            speed = baseSpeed + acceleration - stopForce;
        }
    }
}