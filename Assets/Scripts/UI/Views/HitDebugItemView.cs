using TMPro;
using UnityEngine;

namespace PH.UI.Views
{
    public class HitDebugItemView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI stopingForceText;

        public void Initialize(string name, string stopingForce)
        {
            nameText.text = name;
            stopingForceText.text = stopingForce;
        }
    }
}