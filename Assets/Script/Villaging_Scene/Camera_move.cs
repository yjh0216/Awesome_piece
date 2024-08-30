using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour
{
    private Vector2 ClickPoint;
    public float DragSpeed = 5f;

    private void Update()
    {
        Camera_Move(); // ��ġ�� �հ����� 1�� (ī�޶� ������)
    }

    private void Camera_Move()
    {
        //if (Input.touchCount == 1) // ��ġ�� �հ����� 1�� (ī�޶� ������)
        if (Input.GetMouseButtonDown(0)) // ��ġ�� �հ����� 1�� (ī�޶� ������)
        {
            Debug.Log("�Ѱ��� ��ġ ���� Ȯ��");

            ClickPoint = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint((Vector2)Input.mousePosition - ClickPoint);
            Vector3 move = pos * (Time.deltaTime * DragSpeed);

            float z = -10f;

            transform.Translate(move);
            transform.position = new Vector3(transform.position.x, transform.position.y, z);
        }
    }
}
