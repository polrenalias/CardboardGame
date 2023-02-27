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
    float distance = -7f;    

    public Player player;

    public AudioSource crash;
    public AudioSource repair;

    public GameObject crashParticles;

    bool isRepair = false;

    void Start()
    {
        originalPosition = transform.position.x;
        SetObstacle();
    }

    void SetObstacle()
    {
        position = originalPosition; // TODO: Check this variable, obstacles move every teleport
        if (UnityEngine.Random.Range(0,2) == 0)
        {
            // Left or right movement
            if (UnityEngine.Random.Range(0,2) == 0) 
            {
                distance = Math.Abs(distance);
            }
        }
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

    public void Reboot()
    {
        isRepair = false;
        gameObject.GetComponent<SphereCollider>().enabled = true;
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        distance = -7f;
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
            transform.Rotate (0,50*Time.deltaTime,0); //rotates 50 degrees per second around z axis
        }

    }

    void OnTriggerEnter(Collider other) 
    {
        if (!isRepair)
        {
            player.losePoint();
            crash.Play();
            Instantiate(crashParticles, transform.position, Quaternion.identity);
        }
        else
        {
            if (player.life < player.maxLife){
                player.gainPoint();
                repair.Play();
            }
        }

    }
}
