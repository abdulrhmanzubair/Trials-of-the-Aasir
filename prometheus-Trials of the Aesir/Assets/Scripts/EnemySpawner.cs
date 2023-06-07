using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject EnemyPrefab;
    public GameObject Enemy2;
    public GameObject EnemyPrefab2;
    public GameObject Enemy3;
    public GameObject EnemyPrefab3;
    public GameObject SpawnLocation;

    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            //Enemy already exists, so just move it to the spawn location and set the Enemy gameobject parameter
            Enemy = GameObject.FindGameObjectWithTag("Enemy");
            Enemy.transform.position = SpawnLocation.transform.position;

        }
        else
        {
            //instantiate the Enemy
            Enemy = Instantiate(EnemyPrefab);
            Enemy.transform.position = SpawnLocation.transform.position;
        }


    }
}