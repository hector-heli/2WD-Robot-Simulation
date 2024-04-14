using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsController : MonoBehaviour
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public float maxVelocity = 10f;
    public float spinForce = 10f;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float rotationVelocity = horizontalInput * maxVelocity/10;

        leftWheel.motorTorque = rotationVelocity;
        leftWheel.transform.Rotate((Time.deltaTime * -rotationVelocity*229),0,0);

        rightWheel.motorTorque = rotationVelocity;
        rightWheel.transform.Rotate((Time.deltaTime * rotationVelocity*229),0,0);
        // Debug.Log(leftWheel.rpm);
    }
}
