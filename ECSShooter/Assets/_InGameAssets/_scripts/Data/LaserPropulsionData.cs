using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct LaserPropulsionData : IComponentData
{
    public float speed;
}
