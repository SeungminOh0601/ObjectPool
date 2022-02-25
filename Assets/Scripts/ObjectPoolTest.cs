using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolTest : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    private ComponentPool<Player> pool;

    private void Start()
    {
        pool = new ComponentPool<Player>(playerPrefab, 30);

        Debug.Log(pool.GetPooledObject());
        Debug.Log(pool.GetPooledComponent());

        for (int i = 0; i < 30; i++)
        {
            Player player = pool.GetPooledComponent();

            Debug.Log(player.Index);

            player.gameObject.SetActive(true);
        }
    }
}
