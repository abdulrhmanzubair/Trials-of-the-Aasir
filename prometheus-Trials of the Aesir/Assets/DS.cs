using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DS : MonoBehaviour
{
    private static bool EventSystemExists;
    // Start is called before the first frame update
    void Start()
    {
        if (!EventSystemExists)
        {
            EventSystemExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
