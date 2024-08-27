using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    [Header("스크롤 ui")]
    [SerializeField] private GameObject Scroll_UI_Obj;

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
    [SerializeField] private GameObject mask_slot_obj;
    [SerializeField] private TextMeshProUGUI Select_Building_Name;
    [SerializeField] private GameObject PopUp_Building_Menu_Obj;
    [SerializeField] private GameObject PopUp_Content;
    [SerializeField] private TextMeshProUGUI Tip_text;

    [Header("Popup_ui에 있는 건물 버튼들 넣기")]
    [SerializeField] private List<Button> Build_Type; // 건설할 건물의 버튼타입을 리스트에 넣는다.

    [Header("Popup_ui의 뒤로가기 버튼")]
    [SerializeField] private Button Back_Btn;

    [Header("Scroll Up/Down 버튼")]
    [SerializeField] private Button scrollUp_Btn;
    [SerializeField] private Button scrollDown_Btn;

    private void Start()
    {
        Reset_Scroll(); // 스크롤을 초기화.

        #region _Button.onClick.AddListener()_
        Scroll_Btn01.onClick.AddListener(Change_Scroll_setting02);
        // todo : 나머지 버튼들도 예정.
        Select_Building_Btn.onClick.AddListener(Popup_building_Menu_Method);

        //-------------------------------------------------------------------------- 둘다 10개의 버튼들이 모두 Build_Type[10]을 가리키고 있음
        //for(int i = 0; i < Build_Type.Count; i++)
        //{
        //    Build_Type[i].onClick.AddListener(()=>Select_Build_Set(i));
        //}

        //int index = 0;
        //while(index < 10)
        //{
        //    Build_Type[index].onClick.AddListener(() => Select_Build_Set(index));
        //    index++;
        //}
        //-------------------------------------------------------------------------- 위 방식이 간결해보이지만 안되서 아래 방식으로 사용...
        // int i나 int index는 각자 할당된 메모리가 0에서 10이 될때까지 그대로라서...?
        // 아래 0같은 직접 숫자를 넣어준애들은 Select_Build_Set(0);가 되는 순간 각자 할당이 끝나고 새로운 메모리를 할당받은 애를 사용해서..?
        Build_Type[0].onClick.AddListener(() => Select_Build_Set(0));
        Build_Type[1].onClick.AddListener(() => Select_Build_Set(1));
        Build_Type[2].onClick.AddListener(() => Select_Build_Set(2));
        Build_Type[3].onClick.AddListener(() => Select_Build_Set(3));
        Build_Type[4].onClick.AddListener(() => Select_Build_Set(4));

        Build_Type[5].onClick.AddListener(() => Select_Build_Set(5));
        Build_Type[6].onClick.AddListener(() => Select_Build_Set(6));
        Build_Type[7].onClick.AddListener(() => Select_Build_Set(7));
        Build_Type[8].onClick.AddListener(() => Select_Build_Set(8));
        Build_Type[9].onClick.AddListener(() => Select_Build_Set(9));

        // Popup_ui의 뒤로가기 버튼.
        Back_Btn.onClick.AddListener(Popup_at_Back);

        scrollUp_Btn.onClick.AddListener(scrollUp);
        scrollDown_Btn.onClick.AddListener(scrollDown);
        #endregion

    }

    private void Update()
    {
        //Debug.Log();
    }

    Vector2 up_pos = new Vector2(8.41f, -5.53f);
    Vector2 down_pos = new Vector2(8.41f, -8.57f);

    public void Reset_Scroll()
    {
        //Debug.Log("스크롤 세팅 초기화. UIManager.cs - Start() - Reset_Scroll()");
        setting_01.SetActive(true);
        setting_02.SetActive(false);

        scrollUp_Btn.gameObject.SetActive(true);
        scrollDown_Btn.gameObject.SetActive(false);

        Scroll_UI_Obj.transform.position = down_pos;

        if (mask_slot_obj.transform.childCount != 0) // Build에 선택된 건물을 초기화.
        {
            Destroy(mask_slot_obj.transform.GetChild(0).gameObject);
        }
        Select_Building_Name.text = "◀ 건설할 건물 선택";

        Tip_text.text = "";
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
        //Debug.Log($"{num}번쩨 버튼 클릭");
        PopUp_Building_Menu_Obj.transform.localScale = Vector3.zero; // Popup_ui를 다시 안보이게 처리.

        // obj는 클릭한 버튼 오브젝트의 자식의 자식. 즉, Image 컴포넌트를 가진 building_img.
        GameObject obj;
        obj = Build_Type[num].gameObject.transform.GetChild(0).GetChild(0).gameObject;

        float width = 0, height = 0;
        if (obj.TryGetComponent<RectTransform>(out RectTransform rect_A))
        {
            width = rect_A.rect.width;
            height = rect_A.rect.height;
        } // 길이 저장.

        if (!obj.TryGetComponent<Image>(out Image img)) // 위의 building_img 오브젝트가 가진 Image 컴포넌트의 SourceImage(sprite)를 사용하기 위해 img를 참조.
            Debug.Log("obj에서 Image 참조 실패");

        Image img2;

        if(mask_slot_obj.transform.childCount != 0)
        {
            Destroy(mask_slot_obj.transform.GetChild(0).gameObject);
        }

        obj = Instantiate(obj, mask_slot_obj.transform);

        if(!obj.GetComponent<Image>())
            obj.AddComponent<Image>();

        if (obj.TryGetComponent<Image>(out img2))
        {
            //Debug.Log($"적용 테스트... / img2.sprite : {img2.sprite}, img.sprite : {img.sprite}");
            img2.sprite = img.sprite;
            
            if(obj.TryGetComponent<RectTransform>(out RectTransform rect_B))
            {
                rect_B.localPosition = Vector3.zero;
                rect_B.sizeDelta = new Vector2(width, height);
            }
            obj.name = img2.name;

            obj = Build_Type[num].gameObject.transform.GetChild(2).gameObject;
            if (obj.TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI child_Text))
                Select_Building_Name.text = child_Text.text;

            // todo : 나중에 Insert_Text__부분에도 Tip같은게 들어가도록 작업해줄것.

        }

        switch(num)
        {
            case 0: // Main_Tower 메인 건물
                Tip_text.text = "영지에서 가장 중요한 건축물입니다. 영지내의 여러 건물들이 기능하기 위해선 메인 건물을 필요로 하며 영웅을 한명까지 배치할수 있습니다. 배치된 영웅은 모든 게임에서 모든 능력치가 증가합니다. 또한 메인 건물이 특정 레벨에 다를경우 하루중에 랜덤한 시간에 상단의 지원을 받을수 있습니다.";
                break;
            case 1: // Tavern 여관
                Tip_text.text = "여관은 챕터에서 영웅들에게 한번의 게임동안 갖가지 버프효과를 부여해주는 건물입니다. 여관 건물의 레벨이 높아질수록 식량의 자연 획득량이 증가합니다. 여관에는 영웅을 3명까지 배치할 수 있으며 배치된 영웅들로 전투에 임할 경우 식량 소모량을 최대 3 감소시킬 수 있습니다.";
                break;
            case 2: // Operation 작전 지휘부
                Tip_text.text = "작전 지휘부는 여러가지 전투에서 특별한 지원을 해주는 건물입니다. 매5라운드마다 장비를 지원해주거나 정예 몬스터(가장 성급이 높은 적)의 받는피해를 증가시키는 등 전투에 임하기 전에 여러가지 전략을 선택할 수 있습니다.";
                break;
            case 3: // Barrack_A 검술
                Tip_text.text = "이 건물은 모든 영웅들의 공격력을 증가시킵니다. 또한 해당 건물에 상시 상주할 영웅을 3명까지 배치할 수 있으며 배치된 영웅은 검을 장비할때 1.5배의 공격력이 적용됩니다.";
                break;
            case 4: // Barrack_B 궁술
                Tip_text.text = "이 건물은 모든 영웅들의 공격속도/충전속도를 증가시킵니다. 또한 해당 건물에 상시 상주할 영웅을 3명까지 배치할 수 있으며 배치된 영웅은 활을 장비할때 1.2배의 공격속도/충전속도가 적용됩니다.";
                break;
            case 5: // Barrack_C 마법
                Tip_text.text = "이 건물은 모든 영웅들의 주문력을 증가시킵니다. 또한 해당 건물에 상시 상주할 영웅을 3명까지 배치할 수 있으며 배치된 영웅은 지팡이를 장비할때 2배의 주문력이 적용됩니다.";
                break;
            case 6: // Barrack_D 체력
                Tip_text.text = "이 건물은 모든 영웅들의 체력을 증가시킵니다. 또한 해당 건물에 상시 상주할 영웅을 3명까지 배치할 수 있으며 배치된 영웅은 갑옷을 장비할때 1.5배의 체력이 적용됩니다.";
                break;
            case 7: // Alchemy 연금술
                Tip_text.text = "해당 건물은 여러가지 성장에 필요한 특수한 자원들을 재료와 맞바꾸어 생산해내는 건물입니다. 높은 도전에 막혔을 경우 연금술을 통해 성장을 높여볼수 있습니다.";
                break;
            case 8: // Sanctuary 성소
                Tip_text.text = "성소는 매주마다 이로운 버프효과를 가지고 옵니다. 영웅을 한명 배치할 수 있으며 해당 영웅의 클래스에 따라 일주일동안 특별한 버프를 얻을 수 있으며 교단 영웅을 배치할 경우 1.5배의 효과를 받습니다.";
                break;
            case 9: // Magic_Stone 마법석
                Tip_text.text = "마법석은 매우 랜덤한 시간대에 한명의 영웅에게 주문력을 대폭 상승시켜주는 건물입니다. 영웅을 한명까지만 배치 가능하며 배치된 영웅은 PVE전투에서 극히 드문 확률로 주문력이 300% 증가합니다.";
                break;
        }
    }

    private void scrollUp() // 올리기 버튼 클릭 시.
    {
        scrollUp_Btn.gameObject.SetActive(false);
        scrollDown_Btn.gameObject.SetActive(true);

        Scroll_UI_Obj.transform.position = up_pos;
    }

    private void scrollDown() // 내리기 버튼 클릭 시.
    {
        setting_01.SetActive(true);
        setting_02.SetActive(false);

        scrollUp_Btn.gameObject.SetActive(true);
        scrollDown_Btn.gameObject.SetActive(false);

        Scroll_UI_Obj.transform.position = down_pos;

        if (mask_slot_obj.transform.childCount != 0) // Build에 선택된 건물을 초기화.
        {
            Destroy(mask_slot_obj.transform.GetChild(0).gameObject);
        }
        Select_Building_Name.text = "◀ 건설할 건물 선택";

        Tip_text.text = "";

    }
}
