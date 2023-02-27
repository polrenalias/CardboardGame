using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject playerGameObject;
    public Player player;
    public UIManager ui;
    public RebootAllObstacles obstacles;

    void OnTriggerEnter(Collider other) 
    {
        playerGameObject.transform.position = new Vector3(playerGameObject.transform.position.x, teleportTarget.transform.position.y,  teleportTarget.transform.position.z);
        player.points += 100;
        ui.score.text = "Score: " + player.points.ToString();
        obstacles.RebootAll();
    }
}
