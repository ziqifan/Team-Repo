using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCube : MonoBehaviour
{
    private int type;
    private float x;
    private float z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log(transform.position);
            type = Random.Range(1, 5);
            x = Random.Range(-47f, 45f);
            z = Random.Range(-20f, 23f);
            Vector3 pos = new Vector3(x, 4f, z);
            CubeFactory.MakeCube(type, pos, Quaternion.identity);
        }
    }
}
