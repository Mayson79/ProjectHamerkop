using PH.Gameplay.Interfaces;
using PH.MessengerSystem;
using PH.MessengerSystem.MessageTargets;
using PH.SpaceShip;
using UnityEngine;

namespace PH.Obstacles
{
    [RequireComponent(typeof(Collider))]
    public class Obstacle : MonoBehaviour, IDamagable
    {
        [SerializeField] private float stoppingForce;
        [SerializeField] private float damage;
        [SerializeField] private float health;

        private void OnCollisionEnter(Collision collision)
        {
            var spaceShipMovementComponent = collision.gameObject.GetComponent<SpaceShipMovement>();
            var playerStatusComponent = collision.gameObject.GetComponent<IDamagable>();

            if (spaceShipMovementComponent != null)
            {
                spaceShipMovementComponent.Hit(stoppingForce);

                Messenger.Execute<IHitObstacleTarget>(target => target.OnHitObstacle(name, stoppingForce));

                Destroy(gameObject);
            }

            if (playerStatusComponent != null)
            {
                playerStatusComponent.Damage(this, damage);
            }
        }

        public void Damage(object invoker, float amount)
        {
            if (!CanDamage(invoker, amount)) return;

            health -= amount;

            if (health <= 0f)
            {
                Destroy(gameObject);
            }
        }

        public bool CanDamage(object invoker, float amount)
        {
            return invoker.GetType() != GetType();
        }
    }
}
