using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//code referenced from https://learn.unity.com/tutorial/movement-basics?projectId=5c514956edbc2a002069467c#5c7f8528edbc2a002053b711

public class cameraController : MonoBehaviour
{

    public GameObject Player;
    private Vector3 offset; 
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + offset; 
    }
}
