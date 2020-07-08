using System.Runtime.Serialization;
using UnityEngine;
using PH.MessengerSystem.MessageTargets;
using PH.MessengerSystem;

namespace PH.SpaceShip
{
    [RequireComponent(typeof(Rigidbody))]
    public class SpaceShipMovement : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] [Min(0)] private float baseSpeed;
        [SerializeField] [Min(0)] private float acceleration;
        [SerializeField] [Min(0)] private float maxSpeedWithAcceleration;

        private Rigidbody rb;
        private float speed;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            speed = baseSpeed;
        }

        private void FixedUpdate()
        {
            Move();
            Acceleration();
            Deceleration();
        }

        private void Move()
        {
            var xMovement = Input.GetAxisRaw("Horizontal");
            var yMovement = Input.GetAxisRaw("Vertical");
            
            var movement = Vector3.ClampMagnitude(new Vector3(xMovement, yMovement, 1f), 1f) * speed * Time.fixedDeltaTime;

            rb.MovePosition(rb.position + movement);

            Messenger.Execute<ICameraPlayerMessageTarger>(target => target.OnCameraPosChange(rb.position));
        }
        private void Acceleration()
        {
            //if(nitro>=1)  - next update feature?

            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (speed < maxSpeedWithAcceleration)
                {
                    speed += acceleration * Time.fixedDeltaTime;
                    if (speed >= maxSpeedWithAcceleration)                    
                        speed = maxSpeedWithAcceleration;                   
                }
            }
        }

        private void Deceleration()
        {
            if (speed > baseSpeed)
            {
                speed -= 0.5f * acceleration * Time.fixedDeltaTime;
                if (speed < baseSpeed) 
                    speed = baseSpeed;
            }
        }

    }
}