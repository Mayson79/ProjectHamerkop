using PH.Infrastructure.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace PH.UI.Views
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;

        LevelsManager levelsManager;

        private void Awake()
        {
            levelsManager = FindObjectOfType<LevelsManager>();

            InitializeButtons();
        }

        private void InitializeButtons()
        {
            startButton.onClick.AddListener(OnStartClick);
            exitButton.onClick.AddListener(OnExitClick);
        }

        private void OnStartClick()
        {
            levelsManager.LoadStartLevel();
        }

        private void OnExitClick()
        {
            Application.Quit();
        }
    }
}