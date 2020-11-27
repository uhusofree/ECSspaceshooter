using Unity.Collections;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Entities;


public class LaserPropulsionSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float dT = Time.DeltaTime;

        var jobHandle = Entities.WithName("LaserPropulsionSystem")
            .ForEach((ref PhysicsVelocity physics, ref Translation pos, ref Rotation rot, ref LaserPropulsionData laserPropulsionData) =>
        {
            physics.Angular = float3.zero;
            physics.Linear += dT * laserPropulsionData.speed * math.forward(rot.Value);

        }).Schedule(inputDeps);

        jobHandle.Complete();
        return jobHandle;
    }
}
