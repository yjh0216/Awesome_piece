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

    // 카메라의 이동 범위를 설정하기 위한 변수들 (월드 좌표)
    private Vector2 minWorldBounds = new Vector2(-8.05f, -14f); // 월드의 최소 좌표 (왼쪽 하단)
    private Vector2 maxWorldBounds = new Vector2(27.5f, 11.1f); // 월드의 최대 좌표 (오른쪽 상단)

    private void Start()
    {
        // 카메라의 초기 Z 위치 저장
        initialCameraZ = transform.position.z;
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
                isPointerOverUI = true; // UI 위에서 클릭이 시작되었음을 기록
        }

        if (Input.GetMouseButtonUp(0))
        {
            isPointerOverUI = false; // 터치가 끝났으므로 플래그를 초기화
            isDragging = false; // 드래그 상태도 초기화
        }

        if (!GameManager.Inst.UI_Manager.isPopup_buildMenu)
        {
            Camera_Move(); // 터치된 손가락이 1개 (카메라 움직임)
        }
    }

    private void Camera_Move()
    {
        if (isPointerOverUI && !isDragging)
        {
            return; // UI 위에서 드래그가 시작된 경우, 드래그를 하지 않음
        }

        if (Input.GetMouseButtonDown(0) && !isPointerOverUI)
        {
            previousMousePosition = Input.mousePosition; // 이전 마우스 위치 초기화
            isDragging = true; // 드래그 시작 상태로 변경
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            Vector2 currentMousePosition = Input.mousePosition; // 현재 마우스 포지션
            Vector2 deltaPosition = currentMousePosition - previousMousePosition; // 이전 위치와의 차이 계산

            if (deltaPosition.magnitude > 0.1f)
            {
                Vector3 pos = Camera.main.ScreenToViewportPoint(-deltaPosition); // 드래그와 카메라의 이동방향을 만들어주기 위함
                Vector3 move = pos * (Time.deltaTime * DragSpeed);

                // 카메라의 현재 뷰포트 영역 계산
                Vector3 viewportMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, initialCameraZ));
                Vector3 viewportMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, initialCameraZ));

                // 카메라의 새로운 위치 계산
                Vector3 newPosition = transform.position + move;
                newPosition.z = initialCameraZ;

                // 뷰포트의 월드 좌표 크기
                float viewportWidth = viewportMax.x - viewportMin.x;
                float viewportHeight = viewportMax.y - viewportMin.y;

                // 월드 좌표 범위로 카메라 위치 제한
                newPosition.x = Mathf.Clamp(newPosition.x, minWorldBounds.x + viewportWidth / 2, maxWorldBounds.x - viewportWidth / 2);
                newPosition.y = Mathf.Clamp(newPosition.y, minWorldBounds.y + viewportHeight / 2, maxWorldBounds.y - viewportHeight / 2);

                transform.position = newPosition;
            }

            previousMousePosition = currentMousePosition; // 현재 위치를 이전 위치로 업데이트
        }
    }
}
