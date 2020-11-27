using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringFOV : MonoBehaviour
{
    [SerializeField] private float speedHoriz = 2.0f;
    [SerializeField] private float speedVerti = 2.0f;

    [SerializeField] private float pitch = 0.0f;
    [SerializeField] private float yaw = 0.0f;


    private void Update()
    {
        yaw += speedHoriz * Input.GetAxis("Mouse X") * Time.deltaTime;
        pitch += speedVerti * Input.GetAxis("Mouse Y") * Time.deltaTime;

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
