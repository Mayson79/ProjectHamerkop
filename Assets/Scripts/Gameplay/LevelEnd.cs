using PH.Infrastructure.Managers;
using PH.Infrastructure.Pooling;
using PH.Infrastructure.Preferences;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PH.Gameplay
{
    public class LevelEnd : MonoBehaviour
    {
        [SerializeField] private string nameOfNextLevel; // TODO remove, use LevelsManager

        private GamePreferences gamePreferences;

        private void Start()
        {
            gamePreferences = FindObjectOfType<GameManager>().GamePreferences;
        }

        private void OnTriggerEnter(Collider other)
        {
            var objectPoolManager = ObjectPoolManager.Instance;
            objectPoolManager.ClearPool(gamePreferences.BulletPoolTag);

            SceneManager.LoadScene(nameOfNextLevel);
        }
    }
}
