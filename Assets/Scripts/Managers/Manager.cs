using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // ����Ƽ���� �̱������� ����ϴ� ����

    public static Manager instance;
    [SerializeField] GameManager gameManager;
    [SerializeField] DataManager dataManager;


    public static Manager GetInstance() {  return instance; }
    public static GameManager Game { get { return instance.gameManager; } }
    public static DataManager Data { get { return instance.dataManager; } }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Singleton already exist");
            Destroy(this);              // �̹� �ν��Ͻ��� �����ߴٸ� �ڱ��ڽ� ������Ʈ�� �����ش�

            return;
        }

        instance = this;
        DontDestroyOnLoad(this);        // ���� ��ȯ�Ǿ �� �Ŵ����� ��������ʴ´�
                                        // �� ��쿡�� Ÿ��Ʋ������ ������� �Ŵ����� ���Ӿ� �Ŵ������� ���� �����Ǿ��� ������
                                        // ���Ӿ��� �Ŵ����� ������Ʈ�� ������� Ÿ��Ʋ�� �Ŵ����� �����Ǹ鼭 ������ �ϰ� �ȴ�
    }   
}
