using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Collections;



public class ECSmanager : MonoBehaviour
{

    

    public static EntityManager manager;
    [Header("Asteroids")]
    public GameObject[] asteroidPrefab;
    [SerializeField] private int asteroidCount = 100;

    [Header("Enemies")]
    public GameObject enemyCraftPrefab;
    [SerializeField] private int enemyCraftCount = 5;
    [SerializeField] private float offset = 5f;

    private Entity enemy;
    private Vector2 bounds;

    [Header("Player Elements")]
    public GameObject laserPrefab;
    public Transform laserOrigin;
    private Entity laser;

    BlobAssetStore store;

    // Start is called before the first frame update
    void Start()
    {
        store = new BlobAssetStore(); manager = World.DefaultGameObjectInjectionWorld.EntityManager;
        GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, store);

        Entity asteroid = GameObjectConversionUtility.ConvertGameObjectHierarchy(asteroidPrefab[0], settings);
        Entity asteroid1 = GameObjectConversionUtility.ConvertGameObjectHierarchy(asteroidPrefab[1], settings);
        Entity asteroid2 = GameObjectConversionUtility.ConvertGameObjectHierarchy(asteroidPrefab[2], settings);

        laser = GameObjectConversionUtility.ConvertGameObjectHierarchy(laserPrefab, settings);

        for (int i = 0; i < asteroidCount; i++)
        {
            Entity instance = manager.Instantiate(asteroid);
            Entity instance1 = manager.Instantiate(asteroid1);
            Entity instance2 = manager.Instantiate(asteroid2);


            float x = UnityEngine.Random.Range(-360, 360);
            float y = UnityEngine.Random.Range(-360, 360);
            float z = UnityEngine.Random.Range(-360, 360);

            float3 pos = new float3(x, y, z);

            float randomSpeed = UnityEngine.Random.Range(1, 10) / 10.0f;

            manager.SetComponentData(instance, new Translation { Value = pos });
            manager.SetComponentData(instance, new OrbitData { speed = randomSpeed });
            manager.SetComponentData(instance1, new Translation { Value = pos });
            manager.SetComponentData(instance1, new OrbitData { speed = randomSpeed });
            manager.SetComponentData(instance2, new Translation { Value = pos });
            manager.SetComponentData(instance2, new OrbitData { speed = randomSpeed });
        }

        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        enemy = GameObjectConversionUtility.ConvertGameObjectHierarchy(enemyCraftPrefab, settings);

        EnemyWaves();

        //manager.Instantiate(enemy);
        //manager.AddComponentData(enemy, new Translation { Value = new float3(enemyXpos, enemyYpos, enemyZpos - 5) });


    }


    // Update is called once per frame
    void Update()
    {
        ShootLaser();
    }

    private void ShootLaser()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var laserInstance = manager.Instantiate(laser);
            Vector3 startPos = laserOrigin.transform.position;
            manager.SetComponentData(laserInstance, new Translation { Value = startPos });
            manager.SetComponentData(laserInstance, new Rotation { Value = laserOrigin.transform.rotation });
        }
    }

    private void EnemyWaves()
    {
        NativeArray<Entity> enemyArray = new NativeArray<Entity>(enemyCraftCount, Allocator.Temp);
        float enemyZpos = laserOrigin.transform.position.z + offset;
        float x = bounds.x / 2;

        for (int i = 0; i < enemyArray.Length; i++)
        {
            float3 randomizePos = new float3(x, 0, enemyZpos);

            enemyArray[i] = manager.Instantiate(enemy);
            manager.SetComponentData(enemyArray[i], new Translation { Value = randomizePos });

            x += 75.0f;
        }

    }

    private void OnDestroy()
    {
        store.Dispose();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(laserOrigin.transform.position, .25f);
    }
}
