using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPS_Set : MonoBehaviour {
    public bool Rock;
    public bool Paper;
    public bool Scissors;

    
    public bool getRock()
    {
        return Rock;
    }

    public bool getPaper()
    {
        return Paper;
    }

    public bool getScissors()
    {
        return Scissors;
    }
}
