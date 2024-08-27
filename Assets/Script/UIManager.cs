using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

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
    [SerializeField] private GameObject PopUp_Building_Menu_Obj;
    [SerializeField] private GameObject PopUp_Content;
    [SerializeField] private TextMeshProUGUI Tip_text;

    [Header("Popup_ui�� �ִ� �ǹ� ��ư�� �ֱ�")]
    [SerializeField] private List<Button> Build_Type; // �Ǽ��� �ǹ��� ��ưŸ���� ����Ʈ�� �ִ´�.

    [Header("Popup_ui�� �ڷΰ��� ��ư")]
    [SerializeField] private Button Back_Btn;

    [Header("Scroll Up/Down ��ư")]
    [SerializeField] private Button scrollUp_Btn;
    [SerializeField] private Button scrollDown_Btn;

    private void Start()
    {
        Reset_Scroll(); // ��ũ���� �ʱ�ȭ.

        #region _Button.onClick.AddListener()_
        Scroll_Btn01.onClick.AddListener(Change_Scroll_setting02);
        // todo : ������ ��ư�鵵 ����.
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
        //Debug.Log();
    }

    Vector2 up_pos = new Vector2(8.41f, -5.53f);
    Vector2 down_pos = new Vector2(8.41f, -8.57f);

    public void Reset_Scroll()
    {
        //Debug.Log("��ũ�� ���� �ʱ�ȭ. UIManager.cs - Start() - Reset_Scroll()");
        setting_01.SetActive(true);
        setting_02.SetActive(false);

        scrollUp_Btn.gameObject.SetActive(true);
        scrollDown_Btn.gameObject.SetActive(false);

        Scroll_UI_Obj.transform.position = down_pos;

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
        //Debug.Log($"{num}���� ��ư Ŭ��");
        PopUp_Building_Menu_Obj.transform.localScale = Vector3.zero; // Popup_ui�� �ٽ� �Ⱥ��̰� ó��.

        // obj�� Ŭ���� ��ư ������Ʈ�� �ڽ��� �ڽ�. ��, Image ������Ʈ�� ���� building_img.
        GameObject obj;
        obj = Build_Type[num].gameObject.transform.GetChild(0).GetChild(0).gameObject;

        float width = 0, height = 0;
        if (obj.TryGetComponent<RectTransform>(out RectTransform rect_A))
        {
            width = rect_A.rect.width;
            height = rect_A.rect.height;
        } // ���� ����.

        if (!obj.TryGetComponent<Image>(out Image img)) // ���� building_img ������Ʈ�� ���� Image ������Ʈ�� SourceImage(sprite)�� ����ϱ� ���� img�� ����.
            Debug.Log("obj���� Image ���� ����");

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
            //Debug.Log($"���� �׽�Ʈ... / img2.sprite : {img2.sprite}, img.sprite : {img.sprite}");
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

            // todo : ���߿� Insert_Text__�κп��� Tip������ ������ �۾����ٰ�.

        }

        switch(num)
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
    }

    private void scrollUp() // �ø��� ��ư Ŭ�� ��.
    {
        scrollUp_Btn.gameObject.SetActive(false);
        scrollDown_Btn.gameObject.SetActive(true);

        Scroll_UI_Obj.transform.position = up_pos;
    }

    private void scrollDown() // ������ ��ư Ŭ�� ��.
    {
        setting_01.SetActive(true);
        setting_02.SetActive(false);

        scrollUp_Btn.gameObject.SetActive(true);
        scrollDown_Btn.gameObject.SetActive(false);

        Scroll_UI_Obj.transform.position = down_pos;

        if (mask_slot_obj.transform.childCount != 0) // Build�� ���õ� �ǹ��� �ʱ�ȭ.
        {
            Destroy(mask_slot_obj.transform.GetChild(0).gameObject);
        }
        Select_Building_Name.text = "�� �Ǽ��� �ǹ� ����";

        Tip_text.text = "";

    }
}
