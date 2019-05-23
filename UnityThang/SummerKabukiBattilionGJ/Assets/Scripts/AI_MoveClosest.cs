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

    public int ID;

    
    public GameObject[] enemyPlayer1;
    public GameObject[] enemyPlayer2;

    public Transform[] enemies;

    public GameObject bestTarget;

    /// <summary>
    /// Use this for initialization
    /// </summary> 
    void Start()
    {
        Left = new Vector3(-10, 0, 0);
        Up = new Vector3(0, 0, 10);
        Down = new Vector3(0, 0, -10);
        Right = new Vector3(10, 0, 0);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        enemyPlayer2 = GameObject.FindGameObjectsWithTag("Player 2");
        enemyPlayer1 = GameObject.FindGameObjectsWithTag("Player 1");
        if (ID == 1)
        {
            enemies = new Transform[enemyPlayer2.Length];
            for (int i = 0; i < enemyPlayer2.Length; i++)
            {
                enemies[i] = enemyPlayer2[i].transform;
            }
        }
        else if (ID == 2)
        {
            enemies = new Transform[enemyPlayer1.Length];
            for (int i = 0; i < enemyPlayer1.Length; i++)
            {
                enemies[i] = enemyPlayer1[i].transform;
            }
        }

        
        if (enemies.Length > 1)
        {
            MoveToTarget(GetClosestEnemy(enemies).gameObject);
        }
    }
    
    /// <summary>
    /// Goes through the list of enemies and gets the closest 
    /// </summary>
    /// <param name="enemies">Transform[]</param>
    /// <returns>the target closest to this object</returns>
    Transform GetClosestEnemy(Transform[] enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in enemies)
        {
            if (potentialTarget != null)
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
        }
    
        return bestTarget;
    }

    /// <summary>
    /// Moves towards the closest enemy
    /// </summary>
    /// <param name="enemy"></param>
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
