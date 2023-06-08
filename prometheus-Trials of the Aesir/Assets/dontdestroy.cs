using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroy : MonoBehaviour
{
    private static bool Object;
    // Start is called before the first frame update
    void awake()
    {
        if (!Object)
        {
            Object = true;
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
        if (!Object)
        {
            Object = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            
        }
    }
}
