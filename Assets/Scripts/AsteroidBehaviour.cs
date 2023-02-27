using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AsteroidBehaviour : MonoBehaviour
{
    Rigidbody rb;
    public float initialForce = 10f;
    public float initialTorque = 10f;

    private void Awake()
    {
        float randomScale = Random.Range(1f, 3f);
        transform.localScale = Vector3.one * randomScale;
        
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce(Vector3.forward * initialForce);
        rb.AddTorque(Vector3. forward * initialTorque);
    }
}
