using UnityEngine;

namespace PH.SpaceShip
{
    [RequireComponent(typeof(Camera))]
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float yDistance;
        [SerializeField] private float zDistance;

        [SerializeField] private Transform target;

        private void Update()
        {
            if (target != null)
            {
                transform.position = target.position + new Vector3(0f, yDistance, zDistance);
            }
        }

        public void StartFollow(Transform target)
        {
            this.target = target;
        }
    }
}
