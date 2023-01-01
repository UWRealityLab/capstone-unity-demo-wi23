using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatControls : MonoBehaviour
{
    private Rigidbody boatBody;

    //Making these variables public makes them visible in the editor
    public float moveSpeed = 1.0f;
    public float rotateSpeed = 1.0f;

    void Start()
    {
        //Get a reference to the rigid body for the boat when the component starts
        boatBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Force the velocity and angular velocity to be zero at the start of each update to prevent the boat from drifting
        boatBody.velocity = new Vector3(0,0,0);
        boatBody.angularVelocity = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        { 
            //Move the boat forwards constantly at the given speed
            //This could also be implemented by translating the object every update in the forward direction but that would not play nicely with the physics system

            //The forward direction is rotated by 90 degrees because the "front" of the boat model is its side
            boatBody.velocity = (Quaternion.AngleAxis(-90, Vector3.up) * transform.forward) * moveSpeed;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //Move the boat backwards constantly at the given speed
            boatBody.velocity = (Quaternion.AngleAxis(-90, Vector3.up) * -transform.forward) * moveSpeed;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //Rotate the boat about the Y axis in the positive direction
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotateSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //Rotate the sprite about the Y axis in the negative direction
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * rotateSpeed, Space.World);
        }
    }
}
