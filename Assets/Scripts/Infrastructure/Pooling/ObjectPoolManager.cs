using PH.Infrastructure.Managers;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PH.Infrastructure.Pooling
{
    public class ObjectPoolManager : AbstractManager<ObjectPoolManager>
    {
        public List<Pool> pools;
        public Dictionary<string, Queue<GameObject>> objectsDictionary;

        protected override void Start()
        {
            base.Start();

            objectsDictionary = new Dictionary<string, Queue<GameObject>>();
        }

        public void CreatePool(string tag)
        {
            var pool = pools.First(p => p.Tag == tag);

            if (objectsDictionary.ContainsKey(pool.Tag))
            {
                Debug.LogWarning($"Pool already exist");
                return;
            }

            if (pool.Prefab.GetComponent<IObjectPoolItem>() == null)
            {
                throw new System.SystemException($"Prefab {pool.Prefab} doesn't implement {nameof(IObjectPoolItem)}");
            }

            var objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.Size; i++)
            {
                var obj = Instantiate(pool.Prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            objectsDictionary.Add(pool.Tag, objectPool);
        }

        public void ClearPool(string tag)
        {
            if (!objectsDictionary.ContainsKey(tag))
            {
                Debug.LogError($"Pool with tag {tag} doesn't exist");
                return;
            }

            if (objectsDictionary[tag].Count == 0)
            {
                return;
            }

            var countInPool = objectsDictionary[tag].Count;

            for (int i = 0; i < countInPool; i++)
            {
                Destroy(objectsDictionary[tag].Dequeue());
            }

            objectsDictionary.Clear();
        }

        public GameObject GetFromPool(string tag, Vector3 position, Quaternion rotation)
        {
            if (!objectsDictionary.ContainsKey(tag))
            {
                throw new System.NullReferenceException($"Pool with tag {tag} doesn't exist");
            }

            if (objectsDictionary[tag].Count < 1)
            {
                Debug.LogWarning($"No objects in pool");
                return null;
            }

            var objectToSpawn = objectsDictionary[tag].Dequeue();

            var pooledObj = objectToSpawn.GetComponent<IObjectPoolItem>();
            pooledObj.ResetObject(position, rotation);

            objectsDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }

        [System.Serializable]
        public class Pool
        {
            public string Tag;
            public GameObject Prefab;
            public int Size;
        }
    }
}