using PH.MessengerSystem;
using PH.MessengerSystem.MessageTargets;
using PH.SpaceShip;
using System.ComponentModel;
using UnityEngine;

namespace PH.Obstacles
{
    [RequireComponent(typeof(Collider))]
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private float stoppingForce;
        [SerializeField] private int damage;

        private void OnCollisionEnter(Collision collision)
        {
            var spaceShipMovementComponent = collision.gameObject.GetComponent<SpaceShipMovement>();
            var playerStatusComponent = collision.gameObject.GetComponent<PlayerStatus>();

            if (spaceShipMovementComponent != null)
            {
                spaceShipMovementComponent.Hit(stoppingForce);
            }

            if (playerStatusComponent != null)
            {
                playerStatusComponent.Hit(damage);
            }

            Messenger.Execute<IHitObstacleTarget>(target => target.OnHitObstacle(name, stoppingForce));

            Destroy(gameObject);
        }
    }
}
