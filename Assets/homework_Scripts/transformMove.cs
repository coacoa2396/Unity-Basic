using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformMove : MonoBehaviour
{
    [SerializeField] Transform transform;
    [SerializeField] float movespeed;

    private void Start()
    {
        
    }

    private void Update()
    {
        
        Vector3 position = transform.position;
        if(Input.GetKey(KeyCode.W))
        {
            position.z += movespeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S))
        {
            position.z -= movespeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            position.x -= movespeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.x += movespeed * Time.deltaTime;
        }
        
        transform.position = position;
    }
}
