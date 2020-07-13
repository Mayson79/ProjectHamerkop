using UnityEngine;
using PH.MessengerSystem;
using PH.MessengerSystem.MessageTargets;

namespace PH.SpaceShip
{
    public class PlayerStatus : MonoBehaviour
    {
        [SerializeField] private GamePreferences gamePreferences;

        private void Start()
        {
            gamePreferences.CurrentHealthPoints = gamePreferences.MaxHealthPoints;
            Messenger.Execute<IDamagableTarget>(target => target.SetHealth(gamePreferences.CurrentHealthPoints / gamePreferences.MaxHealthPoints));
        }

        public void Hit(int damage)
        {
            gamePreferences.CurrentHealthPoints -= damage;
            Messenger.Execute<IDamagableTarget>(target => target.SetHealth(gamePreferences.CurrentHealthPoints / gamePreferences.MaxHealthPoints));

            if (gamePreferences.CurrentHealthPoints < 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
