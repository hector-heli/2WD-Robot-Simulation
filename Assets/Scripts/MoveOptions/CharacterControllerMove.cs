using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterControllerMove : MonoBehaviour
{
    public float speed = 1f;
    CharacterController cc;
    public Vector3 movementInput;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {   
        movementInput = Vector3.zero;
        
        if(Input.GetKey(KeyCode.W)) movementInput.x = 1;
        else if(Input.GetKey(KeyCode.S)) movementInput.x = -1;
        
        if(Input.GetKey(KeyCode.D)) movementInput.z = 1;
        else if(Input.GetKey(KeyCode.A)) movementInput.z = -1;
        Move(movementInput);
    }
    
    void Move (Vector3 direction){
        cc.SimpleMove (direction.normalized * speed);
    }
}
