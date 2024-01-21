using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ascend : MonoBehaviour
{
    [Header("References")]
    public GameObject PlayerRef;
    public bool ascendIsActivated;
    private Collider objectColl;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(ascendIsActivated){
            fireRaycast();
        }
    }

    private void fireRaycast(){

        Ray ascendRay = new Ray(transform.position, transform.up);

        Debug.DrawRay(ascendRay.origin, ascendRay.direction * 100, Color.red);

        RaycastHit hit;
        
        if(Physics.Raycast(ascendRay.origin, ascendRay.direction, out hit, Mathf.Infinity)){

            Debug.DrawRay(ascendRay.origin, ascendRay.direction * hit.distance, Color.green);
            
            if(hit.collider != null){
                objectColl = hit.collider;
                Debug.Log("checking max" + objectColl.bounds.max);
            }

        }
    }

    private void checkIfObstructed(){

    }
}
