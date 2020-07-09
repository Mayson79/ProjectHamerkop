using PH.SpaceShip;
using System.ComponentModel;
using UnityEngine;

namespace PH.Obstacles
{
    [RequireComponent(typeof(Collider))]
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private float stoppingForce;

        private void OnCollisionEnter(Collision collision)
        {
            var spaceShipMovementComponent = collision.gameObject.GetComponent<SpaceShipMovement>();

            if (spaceShipMovementComponent != null)
            {
                spaceShipMovementComponent.Hit(stoppingForce);
            }

            Destroy(gameObject);
        }
    }
}
