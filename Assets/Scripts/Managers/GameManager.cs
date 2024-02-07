using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public Button Button;             // 이 경우 유니티 컴포넌트 창에서 참조를 할 때 씬에 있는
                                        // 오브젝트를 사용하면 안된다

    public void GamePause()
    {
        Time.timeScale = 0;
    }

    public void GameResume()
    {
        Time.timeScale = 1;
    }
}
