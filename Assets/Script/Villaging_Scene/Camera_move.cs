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

    private void Start()
    {
        // ī�޶��� �ʱ� Z ��ġ ����
        initialCameraZ = transform.position.z;
    }

    private void Update()
    {
        // UI ������ �����Ͱ� ���� ���� UI �ۿ��� �������� ��츦 �����Ͽ� ó��
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                isPointerOverUI = true; // UI ������ Ŭ���� ���۵Ǿ����� ���
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isPointerOverUI = false; // ��ġ�� �������Ƿ� �÷��׸� �ʱ�ȭ
            isDragging = false; // �巡�� ���µ� �ʱ�ȭ
        }

        // UIManager�� �ǹ� ����â�� �������� ���� ���¿����� �巡�װ� �����ϵ���
        if (!GameManager.Inst.UI_Manager.isPopup_buildMenu)
        {
            Camera_Move(); // ��ġ�� �հ����� 1�� (ī�޶� ������)
        }
    }

    private void Camera_Move()
    {
        // UI ������ �巡�װ� ���۵Ǿ��� ���� �巡�� ������ ����
        if (isPointerOverUI && !isDragging)
        {
            return; // UI ������ �巡�װ� ���۵� ���, �巡�׸� ���� ����
        }

        // ��ġ�� ���۵� ��
        if (Input.GetMouseButtonDown(0) && !isPointerOverUI)
        {
            //Debug.Log("�Ѱ��� ��ġ ���� Ȯ��");
            previousMousePosition = Input.mousePosition; // ���� ���콺 ��ġ �ʱ�ȭ
            isDragging = true; // �巡�� ���� ���·� ����
        }

        // ��ġ�� ������ ��
        if (Input.GetMouseButton(0) && isDragging)
        {
            Vector2 currentMousePosition = Input.mousePosition; // ���� ���콺 ������
            Vector2 deltaPosition = currentMousePosition - previousMousePosition; // ���� ��ġ���� ���� ���

            // �������� ������ ���� �̻��� ���� �巡�׷� ����
            if (deltaPosition.magnitude > 0.1f)
            {
                Vector3 pos = Camera.main.ScreenToViewportPoint(-deltaPosition); // �巡�׿� ī�޶��� �̵������� ������ֱ� ����
                Vector3 move = pos * (Time.deltaTime * DragSpeed);

                transform.Translate(move);
                transform.position = new Vector3(transform.position.x, transform.position.y, initialCameraZ); // Z ��ġ ����
            }

            previousMousePosition = currentMousePosition; // ���� ��ġ�� ���� ��ġ�� ������Ʈ
        }
    }
}