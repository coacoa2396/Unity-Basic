using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    // 키를 누르고 있으면 1초마다 뛰고 키를 때면 더이상 뛰지 않는 코루틴

    public Rigidbody rigid;
    public float power;
    public bool isJumpable = true;

    IEnumerator Bounce()
    {
        rigid.AddForce(Vector3.up * power, ForceMode.Impulse);
        Debug.Log("점프!");
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
