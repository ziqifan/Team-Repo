using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 2;
    void Start()
    {
        
    }
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        transform.position += (Vector3.forward * speed) * y * Time.deltaTime;
        transform.position += (Vector3.right * speed) * x * Time.deltaTime;
    }
}
