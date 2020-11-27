using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct OrbitData : IComponentData
{
    public float speed;
}
