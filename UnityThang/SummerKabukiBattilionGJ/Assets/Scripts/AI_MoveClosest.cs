using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_MoveClosest : MonoBehaviour
{

    public Rigidbody rb;
    public Vector3 Left;
    public Vector3 Up;
    public Vector3 Down;
    public Vector3 Right;

    
    public GameObject enemyList;
    public Transform[] enemies;

    private GameObject bestTarget;

    // Use this for initialization
    void Start()
    {
        Left = new Vector3(-10, 0, 0);
        Up = new Vector3(0, 0, 10);
        Down = new Vector3(0, 0, -10);
        Right = new Vector3(10, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        enemies = enemyList.GetComponentsInChildren<Transform>();
        if(enemies.Length > 1)
        {
            MoveToTarget(GetClosestEnemy(enemies).gameObject);
        }
    }
    
    Transform GetClosestEnemy(Transform[] enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in enemies)
        {
            //if(potentialTarget.name == "Team1" || potentialTarget.name == "Team2")
            //{
            //
            //}
            //else
            //{
                Vector3 directionToTarget = potentialTarget.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget;
                }

           // }
        }
    
        return bestTarget;
    }


    public void MoveToTarget(GameObject enemy)
    {
        if(enemy != null){
            if (enemy.transform.position.x > this.gameObject.gameObject.transform.position.x)
            {
                this.rb.AddForce(Right);
            }
            else if (enemy.transform.position.x < this.gameObject.gameObject.transform.position.x)
            {
                this.rb.AddForce(Left);
            }
            else if (enemy.transform.position.x == this.gameObject.gameObject.transform.position.x)
            {
                return;
            }
            if (enemy.transform.position.z > this.gameObject.gameObject.transform.position.z)
            {
                this.rb.AddForce(Up);
            }
            else if (enemy.transform.position.z < this.gameObject.gameObject.transform.position.z)
            {
                this.rb.AddForce(Down);
            }
            else if (enemy.transform.position.z == this.gameObject.gameObject.transform.position.z)
            {
                return;
            }
        }
    }
}
