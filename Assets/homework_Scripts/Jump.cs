using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody rigid;
    public float jumpPower;
    public float power;
    public Vector3 jump;
    public bool isGrounded;
    [SerializeField] bool isJumpable;
    public float coolTime;

    void OnCollisionExit()
    {
        isGrounded = false;
    }
    private void OnCollisionEnter()
    {
        isGrounded = true;
    }
    IEnumerator JumpCoolTime()
    {
        isJumpable = false;
        yield return new WaitForSeconds(coolTime);
        isJumpable = true;
    }
    IEnumerator AfterThreeSeconds()      // 3�� �ڿ� ������ �ٴ� �ڷ�ƾ
    {
        yield return new WaitForSeconds(3);
        rigid.AddForce(Vector3.up * power, ForceMode.Impulse);
    }
    IEnumerator OneSecondThreeTimes()        // 1�� �������� 3�� ������ �ٴ� �ڷ�ƾ
    {
        yield return new WaitForSeconds(1);
        rigid.AddForce(Vector3.up * power, ForceMode.Impulse);
        yield return new WaitForSeconds(1);
        rigid.AddForce(Vector3.up * power, ForceMode.Impulse);
        yield return new WaitForSeconds(1);
        rigid.AddForce(Vector3.up * power, ForceMode.Impulse);
    }

    void Start()        // �غ�
    {
        rigid = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()       // ����
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && isJumpable)
        {
            /*Debug.Log("�����մϴ�.");
            rigid.AddForce(Vector3.up * power, ForceMode.Impulse);
            StartCoroutine(JumpCoolTime());*/

            //StartCoroutine(AfterThreeSeconds());
            StartCoroutine(OneSecondThreeTimes());
        }
    }
}

