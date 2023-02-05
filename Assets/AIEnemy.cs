using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class AIEnemy : MonoBehaviour
{
    //HIGH QUALITY CODE UP AHEAD
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AIDestinationSetter>().target = Object.FindObjectOfType<Spaceship>().transform;
    }

 
}
