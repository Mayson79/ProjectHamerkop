using PH.MessengerSystem;
using PH.MessengerSystem.MessageTargets;
using UnityEngine;
using UnityEngine.UI;

namespace PH.UI.Views
{
    [RequireComponent(typeof(Image))]
    public class HealthBarView : MonoBehaviour, IDamagableTarget
    {
        [SerializeField] private Image image;

        private void Start()
        {
            Messenger.Register<IDamagableTarget>(this);
        }

        public void SetHealth(float health)
        {
            image.fillAmount = health;
        }
    }
}
