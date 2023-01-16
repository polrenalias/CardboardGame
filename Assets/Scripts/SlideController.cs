using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideController : MonoBehaviour
{
    private Rigidbody rb;
    // Speed of the slide
    public float slideSpeed = 10.0f;
    // Force aplied to the character to make the character slide
    public float slideForce = 100.0f;
    // Angle to slide
    public float slideAngle = 45.0f;
    public LayerMask slideLayer;
    private bool isSliding = false;

    public bool isAllowedToSlide = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (IsCollidingWithSlide())
        {
            Vector3 normal = CalculateSlideNormal();
            if ((Vector3.Angle(normal, Vector3.up) >= slideAngle) && isAllowedToSlide)
            {
                isSliding = true;
                Vector3 slideDirection = Vector3.Cross(normal, Vector3.right);
                rb.AddForce(slideDirection * slideForce, ForceMode.Acceleration);
            }
            else
            {
                isSliding = false;
            }
        }
        else
        {
            isSliding = false;
        }
    }

    bool IsCollidingWithSlide()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 0.5f, Vector3.down, out hit, 1.0f, slideLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    Vector3 CalculateSlideNormal()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 0.5f, Vector3.down, out hit, 1.0f, slideLayer))
        {
            return hit.normal;
        }
        else
        {
            return Vector3.up;
        }
    }

    void FixedUpdate()
    {
        if (isSliding)
        {
            rb.velocity = transform.forward * slideSpeed;
        }
    }
}
