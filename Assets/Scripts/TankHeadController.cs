using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeadController : MonoBehaviour
{
    public Transform turretTransform;
    public float rotateSpeed;

    private Vector3 headDir;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        turretTransform.Rotate(Vector3.up, headDir.x * rotateSpeed * Time.deltaTime, Space.World);
        turretTransform.Rotate(Vector3.right, headDir.z * rotateSpeed * Time.deltaTime, Space.Self);
    }

    private void OnHead(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();
        headDir.x = inputDir.x;
        headDir.z = inputDir.y;
    }
}
