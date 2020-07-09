using UnityEngine;

namespace PH.Infrastructure.Managers
{
    public abstract class AbstractManager<TManager> : MonoBehaviour where TManager : AbstractManager<TManager>
    {
        public static TManager Instance { get; private set; }

        protected virtual void Start()
        {
            if (Instance != null)
            {
                Debug.LogError($"Instance of {GetType().Name} is already exists");
                Destroy(this);
                return;
            }

            Instance = this as TManager;
            DontDestroyOnLoad(this);
        }
    }
}