using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour
{
    private Vector2 ClickPoint;
    public float DragSpeed = 5f;

    private void Update()
    {
        Camera_Move(); // 터치된 손가락이 1개 (카메라 움직임)
    }

    private void Camera_Move()
    {
        //if (Input.touchCount == 1) // 터치된 손가락이 1개 (카메라 움직임)
        if (Input.GetMouseButtonDown(0)) // 터치된 손가락이 1개 (카메라 움직임)
        {
            Debug.Log("한개의 터치 지점 확인");

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
