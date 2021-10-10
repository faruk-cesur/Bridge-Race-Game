using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    [Serializable]
    public struct Pool
    {
        public Queue<GameObject> pooledObject;
        public GameObject objectPrefab;
        public int poolSize;
    }

    public Pool[] pools = null;

    private void Awake()
    {
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i].pooledObject = new Queue<GameObject>();
            for (int j = 0; j < pools[i].poolSize; j++)
            {
                GameObject obj = Instantiate(pools[i].objectPrefab);
                obj.SetActive(false);
                pools[i].pooledObject.Enqueue(obj);
            }
        }
    }

    public GameObject GetPooledObject(int objectType)
    {
        if (objectType >= pools.Length) return null;
        if (pools[objectType].pooledObject.Count == 0)
            AddSizePool(5, objectType);
        GameObject obj = pools[objectType].pooledObject.Dequeue();
        obj.SetActive(true);
        return obj;
    }

    public void SetPooledObject(GameObject pooledObject, int objectType)
    {
        if (objectType >= pools.Length) return;
        pools[objectType].pooledObject.Enqueue(pooledObject);
        pooledObject.SetActive(false);
    }

    public void AddSizePool(float amount, int objectType)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = Instantiate(pools[objectType].objectPrefab);
            obj.SetActive(false);
            pools[objectType].pooledObject.Enqueue(obj);
        }
    }
}