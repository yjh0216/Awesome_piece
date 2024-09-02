using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Camera_move : MonoBehaviour
{
    public float DragSpeed = 2000f;

    private Vector2 previousMousePosition; // 이전 프레임의 마우스 위치
    private bool isDragging; // 드래그 중인지 여부
    private float initialCameraZ; // 초기 카메라 Z 위치
    private bool isPointerOverUI; // UI 위에서 드래그가 시작되었는지 여부

    private void Start()
    {
        // 카메라의 초기 Z 위치 저장
        initialCameraZ = transform.position.z;
    }

    private void Update()
    {
        // UI 위에서 포인터가 있을 경우와 UI 밖에서 시작했을 경우를 구분하여 처리
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                isPointerOverUI = true; // UI 위에서 클릭이 시작되었음을 기록
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isPointerOverUI = false; // 터치가 끝났으므로 플래그를 초기화
            isDragging = false; // 드래그 상태도 초기화
        }

        // UIManager의 건물 선택창이 켜져있지 않은 상태에서만 드래그가 가능하도록
        if (!GameManager.Inst.UI_Manager.isPopup_buildMenu)
        {
            Camera_Move(); // 터치된 손가락이 1개 (카메라 움직임)
        }
    }

    private void Camera_Move()
    {
        // UI 위에서 드래그가 시작되었을 때는 드래그 동작을 막음
        if (isPointerOverUI && !isDragging)
        {
            return; // UI 위에서 드래그가 시작된 경우, 드래그를 하지 않음
        }

        // 터치가 시작될 때
        if (Input.GetMouseButtonDown(0) && !isPointerOverUI)
        {
            //Debug.Log("한개의 터치 지점 확인");
            previousMousePosition = Input.mousePosition; // 이전 마우스 위치 초기화
            isDragging = true; // 드래그 시작 상태로 변경
        }

        // 터치가 유지될 때
        if (Input.GetMouseButton(0) && isDragging)
        {
            Vector2 currentMousePosition = Input.mousePosition; // 현재 마우스 포지션
            Vector2 deltaPosition = currentMousePosition - previousMousePosition; // 이전 위치와의 차이 계산

            // 움직임이 일정한 범위 이상일 때만 드래그로 간주
            if (deltaPosition.magnitude > 0.1f)
            {
                Vector3 pos = Camera.main.ScreenToViewportPoint(-deltaPosition); // 드래그와 카메라의 이동방향을 만들어주기 위함
                Vector3 move = pos * (Time.deltaTime * DragSpeed);

                transform.Translate(move);
                transform.position = new Vector3(transform.position.x, transform.position.y, initialCameraZ); // Z 위치 고정
            }

            previousMousePosition = currentMousePosition; // 현재 위치를 이전 위치로 업데이트
        }
    }
}