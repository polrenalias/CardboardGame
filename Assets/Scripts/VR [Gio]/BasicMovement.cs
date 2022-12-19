using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------
// Basic movement when we want the player to move using a gamepad
// Author (Discord): Gio#0753
//-----------------------------------------------------------------------

public class BasicMovement : MonoBehaviour {

    
    new Rigidbody rigidbody;
    new Camera camera;

    [SerializeField] bool DevMode;
    int jumps = 1;
    [SerializeField] float speed = 3, jumpForce = 500;
    float rotationSpeed = 45f;

    void Start() {
        camera = GetComponentInChildren<Camera>();
        rigidbody = GetComponent<Rigidbody>();
    }
    
    void Update() {
        if (DevMode) {
            if (Input.GetKey("w")) 
			{
                Vector3 velocity = camera.transform.forward * 1 * speed;
                transform.position += velocity * Time.deltaTime;
			}
            if (Input.GetKey("s"))
                {
                Vector3 velocity = camera.transform.forward * -1 * speed;
                transform.position += velocity * Time.deltaTime;
                }
            if (Input.GetKey("d")) transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            if (Input.GetKey("a")) transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        } else {
            //Vector3 velocity = camera.transform.forward * Input.GetAxis("Vertical") * speed;
            float f = Input.acceleration.z;
            //agafa valors positius i negatius per si el mòbil esta girat al revès
            if (f>0.3f || f<-0.3f)
            {
                Vector3 velocity = camera.transform.forward * 1 * speed;
                transform.position += velocity * Time.deltaTime;
            }
        }
        if (Input.GetButtonDown("Jump")) {
            Jump();
        }
    }

    public void Jump() {
        if(jumps >= 1) {
            rigidbody.AddForce(Vector3.up * jumpForce);
            jumps--;
        }
    }

    void OnCollisionEnter(Collision collision) {
        jumps = 1;
    }
}
