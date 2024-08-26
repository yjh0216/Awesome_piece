using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // ��ũ���� ����
    [Header("��ũ���� ���õ�")]
    [SerializeField] private GameObject setting_01;
    [SerializeField] private GameObject setting_02;

    // ��ũ�� ó�� �������� �ִ� ��ư��
    [Header("Setting_01�� �ִ� ��ư�� ���� ��")]
    [SerializeField] private Button Scroll_Btn01; // �������� ���� ��ư.
    [SerializeField] private Button Scroll_Btn02;
    [SerializeField] private Button Scroll_Btn03;
    [SerializeField] private Button Scroll_Btn04;
    [SerializeField] private Button Scroll_Btn05;
    [SerializeField] private Button Scroll_Btn06;

    // setting_02�� UI��
    [Header("setting_02�� UI�� ���� ��(PopUp_ui ����)")]
    [SerializeField] private Button Select_Building_Btn;
    [SerializeField] private TextMeshProUGUI Select_Building_Name;
    [SerializeField] private GameObject PopUp_Building_Menu_Obj;
    [SerializeField] private GameObject PopUp_Content;

    //[SerializeField] private Button Main_Tower_slot_Btn;
    //[SerializeField] private Button Tavern_slot_Btn;
    //[SerializeField] private Button Operation_slot_Btn;
    //[SerializeField] private Button Barrack_A_slot_Btn;
    //[SerializeField] private Button Barrack_B_slot_Btn;
    //[SerializeField] private Button Barrack_C_slot_Btn;
    //[SerializeField] private Button Barrack_D_slot_Btn;
    //[SerializeField] private Button Alchemy_slot_Btn;
    //[SerializeField] private Button Sanctuary_slot_Btn;
    //[SerializeField] private Button Magic_Stone_slot_Btn;

    [Header("Popup_ui�� �ִ� �ǹ� ��ư�� �ֱ�")]
    [SerializeField] private List<Button> Build_Type; // �Ǽ��� �ǹ��� ��ưŸ���� ����Ʈ�� �ִ´�.

    [Header("Popup_ui�� �ڷΰ��� ��ư")]
    [SerializeField] private Button Back_Btn;

    private void Start()
    {
        Reset_Scroll(); // ��ũ���� �ʱ�ȭ.

        #region _Button.onClick.AddListener()_
        Scroll_Btn01.onClick.AddListener(Change_Scroll_setting02);
        // todo : ������ ��ư�鵵 ����.
        Select_Building_Btn.onClick.AddListener(Popup_building_Menu_Method);

        for(int i = 0; i < Build_Type.Count; i++)
        {
            Build_Type[i].onClick.AddListener(()=>Select_Build_Set(i));
        }

        // Popup_ui�� �ڷΰ��� ��ư.
        Back_Btn.onClick.AddListener(Popup_at_Back);
        #endregion

    }

    private void Update()
    {
        //Debug.Log();
    }

    public void Reset_Scroll()
    {
        Debug.Log("��ũ�� ���� �ʱ�ȭ. UIManager.cs - Start() - Reset_Scroll()");
        setting_01.SetActive(true);
        setting_02.SetActive(false);
    }

    // ��ũ���� ������ setting_02�� �ٲߴϴ�.
    private void Change_Scroll_setting02()
    {
        if(setting_01.activeSelf)
        {
            setting_01.SetActive(false);
            setting_02.SetActive(true);
        }
        PopUp_Building_Menu_Obj.transform.localScale = Vector3.zero;
    }

    private void Popup_building_Menu_Method()
    {
        PopUp_Building_Menu_Obj.transform.localScale = Vector3.one;
        PopUp_Content.transform.localPosition = new Vector3(0f, -0.1f, 0f);
    }

    private void Popup_at_Back()
    {
        PopUp_Building_Menu_Obj.transform.localScale = Vector3.zero;
    }

    private void Select_Build_Set(int num)
    {
        PopUp_Building_Menu_Obj.transform.localScale = Vector3.zero;
        switch(num)
        {
            case 0:

                break;
            case 1:

                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
            case 5:

                break;
            case 6:

                break;
            case 7:

                break;
            case 8:

                break;
            case 9:

                break;
        }

    }

}
