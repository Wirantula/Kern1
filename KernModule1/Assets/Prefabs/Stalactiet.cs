using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactiet : MonoBehaviour //moet uit envorimentidle komen!!!
{
    public GameObject StalactietPrefab;
    GameObject instance;
    Queue<GameObject> instances = new Queue<GameObject>();
    Vector3 startlocation;
    void Start()
    {
        startlocation = this.gameObject.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) == true)
        {

            instance = Instantiate(StalactietPrefab, startlocation + new Vector3( CreateRandomBetween(-5,7), CreateRandomBetween(4, 7), CreateRandomBetween(-1, -2)), StalactietPrefab.transform.rotation);
            instances.Enqueue(instance);
        }
        if(instances.Count >= 10)
        {
            destroyInstance();
        }
        //if (Input.GetKeyDown(KeyCode.D) == true)
        //{
        //    Destroy(instances[instances.Count-1]);
        //}
    }
    public void destroyInstance()
    {
        Destroy(instances.Dequeue());
        Debug.Log("hello");
    }
    public int CreateRandomBetween(int a,int b)
    {
        int getrandom = Random.RandomRange(a,b);
        
        return getrandom;
    }
}
