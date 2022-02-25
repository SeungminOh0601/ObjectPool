using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    protected List<GameObject> pooledObjects;

    public ObjectPool() { }

    public ObjectPool(GameObject objectToPool, int count)
    {
        GameObject pool = new GameObject("[POOL] " + objectToPool.name);

        pooledObjects = new List<GameObject>();
        for (int i = 0; i < count; i++)
        {
            GameObject obj = GameObject.Instantiate(objectToPool, pool.transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        Debug.LogWarning("NOT ENOUGH OBJECTS IN THE POOL... PLEASE INCREASE THE COUNT");

        return null;
    }

}
