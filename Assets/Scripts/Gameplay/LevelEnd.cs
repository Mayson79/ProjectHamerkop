using PH.Infrastructure.Managers;
using PH.Infrastructure.Pooling;
using PH.Infrastructure.Preferences;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PH.Gameplay
{
    public class LevelEnd : MonoBehaviour
    {
        private GamePreferences gamePreferences;
        private LevelsManager levelsManager;

        private void Start()
        {
            gamePreferences = FindObjectOfType<GameManager>().GamePreferences;
            levelsManager = FindObjectOfType<LevelsManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var objectPoolManager = ObjectPoolManager.Instance;
            objectPoolManager.ClearPool(gamePreferences.BulletPoolTag);

            levelsManager.NextLevelIndex();
        }
    }
}
