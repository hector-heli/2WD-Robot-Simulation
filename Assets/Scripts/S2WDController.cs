using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class S2WDController : MonoBehaviour {
    public float speed = 0.1f;
    public Rigidbody rb;
    public Vector3 rotationRobot;
    public Vector3 velocityRobot;

    public Transform RightWheelModel;
    public Transform LeftWheelModel;

    const float WHELL_RADIO = 0.035f;
    const float  L = 0.141f;

    private float W;

    float leftDirection; 
    float rightDirection;

    void Awake(){
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update(){    
        rotationRobot = Vector3.zero;
        velocityRobot = Vector3.zero;

        if(Input.GetKey(KeyCode.Keypad7)) leftDirection = -1;
        else if(Input.GetKey(KeyCode.Keypad1)) leftDirection = 1;
        else leftDirection = 0;

        if(Input.GetKey(KeyCode.Keypad9)) rightDirection = 1;
        else if(Input.GetKey(KeyCode.Keypad3)) rightDirection = -1;
        else rightDirection = 0;

        float wheelW = (float)(speed/WHELL_RADIO),
            rightW = wheelW * rightDirection,
            leftW = wheelW * leftDirection,
            rightWheelLinearSpeed = rightW * WHELL_RADIO,
            leftWheelLinearSpeed = -leftW * WHELL_RADIO,
            W =( leftWheelLinearSpeed - rightWheelLinearSpeed )/L,
            // theta = rb.transform.rotation.eulerAngles.y,
            theta = W/Time.fixedDeltaTime,
            xVelocity = ((leftWheelLinearSpeed + rightWheelLinearSpeed)/2) * (float)Math.Cos(theta),
            yVelocity = ((leftWheelLinearSpeed + rightWheelLinearSpeed)/2) * (float)Math.Sin(theta);

            velocityRobot.z = xVelocity;
            velocityRobot.x = yVelocity;

        // Debug.Log(xVelocity);
        
        RightWheelModel.transform.Rotate (0, 0, (float)(rightW * 180/Math.PI) * Time.fixedDeltaTime);
        LeftWheelModel.transform.Rotate (0, 0, (float)(leftW * 180/Math.PI) * Time.fixedDeltaTime);

        rotationRobot.y = (float) (W * 180/Math.PI);

        Debug.Log(string.Format("{0:N5}", leftWheelLinearSpeed)  + "       " + string.Format("{0:N5}", rightWheelLinearSpeed) + "       " + string.Format("{0:N5}", Math.Sin(theta)));
    }
    
    protected void FixedUpdate() {
        Move(rotationRobot, velocityRobot);
    }
    void Move (Vector3 direction, Vector3 velocity) {
        Quaternion deltaRotation = Quaternion.Euler(direction * Time.fixedDeltaTime);
        rb.MoveRotation (rb.rotation * deltaRotation);

        // rb.MovePosition(rb.transform.position + velocity * Time.fixedDeltaTime);
        rb.velocity = ((transform.forward * velocity.z + transform.right * velocity.x).normalized)  * speed;  
    }
}
