using PH.MessengerSystem;
using PH.MessengerSystem.MessageTargets;
using UnityEngine;
using UnityEngine.UI;

namespace PH.UI.Views
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Animator))]
    public class HealthBarView : MonoBehaviour, IDamagableTarget
    {
        [SerializeField] private Image healthFillImage;
        [SerializeField] private float healthLeftToStartPulse;

        Animator animator;

        private void Start()
        {
            Messenger.Register<IDamagableTarget>(this);
            animator = GetComponent<Animator>();

            healthFillImage.fillAmount = 1f;
        }

        public void SetHealth(float healthPercentage)
        {
            healthFillImage.fillAmount = healthPercentage;
            animator.SetBool("IsLowHealth", healthPercentage <= healthLeftToStartPulse);
        }
    }
}
