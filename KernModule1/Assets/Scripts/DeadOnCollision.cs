using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadOnCollision    // Script voor op voorwerpen die moeten sterven op collision

{
    GameObject CollisionGameObject; //object in question
    GameObject[] possibleCollisions; //possible collision objects
    float distanceToObstacle = 0;
    public void init(GameObject voorwerp)
    {
        GameManager local = GameObject.Find("Scriptholder").GetComponent<GameManager>();
        CollisionGameObject = voorwerp;
    }

   public float LocalUpdate(GameObject[] collidables) //will check for collision using spherecast
    {
        possibleCollisions = collidables;
        int index = 0;
        foreach (GameObject item in possibleCollisions)
        {
            Vector3 Pos1 = CollisionGameObject.transform.position; //+ possibleCollisions[index].transform.position;
            RaycastHit hit;
            Debug.DrawLine(Pos1,item.transform.position, Color.white,  3.0f, true);
            //bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance);
            if (Physics.SphereCast(Pos1, 100f, CollisionGameObject.transform.up, out hit, 1000))
            {
                distanceToObstacle = hit.distance;
                Debug.Log("distance: " + distanceToObstacle);
                return distanceToObstacle;
            }
           // Debug.Log(item.name + Pos1 + distanceToObstacle);
            Debug.Log(CollisionGameObject.transform.position.ToString()+ " " + possibleCollisions[index].transform.position.ToString());
            index += 1;
        }
        return 0f;
    }
}
