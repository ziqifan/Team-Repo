using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 2;
    public bool isGrounded;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
    }
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        transform.position += (Vector3.forward * speed) * y * Time.deltaTime;
        transform.position += (Vector3.right * speed) * x * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 0.5f, 0), ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "invisibleTop")
        {
            Debug.Log("you win");
        }
    }
}
