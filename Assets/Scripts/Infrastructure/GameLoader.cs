using UnityEngine;
using UnityEngine.SceneManagement;

namespace PH.Infrastructure
{
    public class GameLoader : MonoBehaviour
    {
        [SerializeField] private string firstSceneToLoad;

        public void LoadFirstScene()
        {
            if (!SceneManager.GetSceneByName(firstSceneToLoad).IsValid())
            {
                SceneManager.LoadScene(firstSceneToLoad);
            }
        }
    }
}