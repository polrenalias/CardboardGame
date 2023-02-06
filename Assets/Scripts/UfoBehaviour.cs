using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class UfoBehaviour : MonoBehaviour
{
    float position;
    float speed = 4f;
    float distance = -7f;    

    public Player player;

    public AudioSource crash;
    public AudioSource repair;

    public GameObject crashParticles;

    bool isRepair = false;

    void Start()
    {
        SetObstacle();
    }

    void SetObstacle()
    {
        position = transform.position.x; // TODO: Check this variable, obstacles move every teleport
        if (UnityEngine.Random.Range(0,3) == 0)
        {
            if (UnityEngine.Random.Range(0,2) == 0) 
            {
                distance = Math.Abs(distance);
            }
        }
        else
        {
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            if (UnityEngine.Random.Range(0,10) == 0)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                isRepair = true;
            }
            else
            {
                gameObject.GetComponent<SphereCollider>().enabled = false;
            }

        }  
    }

    public void Reboot()
    {
        isRepair = false;
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
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
