using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // 아이템을 획득하는 경우
    // 아이템 획득 로그를 재생시켜주고 아이템은 사라져야함
    // 또한 부딪히지 않고 지나가야 한다


    /* 플레이어 태그랑 충돌시에 아이템획득을 띄우고 아이템오브젝트를 없애는 코드
        근데 아래와 같은 코드면 아이템과 충돌을 하게 된다
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("아이템 획득");
            Destroy(gameObject);
        }
    }
    */

    // Collider에서 트리거를 켜주고 아래와 같이 설정한다
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("아이템 획득");
            Destroy(gameObject);
        }
    }
}
