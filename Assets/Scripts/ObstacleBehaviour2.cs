using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour2 : MonoBehaviour
{
    float position;
    float speed = 4f;
    float distance = 7f;    

    void Start()
    {
        position = transform.position.y;
    }

    void Update()
    {
        var y = position + distance*Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
