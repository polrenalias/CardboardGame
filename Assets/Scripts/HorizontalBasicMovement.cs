using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------
// Basic movement when we want the player to move using a gamepad
// Author (Discord): Gio#0753
//-----------------------------------------------------------------------

public class HorizontalBasicMovement : MonoBehaviour {
    
    new Rigidbody rigidbody;
    new Camera camera;

    [SerializeField] bool DevMode;
    int jumps = 1;
    [SerializeField] float speed = 3, jumpForce = 500;
    // float rotationSpeed = 45f;
    private float f;

    public SlideController slideController;
    public AudioChanger audioChanger;

    private const float HORIZONTAL_MULTIPLIER = 8;

    private bool gameHasStarted = false;

    public UIManager ui;

    void Start() {
        camera = GetComponentInChildren<Camera>();
        rigidbody = GetComponent<Rigidbody>();
        Input.gyro.enabled = true;
    }
    protected void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;

        GUILayout.Label("Orientation: " + Screen.orientation + ". Speed: " + slideController.slideSpeed);
        GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude);
        GUILayout.Label("iphone width/font: " + Screen.width + " : " + GUI.skin.label.fontSize);
    }
    
    void Update() {
        // Debug.Log(Input.gyro.attitude);
        if (!gameHasStarted) f = Input.acceleration.z;
        if (DevMode) {
            // if (Input.GetKey("w")) 
			// {
            //     Vector3 velocity = camera.transform.forward * 1 * speed;
            //     transform.position += velocity * Time.deltaTime;
			// }
            // if (Input.GetKey("s"))
            // {
            //     Vector3 velocity = camera.transform.forward * -1 * speed;
            //     transform.position += velocity * Time.deltaTime;
            // }
            if (Input.GetKey("d")) 
            {
                Vector3 velocity = gameObject.transform.right * 1 * speed;
                transform.position += velocity * Time.deltaTime;
            }
            if (Input.GetKey("a"))
            {
                Vector3 velocity = gameObject.transform.right * -1 * speed;
                transform.position += velocity * Time.deltaTime;
            }
        } else if (slideController.isAllowedToSlide) {
            //Vector3 velocity = camera.transform.forward * Input.GetAxis("Vertical") * speed;
            float w = (Input.gyro.attitude.w)*HORIZONTAL_MULTIPLIER;
            //agafa valors positius i negatius per si el mòbil esta girat al revès
            Vector3 velocity = gameObject.transform.right * w * speed;
            transform.position += velocity * Time.deltaTime;
        }
        if (!gameHasStarted && f>0.5f)
        {
            gameHasStarted = true;
            slideController.isAllowedToSlide = true;
            audioChanger.StartSlideSong();
            ui.ChangeUserMessage("");
        }
        if (gameHasStarted){
            slideController.slideSpeed += 0.01f;
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
