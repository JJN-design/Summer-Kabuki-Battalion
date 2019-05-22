using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Move : MonoBehaviour {

    public Rigidbody rb;
    public GameObject enemy;
    public Vector3 Left;
    public Vector3 Up;
    public Vector3 Down;
    public Vector3 Right;


    // Use this for initialization
    void Start () {
        Left = new Vector3(-10, 0, 0);
        Up = new Vector3(0, 0, 10);
        Down = new Vector3(0, 0, -10);
        Right = new Vector3(10, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (enemy != null)
        {
            if(enemy.transform.position.x > this.gameObject.gameObject.transform.position.x)
            {
                this.rb.AddForce(Right);
            }
            else if (enemy.transform.position.x < this.gameObject.gameObject.transform.position.x)
            {
                this.rb.AddForce(Left);
            }
            else if (enemy.transform.position.x == this.gameObject.gameObject.transform.position.x)
            {
                
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
                
            }
        }
    }
}
