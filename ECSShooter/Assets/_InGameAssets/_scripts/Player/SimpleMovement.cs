using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    
    [SerializeField] private float speed = 50;
    private float cruiseSpeed = 250;
    const float multiplier = 10;

    private Rigidbody rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            speed = cruiseSpeed;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            speed *= multiplier;
        }

        Vector3 fwd = transform.TransformDirection(transform.forward);
        float fwdSpeed = speed * Time.deltaTime;
        rb.velocity = fwd * fwdSpeed;

    }
}
