using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingEnemy : MonoBehaviour
{
    //HIGH QUALITY CODE UP AHEAD  // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * 5;
    }

    // Update is called once per frame
    void Update()
    {

        //transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
}
