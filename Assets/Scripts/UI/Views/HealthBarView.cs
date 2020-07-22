using PH.MessengerSystem;
using PH.MessengerSystem.MessageTargets;
using UnityEngine;
using UnityEngine.UI;

namespace PH.UI.Views
{
    [RequireComponent(typeof(Image))]
    public class HealthBarView : MonoBehaviour, IDamagableTarget
    {
        [SerializeField] private float healthLeftToStartPulse;
        [SerializeField] private Animator animator;

        private Image healthFillImage;

        private void Start()
        {
            Messenger.Register<IDamagableTarget>(this);

            healthFillImage = GetComponent<Image>();
            healthFillImage.fillAmount = 1f;
        }

        private void OnDestroy()
        {
            Messenger.UnRegister<IDamagableTarget>(this);
        }

        public void SetHealth(float healthPercentage)
        {
            healthFillImage.fillAmount = healthPercentage;
            animator.SetBool("IsLowHealth", healthPercentage <= healthLeftToStartPulse);
        }
    }
}
