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

    public float moveSpeed;
    public float rotateSpeed;
    public float chargingPower;
    private Vector3 moveDir;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        transform.Translate(0, 0, moveDir.z * moveSpeed * Time.deltaTime, Space.Self);
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, moveDir.x * rotateSpeed * Time.deltaTime, Space.World);
    }

    private void Fire()
    {
        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.force = bullet.force * chargingPower;
        chargingPower = 0;
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
}
