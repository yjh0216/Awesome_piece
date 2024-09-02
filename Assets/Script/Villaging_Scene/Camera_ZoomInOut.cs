using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_ZoomInout : MonoBehaviour
{
    // ★ 내가 작성한게 하나도 없음... 꼼꼼히 한줄 한줄 작업 방식과 구현 이해하기.

    public float zoomSpeed = 1f;       // 줌 속도 조절 (줌 레벨 변경의 속도)
    public float zoomDuration = 0.1f;  // 줌 효과의 지속 시간 (부드러운 줌 속도)
    public float minZoom = 5f;         // 최소 줌 거리 (축소 시 최대로 멀어지는 거리)
    public float maxZoom = 12.5f;      // 최대 줌 거리 (확대 시 최대로 가까워지는 거리)

    private Camera cam;                // 카메라 컴포넌트를 저장할 변수
    private float targetZoom;          // 목표 줌 레벨
    private float zoomVelocity;        // 줌 속도 (부드러운 줌을 위한 보조 변수)
    private bool isZoomingIn;          // 줌 인 상태 여부
    private bool isZoomingOut;         // 줌 아웃 상태 여부

    // 카메라의 이동 범위를 설정하기 위한 변수들 (뷰포트의 좌표)
    private Vector2 minWorldBounds = new Vector2(-8.05f, -14f); // 월드의 최소 좌표 (왼쪽 하단)
    private Vector2 maxWorldBounds = new Vector2(27.5f, 11.1f); // 월드의 최대 좌표 (오른쪽 상단)

    private void Start()
    {
        // 카메라 컴포넌트를 초기화
        cam = Camera.main;
        targetZoom = cam.orthographicSize; // 초기 줌 레벨을 현재 줌 레벨로 설정
    }

    private void Update()
    {
        // 키보드 입력에 따라 줌을 설정
        if (Input.GetKeyDown(KeyCode.Alpha1)) // '1' 키를 눌렀을 때
        {
            isZoomingIn = true;
            isZoomingOut = false;
            targetZoom = Mathf.Max(cam.orthographicSize - 5f, minZoom); // 줌 인 목표
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) // '2' 키를 눌렀을 때
        {
            isZoomingIn = false;
            isZoomingOut = true;
            targetZoom = Mathf.Min(cam.orthographicSize + 5f, maxZoom); // 줌 아웃 목표
        }

        // 줌 인/아웃 상태에 따라 줌 레벨을 부드럽게 조절
        if (isZoomingIn || isZoomingOut)
        {
            // 부드럽게 줌 조절
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, targetZoom, ref zoomVelocity, zoomDuration);

            // 줌 인/아웃 도중에 카메라 위치를 조정하여 범위를 유지
            AdjustCameraBounds();

            // 줌이 완료된 후 상태 초기화
            if (Mathf.Approximately(cam.orthographicSize, targetZoom))
            {
                isZoomingIn = false;
                isZoomingOut = false;
            }
        }
    }

    private void AdjustCameraBounds()
    {
        // 카메라의 뷰포트를 월드 좌표로 변환하여 범위 제한
        Vector3 viewportMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector3 viewportMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));

        // 월드 좌표 범위에 따라 카메라의 위치 조정
        float cameraWidth = viewportMax.x - viewportMin.x;
        float cameraHeight = viewportMax.y - viewportMin.y;

        Vector3 newPosition = transform.position;

        // 줌 인/아웃에 따라 카메라의 위치 조정
        newPosition.x = Mathf.Clamp(newPosition.x, minWorldBounds.x + cameraWidth / 2, maxWorldBounds.x - cameraWidth / 2);
        newPosition.y = Mathf.Clamp(newPosition.y, minWorldBounds.y + cameraHeight / 2, maxWorldBounds.y - cameraHeight / 2);

        transform.position = newPosition;
    }
}