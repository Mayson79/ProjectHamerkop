using UnityEngine;

namespace PH.Gameplay
{
    public class SpawnPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        private void Start()
        {
            Instantiate(playerPrefab, transform.position, transform.rotation);
        }
    }
}