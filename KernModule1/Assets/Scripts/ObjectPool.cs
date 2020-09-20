using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPool
{
    [System.Serializable]
    public class Pool
    {
        public string name = "stalactiet";
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
    public void execution()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>(); //instantie

        foreach (Pool item in Pools)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();
            for (int i = 0; i < item.Size; i++)
            {
                Debug.Log("objectpool");   
                GameObject Stalactiet = new GameObject(); //moet nog geinstantiate worden :(
                GameManager origin = GameObject.Find("Scriptholder").GetComponent<GameManager>();
                origin.Spawner(Stalactiet);
                Stalactiet.SetActive(false);
                objectpool.Enqueue(Stalactiet);
            }
            PoolDictionary.Add("String", objectpool);
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
