using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour   // Cinemachine�� ����ϸ� �� �ִ� ���
{
    public Transform follow;
    public Vector3 offset;
    
    public void LateUpdate()           // ī�޶�� LateUpdate��� �����ϸ� �ȴ�
    {
        transform.position = follow.position + offset;
        transform.LookAt(follow.position);
    }
}
