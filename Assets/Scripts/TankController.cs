using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TankController : MonoBehaviour
{
    public Transform firePoint;
    public Bullet bulletPrefab;
    private Coroutine routine;
    public Rigidbody rigid;
    
    public float movepower;
    public float rotateSpeed;
    public float chargingPower;
    private Vector3 moveDir;
    public float maxSpeed;

    public CinemachineVirtualCamera normalCamera;
    public CinemachineVirtualCamera zoomCamera;

    public AudioSource shootSound;

    public Animator animator;
    private void Update()
    {
        Rotate();
    }
    private void FixedUpdate()
    {
        Move();
        
    }

    private void Move()
    {
        //transform.Translate(0, 0, moveDir.z * moveSpeed * Time.deltaTime, Space.Self);
        
        Vector3 forceDir = transform.forward * moveDir.z;
        rigid.AddForce(forceDir*movepower, ForceMode.Force);
        if (rigid.velocity.magnitude > maxSpeed)                // �ְ�ӵ� ���ѹ�� velocity : �ӵ�, magnitude : ũ��
        {
            rigid.velocity = rigid.velocity.normalized * maxSpeed;
        }
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, moveDir.x * rotateSpeed * Time.deltaTime, Space.World);
    }

    public void Fire()
    {
        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.force = bullet.force * chargingPower;
        chargingPower = 0;
        shootSound.Play();      // ȿ������ ��� ������ҽ� ������Ʈ�� ���� �÷����Լ��� ���ش�
        animator.SetTrigger("Fire");    // �ִϸ����ͷ� �����ϱ�
    }
    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveDir.x = input.x;
        moveDir.z = input.y;
    }

    private void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            StartCoroutine();
        }
        else
        {
            StopCoroutine();
            Fire();
        }
    }

    void StartCoroutine()
    {
        routine = StartCoroutine(SubRoutine());
    }

    void StopCoroutine()
    {
        StopCoroutine(routine);
    }
    IEnumerator SubRoutine()
    {
        while (true)
        {
            chargingPower += 0.1f;
            Debug.Log("��¡���Դϴ�");
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnZoom(InputValue value)
    {
        if(value.isPressed)
        {
            Debug.Log("Zoom on");
            zoomCamera.Priority = 50;
        }
        else
        {
            Debug.Log("Zoom off");
            zoomCamera.Priority = 1;
        }
    }
}
