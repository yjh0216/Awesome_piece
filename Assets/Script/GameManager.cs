using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // �ڽ� Ŭ���� �ȿ� �ڽ��� ����Ҽ� �ִ� ��ü�� ����
    public static GameManager Inst => instance; // �ܺο��� GamaManger�� ����ϱ� ���� ����

    private void Awake()
    {
        #region _�̱���_
        // --------------------------------- �̱��� �ۼ�(���� �ϳ��� ����)
        if (instance && instance != this) // ���� ���� �ִ� GameManager��ü�� �ִµ� �ڱ� �ڽ��� �ƴ� ��� (���� ���� �̻��� �ִ� ���)
        {
            Destroy(gameObject); // �ڱ� �ڽ��� �����.
            return;
        }
        else // ���� �ϳ��� �ִٸ�
        {
            instance = this; // �� ����� GameManager�� ��ü�� �����ϰ�
            DontDestroyOnLoad(gameObject); // �ı����� �ʵ��� ����.
        }
        // --------------------------------- 
        #endregion

    }


    #region _Manager�� ��������_
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
                    Debug.Log("GameManager.cs���� UIManager���� ����");
            }
            return uiManager;
        }
    }


    #endregion

}
