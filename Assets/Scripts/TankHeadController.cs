using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeadController : MonoBehaviour
{
    public Transform turretTransform;
    public float rotateSpeed;

    private Vector3 rot;    // ���Ϸ�
    public float maxXrot;   // ���Ϸ�
    public float minXrot;   // ���Ϸ�
    public float maxYrot;   // ���Ϸ�
    public float minYrot;   // ���Ϸ�


    private Vector3 headDir;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        turretTransform.Rotate(Vector3.up, headDir.x * rotateSpeed * Time.deltaTime, Space.World);
        turretTransform.Rotate(Vector3.right, headDir.z * rotateSpeed * Time.deltaTime, Space.Self);

        /*
        // ȸ���� ����
        rot = turretTransform.rotation.eulerAngles; // ���Ϸ�
        if (rot.x >= maxXrot || rot.x <= minXrot || rot.y >= maxYrot || rot.y <= minYrot)
        {
            //rot.x = Mathf.Clamp(rot.x, maxXrot, minXrot);
            //rot.y = Mathf.Clamp(rot.y, maxYrot, minYrot);
            if (rot.x >= maxXrot)
            {
                rot.x = maxXrot;
            }
            else if (rot.x <= minXrot)
            {
                rot.x = minXrot;
            }
            if (rot.y >= maxYrot)
            {
                rot.y = maxYrot;
            }
            else if (rot.y <= minYrot)
            {
                rot.y = minYrot;
            }
            turretTransform.rotation = Quaternion.Euler(rot);
        }
        */
    }

    private void OnHead(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();
        headDir.x = inputDir.x;
        headDir.z = inputDir.y;
    }
}
