using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // 스크롤의 세팅
    [Header("스크롤의 세팅들")]
    [SerializeField] private GameObject setting_01;
    [SerializeField] private GameObject setting_02;

    // 스크롤 처음 열었을때 있는 버튼들
    [Header("Setting_01에 있는 버튼들 넣을 것")]
    [SerializeField] private Button Scroll_Btn01; // 건축으로 들어가는 버튼.
    [SerializeField] private Button Scroll_Btn02;
    [SerializeField] private Button Scroll_Btn03;
    [SerializeField] private Button Scroll_Btn04;
    [SerializeField] private Button Scroll_Btn05;
    [SerializeField] private Button Scroll_Btn06;

    // setting_02의 UI들
    [Header("setting_02의 UI들 넣을 것(PopUp_ui 제외)")]
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

    [Header("Popup_ui에 있는 건물 버튼들 넣기")]
    [SerializeField] private List<Button> Build_Type; // 건설할 건물의 버튼타입을 리스트에 넣는다.

    [Header("Popup_ui의 뒤로가기 버튼")]
    [SerializeField] private Button Back_Btn;

    private void Start()
    {
        Reset_Scroll(); // 스크롤을 초기화.

        #region _Button.onClick.AddListener()_
        Scroll_Btn01.onClick.AddListener(Change_Scroll_setting02);
        // todo : 나머지 버튼들도 예정.
        Select_Building_Btn.onClick.AddListener(Popup_building_Menu_Method);

        for(int i = 0; i < Build_Type.Count; i++)
        {
            Build_Type[i].onClick.AddListener(()=>Select_Build_Set(i));
        }

        // Popup_ui의 뒤로가기 버튼.
        Back_Btn.onClick.AddListener(Popup_at_Back);
        #endregion

    }

    private void Update()
    {
        //Debug.Log();
    }

    public void Reset_Scroll()
    {
        Debug.Log("스크롤 세팅 초기화. UIManager.cs - Start() - Reset_Scroll()");
        setting_01.SetActive(true);
        setting_02.SetActive(false);
    }

    // 스크롤의 세팅을 setting_02로 바꿉니다.
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
