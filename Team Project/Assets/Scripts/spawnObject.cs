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
        //this will spawn one thing for each time you press the button, i might switch it to some particle effect idk
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(box); 
        }
    }
}
