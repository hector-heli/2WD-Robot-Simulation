using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NavMeshAgent_Move : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent nma;

    void Awake()
    {
        nma = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {   
       if (Input. GetMouseButtonDown(0)){
            Debug.Log(Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)){
                Move (hit.point);
            }
       }
    }
    
    void Move (Vector3 position){
        nma.SetDestination (position);
    }
}
