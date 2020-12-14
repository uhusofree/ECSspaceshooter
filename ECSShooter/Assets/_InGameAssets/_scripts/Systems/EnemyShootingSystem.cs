using System.Collections;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Collections;

public class EnemyShootingSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        NativeArray<float3> launcherPositions = new NativeArray<float3>(GameManagers.instance.launcherPositions, Allocator.TempJob);
        float3 playerPos = GameManagers.GetPlayerPosition();
        EntityManager em = this.EntityManager;

        Entities.WithoutBurst().WithStructuralChanges().ForEach((Entity entity, ref Translation pos, ref Rotation rot, ref EnemyData eData) =>
        {
            //foreach (float3 launcherPos in launcherPositions)
            //{
                var laserInstance = em.Instantiate(eData.enemyLaser);
                em.SetComponentData(laserInstance, new Translation { Value = pos.Value/* + math.mul(rot.Value, launcherPos)*/ });
                em.SetComponentData(laserInstance, new Rotation { Value = rot.Value });
            //}

        }).Run();

        launcherPositions.Dispose();
        return inputDeps;
    }


}
