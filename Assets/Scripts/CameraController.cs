using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour   // Cinemachine을 사용하면 다 있는 기능
{
    public Transform follow;
    public Vector3 offset;
    
    public void LateUpdate()           // 카메라는 LateUpdate라고 생각하면 된다
    {
        transform.position = follow.position + offset;
        transform.LookAt(follow.position);
    }
}
