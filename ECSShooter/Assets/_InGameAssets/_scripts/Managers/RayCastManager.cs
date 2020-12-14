using System.Collections;
using UnityEngine;
using Unity.Physics;
using Unity.Physics.Systems;
using Unity.Mathematics;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine.Assertions;

public class RayCastManager : MonoBehaviour
{
    public float dist = 10.0f;
    public Vector3 direction = new Vector3(0, 0, 1);

    RaycastInput raycastInput;

    private void LateUpdate()
    {
        float3 origin = this.transform.position;
        float3 rayDirection = (transform.rotation * direction) * dist;

        raycastInput = new RaycastInput
        {
            Start = origin,
            End = origin + rayDirection,
            Filter = CollisionFilter.Default
        };      
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(raycastInput.Start, raycastInput.End - raycastInput.Start);
    }
}
