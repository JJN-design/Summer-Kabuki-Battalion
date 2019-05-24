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
        Time.timeScale = 0.0f;

        this.rb.maxAngularVelocity = 1;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        enemies = enemyList.GetComponentsInChildren<Transform>();
        if (enemies.Length > 1)
        {
            MoveToTarget(GetClosestEnemy(enemies).gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1.0f;
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
                if (potentialTarget.name == "Team1" || potentialTarget.name == "Team2")
                {
                    //if the target's name is the same as the empty holding all the objects it will ignore it.
                }
                else
                {
                    //checks the length between the current game object and the enemies
                    Vector3 directionToTarget = potentialTarget.position - currentPosition;
                    //squares the distance to get the magnitude
                    float dSqrToTarget = directionToTarget.sqrMagnitude;
                    if (dSqrToTarget < closestDistanceSqr)
                    {
                        //gets the gameobject the shortest distance away and makes it the best target to move towards
                        closestDistanceSqr = dSqrToTarget;
                        bestTarget = potentialTarget;
                    }
                }
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
        //checks to see if the enemy is null
        if (enemy != null)
        {
            //moves the game object towards the target on the x axis
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

            //moves the game object towards the target on the z axis
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
