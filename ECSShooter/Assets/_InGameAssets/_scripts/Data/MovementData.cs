using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct MovementData : IComponentData
{
    public float speed;
}

