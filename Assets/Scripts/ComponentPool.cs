using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentPool<T> : ObjectPool
{
    private List<T> pooledComponents;

    public ComponentPool(GameObject objectToPool, int count) : base(objectToPool, count)
    {
        pooledComponents = new List<T>();
        if (objectToPool.TryGetComponent<T>(out var component))
        {
            foreach (GameObject obj in pooledObjects)
            {
                pooledComponents.Add(obj.GetComponent<T>());
            }
        }
    }

    public T GetPooledComponent()
    {
        GameObject pooledObject = GetPooledObject();
        if (pooledObject != null)
        {
            return pooledComponents[pooledObjects.IndexOf(pooledObject)];
        }
        else
        {
            return default(T);
        }
    }
}
