using Unity.Collections;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Entities;

public class EnemyMovementSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float dT = Time.DeltaTime;

        var jobHandle = Entities.WithName("MovementData").ForEach(( ref PhysicsVelocity physics, ref Translation trans, ref Rotation rot, ref MovementData mData) =>
        {
            physics.Angular = float3.zero;
            physics.Linear = dT * mData.speed * math.forward(rot.Value);
         
            //if (!canStoptoAttack)
            //{
            //    physics.Linear = dT * mData.speed * math.forward(rot.Value);
            //}
            //else return;

        }).Schedule(inputDeps);

        return jobHandle;
    }
}
