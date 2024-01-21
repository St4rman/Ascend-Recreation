using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ascend : MonoBehaviour
{
    [Header("References")]
    public GameObject PlayerRef;
    bool ascendIsActivated  = true;
    public bool canAscend;
    public LayerMask IgnoreLayer;
    private Collider objectColl;
    private Vector3 pointOfExitOnSurface;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(ascendIsActivated){
            fireRaycast();
        }
        if(ascendIsActivated && canAscend){
            if(Input.GetKeyDown(KeyCode.E)){
                StartCoroutine(StartAscend(pointOfExitOnSurface));
            }
        }
    }

    private void fireRaycast(){

        Ray ascendRay = new Ray(transform.position, transform.up);

        Debug.DrawRay(ascendRay.origin, ascendRay.direction * 100, Color.red);

        RaycastHit hit;
        
        if(Physics.Raycast(ascendRay.origin, ascendRay.direction, out hit, Mathf.Infinity, ~IgnoreLayer)){

            Debug.DrawRay(ascendRay.origin, ascendRay.direction * hit.distance, Color.green);
            
            if(hit.collider != null){

                objectColl = hit.collider;

                //we're getting point of exit manually here
                Vector3 ExitPoint = new Vector3(hit.point.x, hit.point.y + 2* objectColl.bounds.extents.y, hit.point.z);
                
                checkIfObstructed(ExitPoint);
            }

        } else { 
            canAscend = false;
        }
    }

    private void checkIfObstructed(Vector3 pointofExit){

        Ray ray = new Ray(pointofExit, transform.up);
        RaycastHit oHit;

        if(Physics.Raycast(ray.origin, ray.direction, out oHit, Mathf.Infinity, ~IgnoreLayer)){

            if(oHit.collider != null){ //adn and has enough place for player to stand
                canAscend = false;
            }

        } else {
            //if there is enough space for player model
            pointOfExitOnSurface = pointofExit;
            canAscend = true;
        }
    }

    IEnumerator StartAscend(Vector3 AscendToPoint){
        Debug.Log(AscendToPoint);
        PlayerRef.GetCompo
        yield return null;
    }
}
