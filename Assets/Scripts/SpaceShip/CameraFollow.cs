using UnityEngine;

namespace PH.SpaceShip
{
    [RequireComponent(typeof(Camera))]
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float yDistance;
        [SerializeField] private float zDistance;

        private void Update()
        {
            transform.position = target.position + new Vector3(0f, yDistance, zDistance);
        }
    }
}
