using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple : MonoBehaviour {

    //Create a RigidBody Reference for use later in the code
    private Rigidbody rb;

    //Create a publically accessible number for use within code
    public int speed;

    //create publically accessible value for jump power|
    public int jumpPower;

    // Run when the script starts
    private void Start()
    {
        // set 'rb' equal to the value of the default RigidBody reference
        rb = GetComponent<Rigidbody>();
    }

    // Check Every frame
    void FixedUpdate()
    {
        // creates an entity named 'moveHorizontal' and sets it's value equal to the "Virtual Axis"s ''Horizontal'' value.
        float moveHorizontal = Input.GetAxis("Horizontal");
        // creats an entity name 'moveVertical' and sets it's value equal to the "Virtual Axis"s 'Vertical' value.
        float moveVertical = Input.GetAxis("Vertical");



        // Create a blank Vector3 Object named 'movement' to contain reference information
        // This will be used for x and z movement
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //Create dedicated Vector3 attributes for jump function
        Vector3 jump = new Vector3(0.0f, jumpPower, 0.0f);

        // Add force to the rigidbody 
        // add the force that's called 'movement'
        rb.AddForce(movement*speed);

        //add jump to the rigidbody
        if (Input.GetKeyDown("space")){
            rb.AddForce(jump);
        }
        



    }
}
