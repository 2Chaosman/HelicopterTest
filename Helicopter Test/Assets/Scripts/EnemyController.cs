using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoSingleton<EnemyController>
{
    [SerializeField] private GameObject missilePrefab;
    private Transform playerMissile;

    private void Start()
    {
        
    }

    private void Update()
    {
        playerMissile = GameObject.Find("PlayerMissile").GetComponent<Transform>();
    }

    private void FireAtPlayersMissile()
    {
        GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);

    }

}


