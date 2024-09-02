using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Camera_move : MonoBehaviour
{
    public float DragSpeed = 2000f;

    private Vector2 previousMousePosition; // ���� �������� ���콺 ��ġ
    private bool isDragging; // �巡�� ������ ����
    private float initialCameraZ; // �ʱ� ī�޶� Z ��ġ
    private bool isPointerOverUI; // UI ������ �巡�װ� ���۵Ǿ����� ����

    // ī�޶��� �̵� ������ �����ϱ� ���� ������ (���� ��ǥ)
    private Vector2 minWorldBounds = new Vector2(-8.05f, -14f); // ������ �ּ� ��ǥ (���� �ϴ�)
    private Vector2 maxWorldBounds = new Vector2(27.5f, 11.1f); // ������ �ִ� ��ǥ (������ ���)

    private void Start()
    {
        // ī�޶��� �ʱ� Z ��ġ ����
        initialCameraZ = transform.position.z;
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
                isPointerOverUI = true; // UI ������ Ŭ���� ���۵Ǿ����� ���
        }

        if (Input.GetMouseButtonUp(0))
        {
            isPointerOverUI = false; // ��ġ�� �������Ƿ� �÷��׸� �ʱ�ȭ
            isDragging = false; // �巡�� ���µ� �ʱ�ȭ
        }

        if (!GameManager.Inst.UI_Manager.isPopup_buildMenu)
        {
            Camera_Move(); // ��ġ�� �հ����� 1�� (ī�޶� ������)
        }
    }

    private void Camera_Move()
    {
        if (isPointerOverUI && !isDragging)
        {
            return; // UI ������ �巡�װ� ���۵� ���, �巡�׸� ���� ����
        }

        if (Input.GetMouseButtonDown(0) && !isPointerOverUI)
        {
            previousMousePosition = Input.mousePosition; // ���� ���콺 ��ġ �ʱ�ȭ
            isDragging = true; // �巡�� ���� ���·� ����
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            Vector2 currentMousePosition = Input.mousePosition; // ���� ���콺 ������
            Vector2 deltaPosition = currentMousePosition - previousMousePosition; // ���� ��ġ���� ���� ���

            if (deltaPosition.magnitude > 0.1f)
            {
                Vector3 pos = Camera.main.ScreenToViewportPoint(-deltaPosition); // �巡�׿� ī�޶��� �̵������� ������ֱ� ����
                Vector3 move = pos * (Time.deltaTime * DragSpeed);

                // ī�޶��� ���� ����Ʈ ���� ���
                Vector3 viewportMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, initialCameraZ));
                Vector3 viewportMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, initialCameraZ));

                // ī�޶��� ���ο� ��ġ ���
                Vector3 newPosition = transform.position + move;
                newPosition.z = initialCameraZ;

                // ����Ʈ�� ���� ��ǥ ũ��
                float viewportWidth = viewportMax.x - viewportMin.x;
                float viewportHeight = viewportMax.y - viewportMin.y;

                // ���� ��ǥ ������ ī�޶� ��ġ ����
                newPosition.x = Mathf.Clamp(newPosition.x, minWorldBounds.x + viewportWidth / 2, maxWorldBounds.x - viewportWidth / 2);
                newPosition.y = Mathf.Clamp(newPosition.y, minWorldBounds.y + viewportHeight / 2, maxWorldBounds.y - viewportHeight / 2);

                transform.position = newPosition;
            }

            previousMousePosition = currentMousePosition; // ���� ��ġ�� ���� ��ġ�� ������Ʈ
        }
    }
}
