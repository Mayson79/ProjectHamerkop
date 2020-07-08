using UnityEngine;

namespace PH.MessengerSystem.MessageTargets
{

    public interface ICameraPlayerMessageTarger : IMessageTarget
    {
        void OnCameraPosChange(Vector3 move);
    }
}