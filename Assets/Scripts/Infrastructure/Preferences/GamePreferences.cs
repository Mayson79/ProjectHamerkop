using UnityEngine;

namespace PH.Infrastructure.Preferences
{
    [CreateAssetMenu(fileName = "NewGamePreferences", menuName = "Game Preferences")]
    public class GamePreferences : ScriptableObject
    {
        [Header("Player")]
        [SerializeField] [Min(1f)] private float maxHealthPoints;

        [Header("Shooting")]
        [SerializeField] [Min(1f)] private float bulletForce;
        [SerializeField] private float shootingRate;
        [SerializeField] private int bulletDamage;
        [SerializeField] private float bulletLifeTime;
        [SerializeField] private string bulletPoolTag;

        [Header("Movement")]
        [SerializeField] private float horizontalConstrains;
        [SerializeField] private float verticalConstrains;

        [Header("Status")]
        [SerializeField] private float obstaclesCheckDistance;

        public float MaxHealthPoints
        {
            get => maxHealthPoints;
            set => maxHealthPoints = value;
        }

        public float BulletForce
        {
            get => bulletForce;
            set => bulletForce = value;
        }

        public float ShootingRate
        {
            get => shootingRate;
            set => shootingRate = value;
        }

        public int BulletDamage
        {
            get => bulletDamage;
            set => bulletDamage = value;
        }

        public string BulletPoolTag
        {
            get => bulletPoolTag;
            set => bulletPoolTag = value;
        }

        public float ObstaclesCheckDistance
        {
            get => obstaclesCheckDistance;
            set => obstaclesCheckDistance = value;
        }

        public float BulletLifeTime
        {
            get => bulletLifeTime;
            set => bulletLifeTime = value;
        }

        public float HorizontalConstrains
        {
            get => horizontalConstrains;
            set => horizontalConstrains = value;
        }

        public float VerticalConstrains
        {
            get => verticalConstrains;
            set => verticalConstrains = value;
        }
    }
}