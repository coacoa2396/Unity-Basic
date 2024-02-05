using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Mover : MonoBehaviour
{
    public Rigidbody TargetRigid;         // ī�޶� ����ٴ� Ÿ��

    public float offsetX;             // ī�޶��� x��ǥ
    public float offsetY;             // ī�޶��� y��ǥ
    public float offsetZ;             // ī�޶��� z��ǥ

    public float CameraSpeed;         // ī�޶��� �ӵ�
    Vector3 TargetPos;                // Ÿ���� ��ġ

    // Update is called once per frame
    void FixedUpdate()
    {
        // Ÿ���� x, y, z ��ǥ�� ī�޶��� ��ǥ�� ���Ͽ� ī�޶��� ��ġ�� ����
        TargetPos = new Vector3(
            TargetRigid.transform.position.x + offsetX,
            TargetRigid.transform.position.y + offsetY,
            TargetRigid.transform.position.z + offsetZ
            );

        // ī�޶��� �������� �ε巴�� �ϴ� �Լ�(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);

    }
}

