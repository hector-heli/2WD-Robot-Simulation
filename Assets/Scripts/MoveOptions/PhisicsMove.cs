using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhisicsMove : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody rb;
    public Vector3 movementInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {   
        movementInput = Vector3.zero;
        if(Input.GetKey(KeyCode.W)) movementInput.z = 1;
        else if(Input.GetKey(KeyCode.S)) movementInput.z = -1;
        
        if(Input.GetKey(KeyCode.D)) movementInput.x = 1;
        else if(Input.GetKey(KeyCode.A)) movementInput.x = -1;
    }
    
    protected void FixedUpdate() {
        Move(movementInput);
    }
    void Move (Vector3 direction){
        // rb.AddForce (direction.normalized * speed, ForceMode.Acceleration);
        rb.MovePosition(rb.position + direction.normalized * speed * Time.fixedDeltaTime);
    }
}
