using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSetup : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float holdTime = 1f; // ��� ������ �ð� (1��)
    private bool isHolding = false; // ��ư�� ���ȴ��� ����
    private float holdTimer = 0f; // ��ư�� ���� �ð� Ÿ�̸�
    private PrefabSelector prefabSelector; // ������ ������ ����

    private void Awake()
    {
        prefabSelector = FindObjectOfType<PrefabSelector>(); // ������ ������ ã��
    }

    private void Update()
    {
        // ��ư�� ���� ������ ��, �ð� ����
        if (isHolding)
        {
            holdTimer += Time.deltaTime;

            if (holdTimer >= holdTime)
            {
                isHolding = false;
                holdTimer = 0f;

                // ��ư �̹����� ���� ������ ���� ��û
                prefabSelector.SpawnPrefabBasedOnButton(this.GetComponent<Image>().sprite);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
        holdTimer = 0f; // Ÿ�̸� �ʱ�ȭ
    }
}
