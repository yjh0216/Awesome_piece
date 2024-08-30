using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    // ���� ��ũ. https://dooding.tistory.com/9
    [Header("Main Camera�� Projection�� Orthographic�� ���\n����/�ƿ� �ӵ�")]
    public float Camera_Orthographic_ZoomInOutSpeed = 0.5f; // ī�޶� Orthographic ��������϶� ����,�ܾƿ� �ӵ�.

    [Header("Main Camera�� Projection�� Perspective�� ���\n����/�ƿ� �ӵ�")]
    public float Camera_Perspective_ZoomInOutSpeed  = 0.5f; // ���ٸ���϶� Perspective

    private void Update()
    {
        if(Input.touchCount == 2)
        {
            // Touch ��� ����ü. Vector�� ������ ����?
            Touch touchZero = Input.GetTouch(0); // User�� �Էµ� ù��° �հ��� ���� ����.
            Touch touchOne  = Input.GetTouch(1); // �ι�° �հ��� ����.

            // ��ġ�� ���� ���� ��ġ���� ���� ����...
            // ó�� ��ġ�� ��ġ(touchZero.position)���� ���� �����ӿ����� ��ġ ��ġ�� �̹� �����ӿ��� ��ġ ��ġ�� ���̸� ����?
            // �Ʒ��� �� ���ʹ� ����� ���� ���� ����...
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition; // <- deltaPosition�� �̵����� �����Ҷ� ���?
            Vector2 touchOnePrevPos  = touchOne.position  - touchOne.deltaPosition;

            // �� �����ӿ��� ��ġ ������ ���� �Ÿ��� ���Ѵ�.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude; // Vector2.magnitude ������ ���� ������ ���� ����/�Ÿ�
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // �Ÿ� ���̸� ���Ѵ�. (�Ÿ��� �������� ũ��(���̳ʽ��� ������)�հ����� ���� ����_���� ����)...
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag; // DeltaMag ������ -����

            // +���� ī�޶� Orthographic ������ ���
            if(Camera.main.orthographic == false) // <- orthographic�̶�� ��. true�� ��� perspective
            {
                Camera.main.orthographicSize += deltaMagnitudeDiff * Camera_Orthographic_ZoomInOutSpeed;
                Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 0.1f);
            }
            else
            {
                // ī�޶� ��尡 Perspective�� ��� ����� ����.
                //Camera.main.fieldOfView += deltaMagnitudeDiff * Camera_Perspective_ZoomInOutSpeed;
                //Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 0.1f, 179.9f);
            }
        }
    }
}
