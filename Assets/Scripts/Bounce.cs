using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    // Ű�� ������ ������ 1�ʸ��� �ٰ� Ű�� ���� ���̻� ���� �ʴ� �ڷ�ƾ

    public Rigidbody rigid;
    public float power;
    public bool isJumpable = true;

    IEnumerator Bounce()
    {
        rigid.AddForce(Vector3.up * power, ForceMode.Impulse);
        Debug.Log("����!");
        isJumpable = false;
        yield return new WaitForSeconds(1f);
        isJumpable = true;
    }
    void Start()
    {
        
    }
    
    public Coroutine cor;
    public void CoroutineStart()
    {
        cor = StartCoroutine(Bounce());
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isJumpable)
        {
            CoroutineStart();
        }        
    }
}
