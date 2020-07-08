using UnityEngine;
using PH.MessengerSystem.MessageTargets;
using PH.MessengerSystem;

namespace Camera
{
    public class CameraPlayer : MonoBehaviour, ICameraPlayerMessageTarger
    {

        private Vector3 offset;
        private Vector3 SpaceShipPos;
        public void OnCameraPosChange(Vector3 move)
        {
            SpaceShipPos = move;
        }

        public void Update()
        {
            transform.position = SpaceShipPos + offset;
        }


        private void Start()
        {
            offset = new Vector3(0f, 5f, -8f);
            Messenger.Register<ICameraPlayerMessageTarger>(this);
        }
        private void OnDestroy()
        {
            Messenger.UnRegister<ICameraPlayerMessageTarger>(this);
        }
    }
}
