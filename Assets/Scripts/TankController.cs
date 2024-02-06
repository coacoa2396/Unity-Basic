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
        if (rigid.velocity.magnitude > maxSpeed)                // 최고속도 제한방법 velocity : 속도, magnitude : 크기
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
        shootSound.Play();      // 효과음의 경우 오디오소스 컴포넌트를 만들어서 플레이함수를 해준다
        animator.SetTrigger("Fire");    // 애니메이터로 연결하기
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
            Debug.Log("차징중입니다");
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
