using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // �������� ȹ���ϴ� ���
    // ������ ȹ�� �α׸� ��������ְ� �������� ���������
    // ���� �ε����� �ʰ� �������� �Ѵ�


    /* �÷��̾� �±׶� �浹�ÿ� ������ȹ���� ���� �����ۿ�����Ʈ�� ���ִ� �ڵ�
        �ٵ� �Ʒ��� ���� �ڵ�� �����۰� �浹�� �ϰ� �ȴ�
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("������ ȹ��");
            Destroy(gameObject);
        }
    }
    */

    // Collider���� Ʈ���Ÿ� ���ְ� �Ʒ��� ���� �����Ѵ�
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("������ ȹ��");
            Destroy(gameObject);
        }
    }
}
