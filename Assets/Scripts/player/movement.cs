using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [Header("mvement")]
    public float speed;
    public Transform orientation;

    public float xInput;
    public float zInput;

    Vector3 moveDirection;
    Rigidbody rb;

    private void Start(){
        Debug.Log("movement script on");
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        movePlayer();
    }

    private void GetInput(){
        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");

    }

    private void movePlayer(){
        moveDirection = orientation.forward * zInput + orientation.right* xInput;
        rb.AddForce(moveDirection * speed,  ForceMode.Force);

    }
}
