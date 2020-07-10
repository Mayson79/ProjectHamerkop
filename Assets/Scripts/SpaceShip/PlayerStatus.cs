using UnityEngine;
using PH.MessengerSystem;
using PH.MessengerSystem.MessageTargets;

namespace PH.SpaceShip
{
    public class PlayerStatus : MonoBehaviour
    {
        [SerializeField] [Min(1)] private int maxHealthPoints;

        private int healthPoints;

        private void Start()
        {
            healthPoints = maxHealthPoints;
            Messenger.Execute<IDamagableTarget>(target => target.setMaxHealth(maxHealthPoints));
        }

        public void Hit(int damage)
        {
            healthPoints -= damage;
            Messenger.Execute<IDamagableTarget>(target => target.currentHealth(healthPoints));
            if (healthPoints < 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
