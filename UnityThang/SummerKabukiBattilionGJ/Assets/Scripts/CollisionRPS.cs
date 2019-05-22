﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionRPS : MonoBehaviour {

    private RPS_Set CollScript = null;
    private RPS_Set ThisScript = null;

    /// <summary>
    /// Checks to see if the object has collided with anything
    /// </summary>
    /// <param name="collision">Collision</param>
    private void OnCollisionEnter(Collision collision)
    {
        CollScript = collision.gameObject.GetComponent<RPS_Set>();
        ThisScript = this.gameObject.GetComponent<RPS_Set>();
        checkTag(collision.gameObject);
    }

    /// <summary>
    /// Checks the tag of other to see if it is a rock, paper or scissor unit.
    /// </summary>
    /// <param name="other">GameObject</param>
    private void checkTag(GameObject other)
    {
        if(CollScript != null)
        {
            if(CollScript.getRock())
            {
                if(ThisScript.getRock())
                {
                    print("tie");
                }
                if (ThisScript.getPaper())
                {
                    print("Rock < Paper");
                    Destroy(other.gameObject);
                }
                if (ThisScript.getScissors())
                {
                    print("Rock > Scissors");
                    Destroy(this.gameObject);
                }
            }

            else if (CollScript.getPaper())
            {
                if (ThisScript.getRock())
                {
                    print("Paper > Rock");
                    Destroy(this.gameObject);
                }
                if (ThisScript.getPaper())
                {
                    print("tie");
                }
                if (ThisScript.getScissors())
                {
                    print("Paper < Scissors");
                    Destroy(other.gameObject);
                }
            }

            else if (CollScript.getScissors())
            {
                if (ThisScript.getRock())
                {
                    print("Scissors < Rock");
                    Destroy(other.gameObject);
                }
                if (ThisScript.getPaper())
                {
                    print("Scissors > Paper");
                }
                if (ThisScript.getScissors())
                {
                    print("Rock > Scissors");
                    Destroy(this.gameObject);
                }
            }
        }
    }
}