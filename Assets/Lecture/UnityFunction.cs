using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityFunction : MonoBehaviour
{
    [Header("This")]
    public GameObject thisGameObject;
    public string thisName;
    public bool thisActive;
    public string thisTag;
    public int thisLayer;

    [Header("GameObject")]
    public GameObject newGameObject;
    public GameObject destroyGameObject;
    public GameObject findWithName;
    public GameObject findWithTag;

    [Header("Component")]
    public Component addComponent;
    public Component destroyComponent;
    public Component getComponent;
    public Component findComponent;


    private void Start()
    {
        ThisFunction();
        GameObjectFunction();
        ComponentFunction();
    }
    private void ThisFunction()
    {
        // <현재 게임오브젝트 참조>
        // 컴포넌트가 붙어있는 게임오브젝트는 Component에 구현한 gameObject 속성을 이용하여 접근가능
        thisGameObject = gameObject;        // 컴포넌트가 붙어있는 게임오브젝트
        thisName = gameObject.name;         // 게임오브젝트 이름
        thisActive = gameObject.activeSelf; // 게임오브젝트의 활성화 여부 (activeInHierarchy : 게임씬에서
        thisTag = gameObject.tag;           // 게임오브젝트의 태그
        thisLayer = gameObject.layer;       // 게임오브젝트의 레이어
    }

    private void GameObjectFunction()
    {
        // <게임오브젝트 생성>
        newGameObject = new GameObject("NewGameObject");

        // <게임오브젝트 삭제>
        if (destroyGameObject != null)          // 삭제 전에 null체크 필수
        {
            Destroy(destroyGameObject, 3f);     // 3초 뒤에 삭제를 예약할 수 있다(지연삭제)
        }

        // <게임오브젝트 탐색>
        findWithName = GameObject.Find("MainCamera");       // 이름으로 찾기(잘안씀)
        findWithTag = GameObject.FindWithTag("MainCamera"); // 태그로 찾기
    }

    private void ComponentFunction()
    {
        // <컴포넌트 추가>
        addComponent = gameObject.AddComponent<Rigidbody>();

        // newComponent = new Rigidbody();  // 의미없음, 컴포넌트는 게임오브젝트에 부착되어 동작할 때 의미있음

        // <컴포넌트 삭제>
        if (destroyComponent != null)
            Destroy(destroyComponent);              // Destroy() 함수를 사용한다, 지연삭제도 가능하다

        // <컴포넌트 탐색 - 게임오브젝트에서 찾기>
        getComponent = gameObject.GetComponent<Collider>(); // 해당 게임오브젝트 안에서 컴포넌트를 찾는다
        

        // <컴포넌트 탐색 - 씬에서 찾기>
        findComponent = Component.FindObjectOfType<Camera>();   // 해당 씬 전체에서 컴포넌트를 찾는다
    }
}
