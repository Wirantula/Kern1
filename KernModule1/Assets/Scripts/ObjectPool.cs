using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPool
{
    //public class Pool
    //{
    //    public string name;
    //    public GameObject stalactiet;
    //    public int Size = 15;
    //}
    public List<GameManager.Pool> Pools; //wordt normaal gesproken gevuld door unity met gameobjects
    public Dictionary<string,Queue<GameObject>> PoolDictionary;

    #region Singleton
    public static ObjectPool Instance;
  
    public void awake()
    {
        Instance = this;
    }
    #endregion
    //public void FillPool(int amount, string Name)
    //{
    //    for (int i = 0; i < amount; i++)
    //    {
    //        Pool pool = new Pool();
    //        pool.name = Name;
    //        Pools.Add(pool);
    //    }
    //}
    public void execution(List<GameManager.Pool> fillpools, GameObject obj,GameManager origin)
    {
        Pools = fillpools;
        PoolDictionary = new Dictionary<string, Queue<GameObject>>(); //instantie

        foreach (GameManager.Pool pool in Pools)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();
            for (int i = 0; i < pool.Size; i++)
            {
                // item.name = "stalactietPrefab(Clone)" + i;
                
               
                origin.Spawner(obj);
                obj.SetActive(false);
                objectpool.Enqueue(obj);
               
            }
            PoolDictionary.Add(origin._stalac.tag, objectpool);
        }
    }
    public GameObject SpawnFromPool (string name,Vector3 position, Quaternion rotation)
    {
        Debug.Log(name);
        //"stalactietPrefab"

        if (!PoolDictionary.ContainsKey(name))
        {
            return null;
        }

        Debug.Log("dequeue");
        GameObject objecttospawn = PoolDictionary[name].Dequeue();

        objecttospawn.SetActive(true);
        objecttospawn.transform.position = position;
        objecttospawn.transform.rotation = rotation;

        PoolDictionary[name].Enqueue(objecttospawn);

        return objecttospawn;
    }
}
