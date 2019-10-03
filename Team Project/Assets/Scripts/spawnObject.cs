    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObject : MonoBehaviour
{

    public GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //need to turn this into an array 
        //also RIP this isnt the factory design pattern idont think? 
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(box);
        }
    }
}
