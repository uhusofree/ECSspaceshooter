using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private LayerMask player;
    public bool hasSeenTarget;

    #region SINGLETON
    public static EnemyManager _instance;

    public static EnemyManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<EnemyManager>();
            }

            return _instance;
        }
    }


    #endregion

    private void Start()
    {
        hasSeenTarget = false;
    }

    public bool SetUpTargeting()
    {
        return hasSeenTarget = Physics.Raycast(transform.position, Vector3.forward, Mathf.Infinity, player);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, Vector3.forward * Mathf.Infinity);
    }
}
