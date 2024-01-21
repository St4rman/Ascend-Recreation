using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("Refs")]
    public Transform orientation;
    public Transform player;
    public Transform playerGameObj;
    public Rigidbody rb;
    public float rotationSpeed;

    public GameObject[] cams;

    public enum viewMode
    {
        DefaultCam, 
        AscendCam
    }

    private viewMode currentViewMode;
    

    private void Start(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update(){
        Vector3 viewDirection = (player.position - new Vector3 (transform.position.x, player.position.y, transform.position.z)).normalized;
        orientation.forward= viewDirection;

        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 inputDirection = orientation.forward * zInput + orientation.right * xInput;

        if(inputDirection!= Vector3.zero){
            playerGameObj.forward = Vector3.Slerp(playerGameObj.forward, inputDirection.normalized, Time.deltaTime * rotationSpeed);
        }

        if(Input.GetKeyDown(KeyCode.R)) SwitchCamera(viewMode.DefaultCam);
        if(Input.GetKeyDown(KeyCode.Q)) SwitchCamera(viewMode.AscendCam);


    }

    private void SwitchCamera(viewMode currentMode){
        foreach(var x in cams){
            x.SetActive(false);
        }

        if(currentMode == viewMode.DefaultCam) cams[0].SetActive(true);
        if(currentMode == viewMode.AscendCam) cams[1].SetActive(true);

        currentViewMode = currentMode;

    }
}
