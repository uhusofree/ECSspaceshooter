using Unity.Collections;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Entities;


public class OrbitSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float dT = Time.DeltaTime;

        var jobHandle = Entities.WithName("OrbitSystem")
            .ForEach((ref PhysicsVelocity physics, ref Translation pos, ref Rotation rot, ref OrbitData orbitData) =>
            {
                rot.Value = math.mul(rot.Value, quaternion.RotateX(math.radians(orbitData.speed * dT)));

            }).Schedule(inputDeps);

        jobHandle.Complete();
        return jobHandle;
    }
}
