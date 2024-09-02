using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // 자신 클래스 안에 자신을 명명할수 있는 객체를 선언
    public static GameManager Inst => instance; // 외부에서 GamaManger를 사용하기 위해 선언

    private void Awake()
    {
        #region _싱글톤_
        // --------------------------------- 싱글톤 작성(씬에 하나만 존재)
        if (instance && instance != this) // 만약 씬에 있는 GameManager객체가 있는데 자기 자신이 아닌 경우 (씬에 둘이 이상이 있는 경우)
        {
            Destroy(gameObject); // 자기 자신을 지운다.
            return;
        }
        else // 씬에 하나만 있다면
        {
            instance = this; // 그 대상을 GameManager의 객체로 지정하고
            DontDestroyOnLoad(gameObject); // 파괴되지 않도록 지정.
        }
        // --------------------------------- 
        #endregion

    }


    #region _Manager들 참조구간_
    private GameObject obj;

    private UIManager uiManager;
    public UIManager UI_Manager
    {
        get
        {
            if(uiManager == null)
            {
                obj = GameObject.FindObjectOfType<UIManager>().gameObject;
                if (!obj.TryGetComponent<UIManager>(out uiManager))
                    Debug.Log("GameManager.cs에서 UIManager참조 실패");
            }
            return uiManager;
        }
    }


    #endregion

}
