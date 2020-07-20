using UnityEngine;
using PH.MessengerSystem;
using PH.MessengerSystem.MessageTargets;
using PH.Infrastructure.Preferences;
using PH.Infrastructure.Managers;
using PH.Gameplay.Interfaces;

namespace PH.SpaceShip
{
    public class PlayerStatus : MonoBehaviour, IDamagable
    {
        private float currentHealthPoints;

        private GamePreferences gamePreferences;

        private void Start()
        {
            gamePreferences = FindObjectOfType<GameManager>().GamePreferences;
            currentHealthPoints = gamePreferences.MaxHealthPoints;
        }

        public void Damage(object invoker, float amount)
        {
            if (!CanDamage(invoker, amount)) return;

            currentHealthPoints -= amount;
            Messenger.Execute<IDamagableTarget>(target => target.SetHealth(currentHealthPoints / gamePreferences.MaxHealthPoints));

            if (currentHealthPoints < 1)
            {
                Destroy(gameObject);
            }
        }

        public bool CanDamage(object invoker, float amount)
        {
            var invokerType = invoker.GetType();
            return invokerType != GetType() && invokerType != typeof(SpaceShipBullet);
        }
    }
}
