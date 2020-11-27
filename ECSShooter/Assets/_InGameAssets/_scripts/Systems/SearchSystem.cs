using System.Collections;
using Unity.Transforms;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;


public class SearchSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float dT = Time.DeltaTime;
        float3 targetPos = (float3)GameManagers.GetPlayerPosition();

        var jobHandle = Entities.WithName("SearchSystem").ForEach((ref PhysicsVelocity phys, ref Translation trans, ref Rotation rot, ref MovementData mData) =>
            {
               
                float3 dir = targetPos - trans.Value;
                rot.Value = quaternion.LookRotation(dir, math.up());
               
            }).Schedule(inputDeps);

        return jobHandle;
    }
}
