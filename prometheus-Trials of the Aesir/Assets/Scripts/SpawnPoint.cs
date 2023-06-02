using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] public GameObject spawn;

    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = spawn.transform.position;
    }
    
}
        
    
