using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSetup : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float holdTime = 1f; // 길게 누르는 시간 (1초)
    private bool isHolding = false; // 버튼이 눌렸는지 여부
    private float holdTimer = 0f; // 버튼이 눌린 시간 타이머
    private PrefabSelector prefabSelector; // 프리팹 선택자 참조

    private void Awake()
    {
        prefabSelector = FindObjectOfType<PrefabSelector>(); // 프리팹 선택자 찾기
    }

    private void Update()
    {
        // 버튼이 눌린 상태일 때, 시간 증가
        if (isHolding)
        {
            holdTimer += Time.deltaTime;

            if (holdTimer >= holdTime)
            {
                isHolding = false;
                holdTimer = 0f;

                // 버튼 이미지에 따른 프리팹 생성 요청
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
        holdTimer = 0f; // 타이머 초기화
    }
}
