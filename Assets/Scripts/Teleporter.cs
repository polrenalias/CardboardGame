using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject player;

    void OnTriggerEnter(Collider other) 
    {
        player.transform.position = new Vector3(player.transform.position.x, teleportTarget.transform.position.y,  teleportTarget.transform.position.z);
    }
}
