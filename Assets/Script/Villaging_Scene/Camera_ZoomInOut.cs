using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_ZoomInout : MonoBehaviour
{
    // �� ���� �ۼ��Ѱ� �ϳ��� ����... �Ĳ��� ���� ���� �۾� ��İ� ���� �����ϱ�.

    public float zoomSpeed = 1f;       // �� �ӵ� ���� (�� ���� ������ �ӵ�)
    public float zoomDuration = 0.1f;  // �� ȿ���� ���� �ð� (�ε巯�� �� �ӵ�)
    public float minZoom = 5f;         // �ּ� �� �Ÿ� (��� �� �ִ�� �־����� �Ÿ�)
    public float maxZoom = 12.5f;      // �ִ� �� �Ÿ� (Ȯ�� �� �ִ�� ��������� �Ÿ�)

    private Camera cam;                // ī�޶� ������Ʈ�� ������ ����
    private float targetZoom;          // ��ǥ �� ����
    private float zoomVelocity;        // �� �ӵ� (�ε巯�� ���� ���� ���� ����)
    private bool isZoomingIn;          // �� �� ���� ����
    private bool isZoomingOut;         // �� �ƿ� ���� ����

    // ī�޶��� �̵� ������ �����ϱ� ���� ������ (����Ʈ�� ��ǥ)
    private Vector2 minWorldBounds = new Vector2(-8.05f, -14f); // ������ �ּ� ��ǥ (���� �ϴ�)
    private Vector2 maxWorldBounds = new Vector2(27.5f, 11.1f); // ������ �ִ� ��ǥ (������ ���)

    private void Start()
    {
        // ī�޶� ������Ʈ�� �ʱ�ȭ
        cam = Camera.main;
        targetZoom = cam.orthographicSize; // �ʱ� �� ������ ���� �� ������ ����
    }

    private void Update()
    {
        // Ű���� �Է¿� ���� ���� ����
        if (Input.GetKeyDown(KeyCode.Alpha1)) // '1' Ű�� ������ ��
        {
            isZoomingIn = true;
            isZoomingOut = false;
            targetZoom = Mathf.Max(cam.orthographicSize - 5f, minZoom); // �� �� ��ǥ
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) // '2' Ű�� ������ ��
        {
            isZoomingIn = false;
            isZoomingOut = true;
            targetZoom = Mathf.Min(cam.orthographicSize + 5f, maxZoom); // �� �ƿ� ��ǥ
        }

        // �� ��/�ƿ� ���¿� ���� �� ������ �ε巴�� ����
        if (isZoomingIn || isZoomingOut)
        {
            // �ε巴�� �� ����
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, targetZoom, ref zoomVelocity, zoomDuration);

            // �� ��/�ƿ� ���߿� ī�޶� ��ġ�� �����Ͽ� ������ ����
            AdjustCameraBounds();

            // ���� �Ϸ�� �� ���� �ʱ�ȭ
            if (Mathf.Approximately(cam.orthographicSize, targetZoom))
            {
                isZoomingIn = false;
                isZoomingOut = false;
            }
        }
    }

    private void AdjustCameraBounds()
    {
        // ī�޶��� ����Ʈ�� ���� ��ǥ�� ��ȯ�Ͽ� ���� ����
        Vector3 viewportMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector3 viewportMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));

        // ���� ��ǥ ������ ���� ī�޶��� ��ġ ����
        float cameraWidth = viewportMax.x - viewportMin.x;
        float cameraHeight = viewportMax.y - viewportMin.y;

        Vector3 newPosition = transform.position;

        // �� ��/�ƿ��� ���� ī�޶��� ��ġ ����
        newPosition.x = Mathf.Clamp(newPosition.x, minWorldBounds.x + cameraWidth / 2, maxWorldBounds.x - cameraWidth / 2);
        newPosition.y = Mathf.Clamp(newPosition.y, minWorldBounds.y + cameraHeight / 2, maxWorldBounds.y - cameraHeight / 2);

        transform.position = newPosition;
    }
}