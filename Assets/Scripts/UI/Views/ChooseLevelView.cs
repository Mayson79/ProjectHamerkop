using PH.Infrastructure.Managers;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace PH.UI.Views
{
    public class ChooseLevelView : MonoBehaviour
    {
        [Header("Levels")]
        [SerializeField] private GameObject buttonPrefab;
        [SerializeField] private RectTransform levelsGridTransform;

        [Header("Other")]
        [SerializeField] private Button backButton;

        private LevelsManager levelsManager;

        private void Start()
        {
            levelsManager = FindObjectOfType<LevelsManager>();

            backButton.onClick.AddListener(OnBackClick);

            GenerateLevelsButtons();
        }

        private void GenerateLevelsButtons()
        {
            var levels = levelsManager.Levels;
            for (int i = 0; i < levels.Count; i++)
            {
                var levelChoiceButton = Instantiate(buttonPrefab, levelsGridTransform);

                levelChoiceButton.GetComponentInChildren<TextMeshProUGUI>(true).text = (i + 1).ToString();
                var index = i;
                levelChoiceButton.GetComponent<Button>().onClick.AddListener(() => {
                    levelsManager.LoadLevel(levels[index].name);
                    levelsManager.StartLevelIndex(index);
                });
            }
        }

        private void OnBackClick()
        {
            // TODO
        }
    }
}