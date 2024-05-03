using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsController : MonoBehaviour
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public float maxVelocity = 1;
    public float spinForce = 1;

    // Update is called once per frame
    void Update()
    {
        int horizontalInput =(int) Input.GetAxis("Horizontal");
        int verticalInput = (int) Input.GetAxis("Vertical");
        float rotationVelocity = horizontalInput * maxVelocity/100;

        leftWheel.motorTorque = rotationVelocity;
        leftWheel.transform.Rotate((Time.deltaTime * rotationVelocity/360),0,0);

        rightWheel.motorTorque = rotationVelocity;
        rightWheel.transform.Rotate((Time.deltaTime * rotationVelocity/360),0,0);
        Debug.Log(Time.deltaTime);
    }
}
