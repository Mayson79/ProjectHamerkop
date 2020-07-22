using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PH.Infrastructure.Managers
{
    public class LevelsManager : AbstractManager<LevelsManager>
    {
        [Header("Levels")]
        [SerializeField] private SceneAsset[] levels;
        [SerializeField] private SceneAsset chooseLevelScene;

        [Header("Debug")]
        [SerializeField] private bool isDebugMode;
        [SerializeField] private string debugLevelName;

        protected override void Start()
        {
            base.Start();
        }

        public void LoadLevel(string levelName = null)
        {
#if UNITY_EDITOR
            if (isDebugMode || levelName == null)
            {
                SceneManager.LoadScene(debugLevelName);

                return;
            }
#endif

            var levelAssetToLoad = levels.First(levelAsset => levelAsset.name == levelName);
            SceneManager.LoadScene(levelAssetToLoad.name);
        }

        public void LoadChooseLevelScene()
        {
            SceneManager.LoadScene(chooseLevelScene.name);
        }

        public IReadOnlyList<SceneAsset> Levels => levels;
    }
}