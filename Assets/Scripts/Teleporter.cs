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

    public int POINTS_BY_ROUND = 100;
    // This object is used to return the player to the start of the slide and restart the obstacles
    void OnTriggerEnter(Collider other) 
    {
        playerGameObject.transform.position = new Vector3(playerGameObject.transform.position.x, teleportTarget.transform.position.y,  teleportTarget.transform.position.z);
        player.points += POINTS_BY_ROUND;
        ui.score.text = "Score: " + player.points.ToString();
        obstacles.RebootAll();
    }
}
