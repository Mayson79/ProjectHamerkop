using System.Collections.Generic;
using UnityEngine;
using PH.Infrastructure.Preferences;
using PH.Infrastructure.Managers;
using PH.Infrastructure.Pooling;

namespace PH.SpaceShip
{
    public class SpaceShipFire : MonoBehaviour
    {
        [SerializeField] private Transform BulletSpawnPoint;
        [SerializeField] private string bulletObjectPoolTag;

        private GamePreferences gamePreferences;

        private float nextShootTime;

        ObjectPoolManager objectPoolManager;

        private void Start()
        {
            nextShootTime = Time.time;
            gamePreferences = FindObjectOfType<GameManager>().GamePreferences;
            objectPoolManager = ObjectPoolManager.Instance;

            objectPoolManager.CreatePool(bulletObjectPoolTag);
        }

        private void FixedUpdate()
        {
            Fire();
        }

        private void Fire()
        {
            if (Input.GetAxisRaw("Fire1") != 1 || Time.time <= nextShootTime) return;

            objectPoolManager.GetFromPool(gamePreferences.BulletPoolTag, BulletSpawnPoint.position, BulletSpawnPoint.rotation * Quaternion.Euler(Vector3.right * 90));

            nextShootTime = Time.time + 1f / gamePreferences.ShootingRate;
        }
    }
}
