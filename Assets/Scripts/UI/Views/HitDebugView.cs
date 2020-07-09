using PH.MessengerSystem;
using PH.MessengerSystem.MessageTargets;
using UnityEngine;

namespace PH.UI.Views
{
    public class HitDebugView : MonoBehaviour, IHitObstacleTarget
    {
        [SerializeField] private GameObject hitDebugViewItem;
        [SerializeField] private RectTransform listTransofrm;
        [SerializeField] [Min(1f)] private float itemShowTime;

        private void Start()
        {
            Messenger.Register<IHitObstacleTarget>(this);
        }

        public void AddItem(string name, string stoppingForce)
        {
            var item = Instantiate(hitDebugViewItem, listTransofrm);

            item.transform.SetSiblingIndex(0);

            item.GetComponent<HitDebugItemView>().Initialize(name, stoppingForce);

            Destroy(item, itemShowTime);
        }

        public void OnHitObstacle(string name, float stoppingForce)
        {
            AddItem(name, $"{stoppingForce}");
        }
    }
}