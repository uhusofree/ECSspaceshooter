using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    
    [SerializeField] private float speed = 50;

    private Rigidbody rb;
   
    //add speed multiplier
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 fwd = transform.TransformDirection(transform.forward);
        float fwdSpeed = speed * Time.deltaTime;
        rb.velocity = fwd * fwdSpeed;
        //rb.velocity = new Vector3(0, 0, transform.position.z * -speed * Time.deltaTime);
        //rb.AddForce(0, 0, -transform.position.z + speed * Time.deltaTime);
    }
}
