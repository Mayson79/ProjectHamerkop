using PH.MessengerSystem;
using PH.MessengerSystem.MessageTargets;
using UnityEngine;
using UnityEngine.UI;

namespace PH.UI.Views
{
    [RequireComponent(typeof(Image))]
    public class HealthBarView : MonoBehaviour, IDamagableTarget
    {
        [SerializeField] private Image healthFillImage;

        private void Start()
        {
            Messenger.Register<IDamagableTarget>(this);
            healthFillImage.fillAmount = 1f;
        }

        public void SetHealth(float healthPercentage)
        {
            healthFillImage.fillAmount = healthPercentage;
        }
    }
}
