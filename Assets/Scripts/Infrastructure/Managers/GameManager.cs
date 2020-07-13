using PH.Infrastructure.Preferences;
using System;
using UnityEngine;

namespace PH.Infrastructure.Managers
{
    public class GameManager : AbstractManager<GameManager>
    {
        [SerializeField] private GamePreferences gamePreferences;
        [SerializeField] private GameObject[] managers;

        private bool isGameLoaded;

        public GamePreferences GamePreferences => gamePreferences;

        protected override void Start()
        {
            base.Start();

            LoadManagers();

            StartGame();
        }

        private void StartGame()
        {
            if (isGameLoaded) return;

            var gameLoader = FindObjectOfType<GameLoader>();

            if (gameLoader == null)
            {
                throw new NullReferenceException($"{nameof(gameLoader)}");
            }

            gameLoader.LoadFirstScene();
            isGameLoaded = true;
        }

        private void LoadManagers()
        {
            if (managers == null)
            {
                throw new NullReferenceException($"{nameof(managers)}");
            }

            foreach (var manager in managers)
            {
                if (manager == null) continue;

                Instantiate(manager);
            }
        }
    }
}