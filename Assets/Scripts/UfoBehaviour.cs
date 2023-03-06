using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class UfoBehaviour : MonoBehaviour
{
    float position;
    float originalPosition;
    float speed = 4f;
    float DEFAULT_DISTANCE = -7f;
    float distance = 0;    

    public Player player;

    public AudioSource crash;
    public AudioSource repair;

    public GameObject crashParticles;

    bool isRepair = false;

    void Start()
    {
        distance = DEFAULT_DISTANCE;
        originalPosition = transform.position.x;
        SetObstacle();
    }
    // Defines via RNG what this object is going to be, an UFO, a repair wrench or nothing
    void SetObstacle()
    {
        position = originalPosition;
        // UFO
        if (UnityEngine.Random.Range(0,3) == 0)
        {
            // Left or right movement
            if (UnityEngine.Random.Range(0,2) == 0) 
            {
                distance = Math.Abs(distance);
            }
        }
        // Wrench or nothing
        else
        {
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            // Repair
            if (UnityEngine.Random.Range(0,10) == 0)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                isRepair = true;
            }
            else
            {
                // It's nothing
                gameObject.GetComponent<SphereCollider>().enabled = false;
            }

        }  
    }
    // Calls the method SetObstacle once for every object, setting all values to default
    public void Reboot()
    {
        isRepair = false;
        gameObject.GetComponent<SphereCollider>().enabled = true;
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        distance = DEFAULT_DISTANCE;
        SetObstacle();
    }

    void Update()
    {
        if (!isRepair)
        {
            var x = position + distance*Mathf.Sin(Time.time * speed);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
        else
        {
            // If the object is a wrench we give it a rotation effect
            transform.Rotate (0,50*Time.deltaTime,0); //rotates 50 degrees per second around z axis
        }

    }

    void OnTriggerEnter(Collider other) 
    {
        if (!isRepair)
        {
            // If it has a collider and it's not a wrench it's an UFO, then the user recives damage
            player.losePoint();
            crash.Play();
            Instantiate(crashParticles, transform.position, Quaternion.identity);
        }
        else
        {
            // If the player doesn't have max health the player recives one health point
            if (player.life < player.maxLife){
                player.gainPoint();
                repair.Play();
            }
        }

    }
}
