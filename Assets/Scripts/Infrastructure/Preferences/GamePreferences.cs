using UnityEngine;

namespace PH.Infrastructure.Preferences
{
    [CreateAssetMenu(fileName = "NewGamePreferences", menuName = "Game Preferences")]
    public class GamePreferences : ScriptableObject
    {
        [Header("Player")]
        [SerializeField] [Min(1f)] private float maxHealthPoints;

        public float MaxHealthPoints
        {
            get => maxHealthPoints;
            set => maxHealthPoints = value;
        }
    }
}