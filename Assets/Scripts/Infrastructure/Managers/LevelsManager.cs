using UnityEngine;
using UnityEngine.SceneManagement;

namespace PH.Infrastructure.Managers
{
    public class LevelsManager : AbstractManager<LevelsManager>
    {
        [Header("Debug")]
        [SerializeField] private bool isDebugMode;
        [SerializeField] private string debugLevelName;

        protected override void Start()
        {
            base.Start();
        }

        // TODO: rename
        public void LoadStartLevel()
        {
            if (isDebugMode)
            {
                SceneManager.LoadScene(debugLevelName);

                return;
            }

            // TODO
        }
    }
}