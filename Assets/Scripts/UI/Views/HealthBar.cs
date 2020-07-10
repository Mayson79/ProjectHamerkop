using PH.MessengerSystem;
using PH.MessengerSystem.MessageTargets;
using UnityEngine;
using UnityEngine.UI;

namespace PH.UI.Views
{
    [RequireComponent(typeof(Slider))]
    public class HealthBar : MonoBehaviour, IDamagableTarget
    {
        [SerializeField] private Slider slider;

        private void Start()
        {
            Messenger.Register<IDamagableTarget>(this);
        }

        public void currentHealth(int health)
        {
            slider.value = health;
        }

        public void setMaxHealth(int health)
        {
            slider.maxValue = health;
            slider.value = health;
        }
    }
}
