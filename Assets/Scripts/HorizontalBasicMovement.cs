using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//-----------------------------------------------------------------------
// Basic movement when we want the player to move using a gamepad
// Author (Discord): Gio#0753
//-----------------------------------------------------------------------

public class HorizontalBasicMovement : MonoBehaviour {
    
    new Rigidbody rigidbody;
    new Camera camera;

    [SerializeField] bool DevMode;

    [SerializeField] float speed = 3;
    // float rotationSpeed = 45f;
    private float f;

    public SlideController slideController;
    public AudioChanger audioChanger;

    private const float HORIZONTAL_MULTIPLIER = 16;

    private bool gameHasStarted = false;

    public UIManager ui;

    public GameObject lifes;
    public GameObject score;

    private float initialGyroRotation;
    // This value defines if the user is tilting the head to the right or to the left
    private float wAttitude;

    void Start() {
        camera = GetComponentInChildren<Camera>();
        rigidbody = GetComponent<Rigidbody>();
        Input.gyro.enabled = true;
        // initialGyroRotation = Input.gyro.attitude.w;
        if (DevMode) StartGame();
    }
    protected void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;
        // DEBUG DATA
        GUILayout.Label("Orientation: " + Screen.orientation + ". Speed: " + slideController.slideSpeed);
        GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude);
        GUILayout.Label("Width/font: " + Screen.width + " : " + GUI.skin.label.fontSize);
        GUILayout.Label("Calculated attitude: " + (Input.gyro.attitude.w - initialGyroRotation));
    }
    
    void Update() {
        // Debug.Log(Input.gyro.attitude);
       
        if (!gameHasStarted) f = Input.acceleration.z;

        // Options to try the game on the unity editor
        // Skips the initial screen and calibration
        if (DevMode) {
            // Keyboard controlls
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
            // If the player is allowed to slide the player can move sideways
        } else if (slideController.isAllowedToSlide) {
            float w = 0;
            wAttitude = Input.gyro.attitude.w - initialGyroRotation;
            // Since the sensivility is high, the user can stay in position if he decides to stay between these values
            if (wAttitude > 0.05 || wAttitude < -0.05) w = wAttitude*HORIZONTAL_MULTIPLIER;
            
            Vector3 velocity = gameObject.transform.right * w * speed;
            transform.position += velocity * Time.deltaTime;
        }
        // If the player looks up the game starts
        if (!gameHasStarted && f>0.5f)
        {
            StartGame();
        }
        // Increments lineally the velocity
        if (gameHasStarted){
            slideController.slideSpeed += 0.002f;
        }
    }
    // Starts the game, allows the user to slide disables the main screen ui elements and activates life and score
    public void StartGame() {
        initialGyroRotation = Input.gyro.attitude.w;
        gameHasStarted = true;
        slideController.isAllowedToSlide = true;
        audioChanger.StartSlideSong();
        ui.ChangeUserMessage("");
        lifes.SetActive(true);
        score.SetActive(true);
    }
}
