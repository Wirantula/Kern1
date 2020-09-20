using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPool
{
    public class Pool
    {
        public string name;
        public GameObject stalactiet;
        public int Size = 15;
    }
    public List<Pool> Pools; //wordt normaal gesproken gevuld door unity met gameobjects
    public Dictionary<string,Queue<GameObject>> PoolDictionary;

    #region Singleton
    public static ObjectPool Instance;
  
    public void awake()
    {
        Instance = this;
    }
    #endregion
    public void FillPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Pools.Add(new Pool());
        }
    }
    public void execution()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>(); //instantie

        foreach (Pool item in Pools)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();
            for (int i = 0; i < item.Size; i++)
            {
                item.name = i.ToString();
                GameManager origin = GameObject.Find("Scriptholder").GetComponent<GameManager>();
                GameObject Stalactiet = origin.spawn;
                origin.Spawner(Stalactiet);
                Stalactiet.SetActive(false);
                objectpool.Enqueue(Stalactiet);
            }
            PoolDictionary.Add(item.name, objectpool);
        }
    }
    public GameObject SpawnFromPool (string name,Vector3 position, Quaternion rotation)
    {
        Debug.Log("start spawn");
        if (!PoolDictionary.ContainsKey(name))
        { 
            return null;
        }

        GameObject stalactiet = PoolDictionary[name].Dequeue();

        stalactiet.SetActive(true);
        stalactiet.transform.position = position;
        stalactiet.transform.rotation = rotation;

        PoolDictionary[name].Enqueue(stalactiet);

        return stalactiet;
    }
}
