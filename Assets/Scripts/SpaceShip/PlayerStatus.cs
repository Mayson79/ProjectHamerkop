using UnityEngine;
using PH.MessengerSystem;
using PH.MessengerSystem.MessageTargets;
using PH.Infrastructure.Preferences;
using PH.Infrastructure.Managers;
using PH.Gameplay.Interfaces;
using UnityEngine.SceneManagement;
using PH.Infrastructure.Pooling;

namespace PH.SpaceShip
{
    public class PlayerStatus : MonoBehaviour, IDamagable
    {
        private float currentHealthPoints;

        private GamePreferences gamePreferences;
        ObjectPoolManager objectPoolManager;

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
                OnDeath();
            }
        }

        public bool CanDamage(object invoker, float amount)
        {
            var invokerType = invoker.GetType();
            return invokerType != GetType() && invokerType != typeof(SpaceShipBullet);
        }

        private void OnDeath()
        {
            Destroy(gameObject);

            objectPoolManager = ObjectPoolManager.Instance;
            objectPoolManager.ClearPool(gamePreferences.BulletPoolTag);

            SceneManager.LoadScene("MainMenu");
        }
    }
}
