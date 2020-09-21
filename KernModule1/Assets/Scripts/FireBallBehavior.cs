using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBehavior : MonoBehaviour
{
   public GameObject BulletPrefab;
    // Update is called once per frame
    Vector3 movevector = new Vector3(10,0,0);
    float shotduration = 100;

    void Update()
    {
        //shoot Bullet
        float localsace = shotduration;
        if(Input.GetKeyDown(KeyCode.F) == true)
        { 
            while (shotduration > 0)
            {
                BulletPrefab.transform.position =-movevector;
                shotduration =- 1;
            }
        }
        shotduration = localsace;
    }
}
