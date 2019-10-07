using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float maxSpeed = 10.0f;
    public float jumpHeight = 250.0f;
    public bool isGrounded;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //hide mouse cursor
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Using unity build in Input to get movement on x and z axis
        //Using maxspeed to control moving speed
        float z = Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;
        float x = Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;

        //make player move to certain position
        transform.Translate(x, 0, z);

        //If player on the ground press space to jump
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(0, jumpHeight, 0);
            isGrounded = false;
        }
    }

    //Unity build in function to check if player touched ground
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
