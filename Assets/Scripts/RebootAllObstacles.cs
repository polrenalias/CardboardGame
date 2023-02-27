using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebootAllObstacles : MonoBehaviour
{
    public List<GameObject> obstacles = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            obstacles.Add(child.gameObject);
        }
    }

    public void RebootAll()
    {
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.GetComponent<UfoBehaviour>().Reboot();
        }
    }
}
