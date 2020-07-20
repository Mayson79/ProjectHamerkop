using UnityEngine;

namespace PH.Infrastructure.Pooling
{
    public interface IObjectPoolItem
    {
        void ResetObject(Vector3 position, Quaternion rotation);
    }
}