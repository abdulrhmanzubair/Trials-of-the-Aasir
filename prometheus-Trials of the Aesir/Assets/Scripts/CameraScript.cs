using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        Vector3 position = transform.position;
        position.x = target.transform.position.x + 5f;
        position.y = target.transform.position.y;
        transform.position = position;
    }
}