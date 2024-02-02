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
        // <���� ���ӿ�����Ʈ ����>
        // ������Ʈ�� �پ��ִ� ���ӿ�����Ʈ�� Component�� ������ gameObject �Ӽ��� �̿��Ͽ� ���ٰ���
        thisGameObject = gameObject;        // ������Ʈ�� �پ��ִ� ���ӿ�����Ʈ
        thisName = gameObject.name;         // ���ӿ�����Ʈ �̸�
        thisActive = gameObject.activeSelf; // ���ӿ�����Ʈ�� Ȱ��ȭ ���� (activeInHierarchy : ���Ӿ�����
        thisTag = gameObject.tag;           // ���ӿ�����Ʈ�� �±�
        thisLayer = gameObject.layer;       // ���ӿ�����Ʈ�� ���̾�
    }

    private void GameObjectFunction()
    {
        // <���ӿ�����Ʈ ����>
        newGameObject = new GameObject("NewGameObject");

        // <���ӿ�����Ʈ ����>
        if (destroyGameObject != null)          // ���� ���� nullüũ �ʼ�
        {
            Destroy(destroyGameObject, 3f);     // 3�� �ڿ� ������ ������ �� �ִ�(��������)
        }

        // <���ӿ�����Ʈ Ž��>
        findWithName = GameObject.Find("MainCamera");       // �̸����� ã��(�߾Ⱦ�)
        findWithTag = GameObject.FindWithTag("MainCamera"); // �±׷� ã��
    }

    private void ComponentFunction()
    {
        // <������Ʈ �߰�>
        addComponent = gameObject.AddComponent<Rigidbody>();

        // newComponent = new Rigidbody();  // �ǹ̾���, ������Ʈ�� ���ӿ�����Ʈ�� �����Ǿ� ������ �� �ǹ�����

        // <������Ʈ ����>
        if (destroyComponent != null)
            Destroy(destroyComponent);              // Destroy() �Լ��� ����Ѵ�, ���������� �����ϴ�

        // <������Ʈ Ž�� - ���ӿ�����Ʈ���� ã��>
        getComponent = gameObject.GetComponent<Collider>(); // �ش� ���ӿ�����Ʈ �ȿ��� ������Ʈ�� ã�´�
        

        // <������Ʈ Ž�� - ������ ã��>
        findComponent = Component.FindObjectOfType<Camera>();   // �ش� �� ��ü���� ������Ʈ�� ã�´�
    }
}
