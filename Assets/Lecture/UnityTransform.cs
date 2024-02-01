using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTransform : MonoBehaviour
{
	/************************************************************************
	 * Ʈ������ (Transform)
	 * 
	 * ���ӿ�����Ʈ�� ��ġ, ȸ��, ũ�⸦ �����ϴ� ������Ʈ
	 * ���ӿ�����Ʈ�� �θ�-�ڽ� ���¸� �����ϴ� ������Ʈ
	 * ���ӿ�����Ʈ�� �ݵ�� �ϳ��� Ʈ������ ������Ʈ�� ������ ������ �߰� & ������ �� ����
	 ************************************************************************/

	public Transform thisTransform;
    float moveSpeed = 3;
    float rotateSpeed = 90;

    // <Ʈ������ ����>
    private void TransformReference()
    {
        thisTransform = transform;		// transform�� �ڵ����� �ش� ������Ʈ�� transform�� �ҷ��´�
    }

    // <Ʈ������ �̵�>
    // Translate : Ʈ�������� �̵� �Լ�
    private void TranslateMove()
    {
        // ���͸� �̿��� �̵�
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        // x,y,z�� �̿��� �̵�
        transform.Translate(0, 0, moveSpeed * Time.deltaTime );
        // position�� �̿��� �̵�
        transform.position += new Vector3(1, 0, 0);        
    }
    // <Ʈ������ �̵� ����>
    private void TransformMoveSpace()
    {
        // ���带 �������� �̵�
        transform.Translate(1, 0, 0, Space.World);
        // ������ �������� �̵�
        transform.Translate(1, 0, 0, Space.Self);
        // �ٸ� ����� �������� �̵�
        transform.Translate(1, 0, 0, Camera.main.transform);
    }


    // <Ʈ������ ȸ��>
    // Rotate : Ʈ�������� ȸ�� �Լ�
    private void Rotate()
    {
        // ���� �̿��� ȸ�� (���� �������� �ð�������� ȸ��)
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        // ���Ϸ��� �̿��� ȸ��
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        // x,y,z�� �̿��� ȸ��
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }

    // <Ʈ������ ȸ�� ����>
    private void RotateSpace()
    {
        // ���带 �������� ȸ��
        transform.Rotate(1, 0, 0, Space.World);
        // ������ �������� ȸ��
        transform.Rotate(1, 0, 0, Space.Self);
        // ��ġ�� �������� ȸ��
        transform.RotateAround(Camera.main.transform.position, Vector3.up, 1);
    }

    // <Ʈ������ LookAt ȸ��>
    // LookAt : ��ġ�� �ٶ󺸴� �������� ȸ��
    private void LookAt()
    {
        // ��ġ�� �ٶ󺸴� ȸ��
        transform.LookAt(new Vector3(0, 0, 0));
        // �Ӹ��� ������ �߰��� �ٶ󺸴� ȸ��
        transform.LookAt(new Vector3(0, 0, 0), Vector3.right);
    }

    // <Ʈ������ ��>
    private void Axis()
    {
        // Ʈ�������� x��
        Vector3 right = transform.right;
        // Ʈ�������� y��
        Vector3 up = transform.up;
        // Ʈ�������� z��
        Vector3 forward = transform.forward;
    }


    // <Ʈ������ �θ�-�ڽ� ����>
    // Ʈ�������� �θ� Ʈ�������� ���� �� ����
    // �θ� Ʈ�������� �ִ� ��� �θ� Ʈ�������� ��ġ, ȸ��, ũ�� ������ ���� �����
    // �̸� �̿��Ͽ� ������ ������ �����ϴµ� ������ (ex. ���� �����̸�, �հ����� ���� ������)
    // ���̾��Ű â �󿡼� �巡�� & ����� ���� �θ�-�ڽ� ���¸� ������ �� ����
    private void TransformParent()
    {
        GameObject newGameObject = new GameObject() { name = "NewGameObject" };

        // �θ� ����
        transform.parent = newGameObject.transform;

        // �θ� ���������� Ʈ������
        // transform.localPosition	: �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ��ġ
        // transform.localRotation	: �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ȸ��
        // transform.localScale		: �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ũ��

        // �θ� ����
        transform.parent = null;

        // ���带 ���������� Ʈ������
        // transform.localPosition == transform.position	: �θ�Ʈ�������� ���� ��� ���带 �������� �� ��ġ
        // transform.localRotation == transform.rotation	: �θ�Ʈ�������� ���� ��� ���带 �������� �� ȸ��
        // transform.localScale								: �θ�Ʈ�������� ���� ��� ���带 �������� �� ũ��
    }



    // <Quarternion(���ʹϾ�) & Euler(���Ϸ�)>
    // Quarternion	: ����Ƽ�� ���ӿ�����Ʈ�� 3���� ������ �����ϰ� �̸� ���⿡�� �ٸ� ���������� ��� ȸ������ ����
    //				  �������� ȸ������ ������ ������ �߻����� ����
    // EulerAngle	: 3���� �������� ���������� ȸ����Ű�� ���
    //				  ������������ ������ ������ �߻��Ͽ� ȸ���� ��ġ�� ���� ���� �� ����
    // ������		: ���� �������� ������Ʈ�� �� ȸ�� ���� ��ġ�� ����

    // Quarternion�� ���� ȸ�������� ����ϴ� ���� ���������� �ʰ� �����ϱ� �����
    // ������ ��� ���ʹϾ� -> ���Ϸ����� -> �������� -> ������Ϸ����� -> ������ʹϾ� �� ���� ������ ��� ���ʹϾ��� �����
    private void Rotation()
    {
        // Ʈ�������� ȸ������ Euler���� ǥ���� �ƴ� Quaternion�� �����
        transform.rotation = Quaternion.identity;

        // Euler������ Quaternion���� ��ȯ
        transform.rotation = Quaternion.Euler(0, 90, 0);

        // ���ʹϾ��� ���Ϸ��� ��ȯ
        Vector3 rotation = transform.rotation.eulerAngles;
    }


    private void Update()
    {
        
    }
}