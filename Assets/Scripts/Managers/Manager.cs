using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // 유니티에서 싱글톤패턴 사용하는 예시

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
            Destroy(this);              // 이미 인스턴스가 존재했다면 자기자신 컴포넌트를 지워준다

            return;
        }

        instance = this;
        DontDestroyOnLoad(this);        // 씬이 전환되어도 이 매니저가 사라지지않는다
                                        // 이 경우에는 타이틀씬에서 만들어진 매니저가 게임씬 매니저보다 먼저 생성되었기 때문에
                                        // 게임씬의 매니저는 컴포넌트가 사라지고 타이틀씬 매니저가 유지되면서 관리를 하게 된다
    }   
}
