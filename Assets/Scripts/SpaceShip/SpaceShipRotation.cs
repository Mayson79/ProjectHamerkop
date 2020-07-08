using UnityEngine;


namespace PH.SpaceShipRotation
{
    public class SpaceShipRotation : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] [Min(1)] private float rotationSpeed;


        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Rotate();
        }

        private void Rotate()
        {
            var xRotation = rotationSpeed * Input.GetAxisRaw("Mouse X");
            var rotation = Quaternion.Euler(new Vector3(0f, 0f, xRotation) * rotationSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * rotation);
        }
    }

}