using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsController : MonoBehaviour
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public float maxVelocity = 10;
    public float spinForce = 1;

    // Update is called once per frame
    void Update()
    {
        int horizontalInput =(int) Input.GetAxis("Horizontal");
        int verticalInput = (int) Input.GetAxis("Vertical");
        float rotationVelocity = maxVelocity;

        if( horizontalInput != 0 ){
            leftWheel.brakeTorque = 0;
            rightWheel.brakeTorque = 0;

            if(leftWheel.rotationSpeed > 360){
                leftWheel.motorTorque = rotationVelocity * horizontalInput;
            } else {
                leftWheel.motorTorque = 0;
            }
            // leftWheel.transform.Rotate((Time.deltaTime * rotationVelocity), 0, 0);
            
            if(rightWheel.rotationSpeed > 360){
                rightWheel.motorTorque = -rotationVelocity * horizontalInput;
            } else{
                rightWheel.motorTorque = 0;
            }
            // rightWheel.transform.Rotate((Time.deltaTime * rotationVelocity), 0, 0);

            Debug.Log("\nVel Rueda Izq = " + leftWheel.rotationSpeed + "\nVel Rueda Der = " + rightWheel.rotationSpeed);
        } else if( verticalInput != 0 ){ 
            leftWheel.brakeTorque = 0;
            rightWheel.brakeTorque = 0;

            leftWheel.motorTorque = rotationVelocity * verticalInput;
            leftWheel.transform.Rotate((Time.deltaTime * rotationVelocity), 0, 0);
            
            rightWheel.motorTorque = rotationVelocity * verticalInput;
            rightWheel.transform.Rotate((Time.deltaTime * rotationVelocity), 0, 0);

            Debug.Log((int) Input.GetAxis("Vertical"));
        } else {
            leftWheel.brakeTorque = 100;
            rightWheel.brakeTorque = 100;
            Debug.Log("\nVel Rueda Izq = " + leftWheel.rotationSpeed + "\nVel Rueda Der " + rightWheel.rotationSpeed);
        }
    }
}
