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
        //a.GetComponent<ParticleSystem>().Play();      // ��ƼŬ�ý��ۿ��� �ڵ� �÷��̸� ���س��� ��� ����ϴ� ���
        //Destroy(a, 1.1f);                             // ���������� �ڵ������� ���س����� ��� ����ϴ� ���
        Destroy(gameObject);
    }
    private void Start()
    {
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
        if (gameObject != null)
            Destroy(gameObject, 3f);
    }
}
