using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Unity.Collections;

public class GameManagers : MonoBehaviour
{
    private Transform player;
    public float3[] launcherPositions;
    //Attempt at a singleton
    #region SINGLETON
    public static GameManagers _instance;

    public static GameManagers instance
    {
        get 
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManagers>();
            }

            return _instance;
        }
    }

    #endregion
    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<SimpleMovement>().transform;
    }

   public static Vector3 GetPlayerPosition ()
    {
        if (GameManagers.instance == null)
        {
            return Vector3.zero;
        }

        return (instance.player != null) ? GameManagers.instance.player.position : Vector3.zero;
    }

}
