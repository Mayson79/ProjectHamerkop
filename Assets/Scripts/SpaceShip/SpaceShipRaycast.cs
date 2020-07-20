using PH.Infrastructure.Managers;
using PH.Infrastructure.Preferences;
using PH.MessengerSystem;
using PH.MessengerSystem.MessageTargets;
using UnityEngine;

namespace PH.SpaceShip
{
    public class SpaceShipRaycast : MonoBehaviour
    {
        [SerializeField] private GameObject rayCastSpawn;
        [SerializeField] private LayerMask layerMask;

        private GamePreferences gamePreferences;

        private void Start()
        {
            gamePreferences = FindObjectOfType<GameManager>().GamePreferences;
        }

        private void FixedUpdate()
        {
            HitRaycast();
        }

        private void HitRaycast()
        {
            if (Physics.Raycast(rayCastSpawn.transform.position, rayCastSpawn.transform.TransformDirection(Vector3.forward), out var hit, gamePreferences.ObstaclesCheckDistance, layerMask))
            {
                Messenger.Execute<IRaycastHitTarget>(target => target.OnRaycastHitObstacle(hit.collider.gameObject.name, hit.distance));
                Debug.DrawRay(rayCastSpawn.transform.position, rayCastSpawn.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            }
            else
            {
                Messenger.Execute<IRaycastHitTarget>(target => target.OnRaycastHitNothing());
                Debug.DrawRay(rayCastSpawn.transform.position, rayCastSpawn.transform.TransformDirection(Vector3.forward) * gamePreferences.ObstaclesCheckDistance, Color.white);
            }
        }
    }
}