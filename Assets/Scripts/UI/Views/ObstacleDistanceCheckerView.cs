using PH.MessengerSystem;
using PH.MessengerSystem.MessageTargets;
using TMPro;
using UnityEngine;

namespace PH.UI.Views
{
    public class ObstacleDistanceCheckerView : MonoBehaviour, IRaycastHitTarget
    {
        [SerializeField] private TextMeshProUGUI raycastTMP;

        private void Start()
        {
            Messenger.Register<IRaycastHitTarget>(this);
        }

        public void OnRaycastHitObstacle(string name, float distance)
        {
            raycastTMP.text = $"Did hit {name}! Distance: {distance}";
        }

        public void OnRaycastHitNothing()
        {
            raycastTMP.text = string.Empty;
        }
    }
}