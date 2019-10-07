using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    //Hold left mouse to pick up the object select by mouse
    void OnMouseDown()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = GameObject.Find("Destination").transform.position;
        this.transform.parent = GameObject.Find("Destination").transform;
    }

    //Release left mouse to drop the object
    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;
    }
}
