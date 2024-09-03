using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("��ũ�� ui")]
    [SerializeField] private GameObject Scroll_UI_Obj;

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
    [SerializeField] private GameObject mask_slot_obj;
    [SerializeField] private TextMeshProUGUI Select_Building_Name;
    [SerializeField] private GameObject PopUp_Building_Menu_Obj;        public bool isPopup_buildMenu = false;
    [SerializeField] private GameObject PopUp_Content;
    [SerializeField] private TextMeshProUGUI Tip_text;

    [Header("Popup_ui�� �ִ� �ǹ� ��ư�� �ֱ�")]
    [SerializeField] public List<Button> Build_Type; // �Ǽ��� �ǹ��� ��ưŸ���� ����Ʈ�� �ִ´�.

    [Header("Popup_ui�� �ڷΰ��� ��ư")]
    [SerializeField] private Button Back_Btn;

    [Header("Scroll Up/Down ��ư")]
    [SerializeField] private Button scrollUp_Btn;
    [SerializeField] private Button scrollDown_Btn;

    private Vector2 Up_LocalPosition   = new Vector2(9.02f, -790f);
    private Vector2 Down_LocalPosition = new Vector2(9.02f, -1371f);

    private Vector2 scroll_ui_scale = new Vector2(1.7f, 1.7f);

    private void Start()
    {
        Reset_Scroll(); // ��ũ���� �ʱ�ȭ.

        #region _Button.onClick.AddListener()_
        Scroll_Btn01.onClick.AddListener(Change_Scroll_setting02);
        // �� todo : ������ ��ư�鵵 ����.
        Select_Building_Btn.onClick.AddListener(Popup_building_Menu_Method);

        //-------------------------------------------------------------------------- �Ѵ� 10���� ��ư���� ��� Build_Type[10]�� ����Ű�� ����
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
        //-------------------------------------------------------------------------- �� ����� �����غ������� �ȵǼ� �Ʒ� ������� ���...
        // int i�� int index�� ���� �Ҵ�� �޸𸮰� 0���� 10�� �ɶ����� �״�ζ�...?
        // �Ʒ� 0���� ���� ���ڸ� �־��ؾֵ��� Select_Build_Set(0);�� �Ǵ� ���� ���� �Ҵ��� ������ ���ο� �޸𸮸� �Ҵ���� �ָ� ����ؼ�..?
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

        // Popup_ui�� �ڷΰ��� ��ư.
        Back_Btn.onClick.AddListener(Popup_at_Back);

        scrollUp_Btn.onClick.AddListener(scrollUp);
        scrollDown_Btn.onClick.AddListener(scrollDown);
        #endregion

    }

    private void Update()
    {

    }

    public void Reset_Scroll()
    {
        //Debug.Log("��ũ�� ���� �ʱ�ȭ. UIManager.cs - Start() - Reset_Scroll()");
        setting_01.SetActive(true);
        setting_02.SetActive(false);

        scrollUp_Btn.gameObject.SetActive(true);
        scrollDown_Btn.gameObject.SetActive(false);

        //Scroll_UI_Obj.transform.position = down_pos;
        if (Scroll_UI_Obj.TryGetComponent<RectTransform>(out RectTransform rectTransform))
        {
            rectTransform.localPosition = Down_LocalPosition;
            rectTransform.localScale = scroll_ui_scale;
        }

        if (mask_slot_obj.transform.childCount != 0) // Build�� ���õ� �ǹ��� �ʱ�ȭ.
        {
            Destroy(mask_slot_obj.transform.GetChild(0).gameObject);
        }
        Select_Building_Name.text = "�� �Ǽ��� �ǹ� ����";

        Tip_text.text = "";
    }

    // ��ũ���� ������ setting_02�� �ٲߴϴ�.
    private void Change_Scroll_setting02()
    {
        if (setting_01.activeSelf)
        {
            setting_01.SetActive(false);
            setting_02.SetActive(true);
        }
        PopUp_Building_Menu_Obj.transform.localScale = Vector3.zero;
    }

    private void Popup_building_Menu_Method() // �˾� â�� Ų��.
    {
        isPopup_buildMenu = true;
        PopUp_Building_Menu_Obj.transform.localScale = Vector3.one;
        PopUp_Content.transform.localPosition = new Vector3(0f, -0.1f, 0f); // Scroll View�� localScale�� 0�� �ɶ����� �Ʒ��� ��ϵ��� ���߾ ������ ��ġ�� ����.
    }

    private void Popup_at_Back() // �˾� â�� ����.
    {
        isPopup_buildMenu = false;
        PopUp_Building_Menu_Obj.transform.localScale = Vector3.zero;
    }

    private void Select_Build_Set(int num) // �ǹ� ��ư�� Ŭ���ϸ� ���ñ���
    {
        Popup_at_Back(); // Popup_ui�� �ٽ� �Ⱥ��̰� ó��.

        // obj�� Ŭ���� ��ư ������Ʈ�� �ڽ��� �ڽ�. ��, Image ������Ʈ�� ���� building_img.
        GameObject obj;
        obj = Build_Type[num].gameObject.transform.GetChild(0).GetChild(0).gameObject; // ���⼭ obj�� "Popup�� �ǹ� ����â�� �ǹ� ������Ʈ" image.

        float width = 0, height = 0;
        if (obj.TryGetComponent<RectTransform>(out RectTransform rect_A)) // �� ������Ʈ�� RectTransform�� ������ ���� ���̿� ���� ���̸� ����.
        {
            width = rect_A.rect.width;
            height = rect_A.rect.height; // �� ���� Sprite�� pixel ���� ������ �ִ�.
        } // ���� ����.

        if (!obj.TryGetComponent<Image>(out Image img)) // ���� building_img ������Ʈ�� ���� Image ������Ʈ�� SourceImage(sprite)�� ����ϱ� ���� img�� ����.
            Debug.Log("obj���� Image ���� ����");
        // �� �������� "img"���� �� "Popup�� �ǹ� ����â�� �ǹ� ������Ʈ"�� image ������Ʈ�� ���� ����.

        Image img2; // ������ ������ ������Ʈ�� Image������Ʈ��, ���� Image���� ������ ��� ���� img2.

        if(mask_slot_obj.transform.childCount != 0) // ���� �̹� mask_slot_obj���� �ڽ��� �ִ� ���
        {
            Destroy(mask_slot_obj.transform.GetChild(0).gameObject); // �̹� �ִ� �ڽ��� ����.
        }

        obj = Instantiate(obj, mask_slot_obj.transform); // ���⼭ obj�� mask_slot_obj�� �ڽ����� ������ ������Ʈ. (���õ� �ǹ��� ���� Ÿ���� �ǹ� ������Ʈ image)

        if (!obj.GetComponent<Image>()) // obj���Լ� Image�� ���� ��� Image������Ʈ�� �߰�.
            obj.AddComponent<Image>();

        if (!obj.GetComponent<Button>())
        {
            Button btn = obj.AddComponent<Button>();
            // �� todo : �޼ҵ带 ����� ���⼭ �߰��� ��ư���� �� ������ ����� ���� �غ��ϵ��� ������ ��.
        }

        if(!obj.GetComponent<ButtonSetup>())
            obj.AddComponent<ButtonSetup>();


        if (obj.TryGetComponent<Image>(out img2))
        {
            //Debug.Log($"���� �׽�Ʈ... / img2.sprite : {img2.sprite}, img.sprite : {img.sprite}");
            img2.sprite = img.sprite; // ������ ��ư�� ������ sprite�� Image�� ���� ��������.
            
            if(obj.TryGetComponent<RectTransform>(out RectTransform rect_B))
            {
                rect_B.localPosition = Vector3.zero; // ������ ������Ʈ�� ��ġ�� ����.
                rect_B.sizeDelta = new Vector2(width, height); // ������ ������Ʈ�� ũ�� �� ����.
            }
            obj.name = img2.name; // �̸��� �Ȱ��� ������ �ڿ� "(Clone)"�� �ٴ´�. �̰Ŷ� ���ϸ� New GameObject��� ������.

            obj = Build_Type[num].gameObject.transform.GetChild(2).gameObject; // ���⼭ obj�� Text������ ������Ʈ... �̸� String�� �״�� �������ֱ� ���� �۾�.
            if (obj.TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI child_Text))
                Select_Building_Name.text = child_Text.text;

        }

        #region _�ǹ��� ���� Tip ���� ����_
        switch (num)
        {
            case 0: // Main_Tower ���� �ǹ�
                Tip_text.text = "�������� ���� �߿��� ���๰�Դϴ�. �������� ���� �ǹ����� ����ϱ� ���ؼ� ���� �ǹ��� �ʿ�� �ϸ� ������ �Ѹ���� ��ġ�Ҽ� �ֽ��ϴ�. ��ġ�� ������ ��� ���ӿ��� ��� �ɷ�ġ�� �����մϴ�. ���� ���� �ǹ��� Ư�� ������ �ٸ���� �Ϸ��߿� ������ �ð��� ����� ������ ������ �ֽ��ϴ�.";
                break;
            case 1: // Tavern ����
                Tip_text.text = "������ é�Ϳ��� �����鿡�� �ѹ��� ���ӵ��� ������ ����ȿ���� �ο����ִ� �ǹ��Դϴ�. ���� �ǹ��� ������ ���������� �ķ��� �ڿ� ȹ�淮�� �����մϴ�. �������� ������ 3����� ��ġ�� �� ������ ��ġ�� ������� ������ ���� ��� �ķ� �Ҹ��� �ִ� 3 ���ҽ�ų �� �ֽ��ϴ�.";
                break;
            case 2: // Operation ���� ���ֺ�
                Tip_text.text = "���� ���ֺδ� �������� �������� Ư���� ������ ���ִ� �ǹ��Դϴ�. ��5���帶�� ��� �������ְų� ���� ����(���� ������ ���� ��)�� �޴����ظ� ������Ű�� �� ������ ���ϱ� ���� �������� ������ ������ �� �ֽ��ϴ�.";
                break;
            case 3: // Barrack_A �˼�
                Tip_text.text = "�� �ǹ��� ��� �������� ���ݷ��� ������ŵ�ϴ�. ���� �ش� �ǹ��� ��� ������ ������ 3����� ��ġ�� �� ������ ��ġ�� ������ ���� ����Ҷ� 1.5���� ���ݷ��� ����˴ϴ�.";
                break;
            case 4: // Barrack_B �ü�
                Tip_text.text = "�� �ǹ��� ��� �������� ���ݼӵ�/�����ӵ��� ������ŵ�ϴ�. ���� �ش� �ǹ��� ��� ������ ������ 3����� ��ġ�� �� ������ ��ġ�� ������ Ȱ�� ����Ҷ� 1.2���� ���ݼӵ�/�����ӵ��� ����˴ϴ�.";
                break;
            case 5: // Barrack_C ����
                Tip_text.text = "�� �ǹ��� ��� �������� �ֹ����� ������ŵ�ϴ�. ���� �ش� �ǹ��� ��� ������ ������ 3����� ��ġ�� �� ������ ��ġ�� ������ �����̸� ����Ҷ� 2���� �ֹ����� ����˴ϴ�.";
                break;
            case 6: // Barrack_D ü��
                Tip_text.text = "�� �ǹ��� ��� �������� ü���� ������ŵ�ϴ�. ���� �ش� �ǹ��� ��� ������ ������ 3����� ��ġ�� �� ������ ��ġ�� ������ ������ ����Ҷ� 1.5���� ü���� ����˴ϴ�.";
                break;
            case 7: // Alchemy ���ݼ�
                Tip_text.text = "�ش� �ǹ��� �������� ���忡 �ʿ��� Ư���� �ڿ����� ���� �¹ٲپ� �����س��� �ǹ��Դϴ�. ���� ������ ������ ��� ���ݼ��� ���� ������ �������� �ֽ��ϴ�.";
                break;
            case 8: // Sanctuary ����
                Tip_text.text = "���Ҵ� ���ָ��� �̷ο� ����ȿ���� ������ �ɴϴ�. ������ �Ѹ� ��ġ�� �� ������ �ش� ������ Ŭ������ ���� �����ϵ��� Ư���� ������ ���� �� ������ ���� ������ ��ġ�� ��� 1.5���� ȿ���� �޽��ϴ�.";
                break;
            case 9: // Magic_Stone ������
                Tip_text.text = "�������� �ſ� ������ �ð��뿡 �Ѹ��� �������� �ֹ����� ���� ��½����ִ� �ǹ��Դϴ�. ������ �Ѹ������ ��ġ �����ϸ� ��ġ�� ������ PVE�������� ���� �幮 Ȯ���� �ֹ����� 300% �����մϴ�.";
                break;
        }
        #endregion
    }

    private void scrollUp() // �ø��� ��ư Ŭ�� ��.
    {
        scrollUp_Btn.gameObject.SetActive(false);
        scrollDown_Btn.gameObject.SetActive(true);

        if (Scroll_UI_Obj.TryGetComponent<RectTransform>(out RectTransform rectTransform))
            rectTransform.localPosition = Up_LocalPosition;

    }

    private void scrollDown() // ������ ��ư Ŭ�� ��.
    {
        Popup_at_Back();

        setting_01.SetActive(true);
        setting_02.SetActive(false);

        scrollUp_Btn.gameObject.SetActive(true);
        scrollDown_Btn.gameObject.SetActive(false);

        if (Scroll_UI_Obj.TryGetComponent<RectTransform>(out RectTransform rectTransform))
            rectTransform.localPosition = Down_LocalPosition;


        if (mask_slot_obj.transform.childCount != 0) // Build�� ���õ� �ǹ��� �ʱ�ȭ.
        {
            Destroy(mask_slot_obj.transform.GetChild(0).gameObject);
        }
        Select_Building_Name.text = "�� �Ǽ��� �ǹ� ����";

        Tip_text.text = "";

    }
}
