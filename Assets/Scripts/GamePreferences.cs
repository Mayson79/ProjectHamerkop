using UnityEngine;

[CreateAssetMenu(fileName = "New Game Preferences", menuName = "Game Preferences", order = 51)]
public class GamePreferences : ScriptableObject
{
    [SerializeField] [Min(1f)] private float maxHealthPoints;
    [SerializeField] private float currentHealthPoints;

    public float MaxHealthPoints
    {
        get
        {
            return maxHealthPoints;
        }
    }

    public float CurrentHealthPoints
    {
        get
        {
            return currentHealthPoints;
        }
        set
        {
            currentHealthPoints = value;
        }
    }
}
