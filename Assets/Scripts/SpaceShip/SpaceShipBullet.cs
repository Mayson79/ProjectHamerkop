using UnityEngine;
using PH.Infrastructure.Preferences;
using PH.Infrastructure.Managers;
using PH.Gameplay.Interfaces;
using PH.Infrastructure.Pooling;
using System.Collections;

namespace PH.SpaceShip
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]

    public class SpaceShipBullet : MonoBehaviour, IObjectPoolItem
    {
        private Rigidbody rb;
        private Coroutine disableAfterCoroutine;

        private GamePreferences gamePreferences;

        private void Awake()
        {
            gamePreferences = FindObjectOfType<GameManager>().GamePreferences;
            rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            IEnumerator DisableAfterRoutine()
            {
                yield return new WaitForSeconds(gamePreferences.BulletLifeTime);

                gameObject.SetActive(false);
            }

            if (disableAfterCoroutine != null) return;

            disableAfterCoroutine = StartCoroutine(DisableAfterRoutine());
            disableAfterCoroutine = null;
        }

        private void OnDisable()
        {
            if (disableAfterCoroutine == null) return;

            StopCoroutine(disableAfterCoroutine);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var damagable = collision.gameObject.GetComponent<IDamagable>();
            
            if (damagable != null)
            {
                damagable.Damage(this, gamePreferences.BulletDamage);
            }

            gameObject.SetActive(false);
        }

        public void ResetObject(Vector3 position, Quaternion rotation)
        {
            gameObject.SetActive(true);
            transform.position = position;
            transform.rotation = rotation;

            rb.velocity = new Vector3(0f, 0f, gamePreferences.BulletForce);
        }
    }
}
