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
    public GameObject SpawnLocation2;

    void start()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            //Enemy already exists, so just move it to the spawn location and set the Enemy gameobject parameter
            Enemy = GameObject.FindGameObjectWithTag("Enemy");
            EnemyPrefab = GameObject.FindGameObjectWithTag("Enemy");
            Enemy2 = GameObject.FindGameObjectWithTag("Enemy2");
            EnemyPrefab2 = GameObject.FindGameObjectWithTag("Enemy2");
            Enemy.transform.position = SpawnLocation.transform.position;
            EnemyPrefab.SetActive(true);
            EnemyPrefab2.SetActive(true);
            Enemy.SetActive(true);
            Enemy2.SetActive(true);

        }
        else
        {
            //instantiate the Enemy
            Enemy = Instantiate(EnemyPrefab);
            Enemy2 = Instantiate(EnemyPrefab2);
            Enemy.transform.position = SpawnLocation.transform.position;
            Enemy2.transform.position = SpawnLocation2.transform.position;

        }


    }
}