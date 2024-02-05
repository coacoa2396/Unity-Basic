using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float force;
    public GameObject explosionPrefab;
    private void OnCollisionEnter(Collision collision)
    {
        GameObject a = Instantiate(explosionPrefab, transform.position, transform.rotation);
        //a.GetComponent<ParticleSystem>().Play();      // 파티클시스템에서 자동 플레이를 안해놓는 경우 사용하는 방법
        //Destroy(a, 1.1f);                             // 마찬가지로 자동삭제를 안해놓았을 경우 사용하는 방법
        Destroy(gameObject);
    }
    private void Start()
    {
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
        if (gameObject != null)
            Destroy(gameObject, 3f);
    }
}
