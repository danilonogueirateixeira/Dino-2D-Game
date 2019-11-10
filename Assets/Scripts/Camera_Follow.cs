using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{   
    public Transform playerTransform;
    public float offset;

    
    void FixedUpdate(){
                playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 temp = transform.position;

        temp.x = playerTransform.position.x;

        temp.x += offset;

        transform.position = temp;
    }
}
