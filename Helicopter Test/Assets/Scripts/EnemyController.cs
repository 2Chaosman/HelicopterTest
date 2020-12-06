using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoSingleton<EnemyController>
{

    /*TODO:
        Стрельба по ракетам игрока
        

    */

    [SerializeField] private GameObject missilePrefab;

    private void Start()
    {
        
    }

    private void FireAtPlayersMissile()
    {
        GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);

    }

}


