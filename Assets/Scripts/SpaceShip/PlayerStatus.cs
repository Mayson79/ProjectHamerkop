using UnityEngine;
using PH.MessengerSystem;
using PH.MessengerSystem.MessageTargets;
using PH.Infrastructure.Preferences;
using PH.Infrastructure.Managers;

namespace PH.SpaceShip
{
    public class PlayerStatus : MonoBehaviour
    {
        private float currentHealthPoints;

        private GamePreferences gamePreferences;

        private void Start()
        {
            gamePreferences = FindObjectOfType<GameManager>().GamePreferences;
            currentHealthPoints = gamePreferences.MaxHealthPoints;
        }

        public void Hit(int damage)
        {
            currentHealthPoints -= damage;
            Messenger.Execute<IDamagableTarget>(target => target.SetHealth(currentHealthPoints / gamePreferences.MaxHealthPoints));

            if (currentHealthPoints < 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
