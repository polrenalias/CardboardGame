using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    float position;
    float speed = 4f;
    float distance = 7f;    

    void Start()
    {
        position = transform.position.x;
    }

    void Update()
    {
        var x = position + distance*Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
