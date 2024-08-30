using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    // 참고 링크. https://dooding.tistory.com/9
    [Header("Main Camera의 Projection이 Orthographic일 경우\n줌인/아웃 속도")]
    public float Camera_Orthographic_ZoomInOutSpeed = 0.5f; // 카메라가 Orthographic 직교모드일때 줌인,줌아웃 속도.

    [Header("Main Camera의 Projection이 Perspective일 경우\n줌인/아웃 속도")]
    public float Camera_Perspective_ZoomInOutSpeed  = 0.5f; // 원근모드일땐 Perspective

    private void Update()
    {
        if(Input.touchCount == 2)
        {
            // Touch 라는 구조체. Vector와 유사한 구조?
            Touch touchZero = Input.GetTouch(0); // User의 입력된 첫번째 손가락 정보 저장.
            Touch touchOne  = Input.GetTouch(1); // 두번째 손가락 저장.

            // 터치에 대한 이전 위치값을 각각 저장...
            // 처음 터치한 위치(touchZero.position)에서 이전 프레임에서의 터치 위치와 이번 프레임에서 터치 위치의 차이를 뺀다?
            // 아래의 두 벡터는 방향과 힘을 가진 벡터...
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition; // <- deltaPosition은 이동방향 추적할때 사용?
            Vector2 touchOnePrevPos  = touchOne.position  - touchOne.deltaPosition;

            // 각 프레임에서 터치 사이의 벡터 거리를 구한다.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude; // Vector2.magnitude 벡터의 힘을 제외한 순수 길이/거리
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // 거리 차이를 구한다. (거리가 이전보다 크면(마이너스가 나오면)손가락을 벌린 상태_줌인 상태)...
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag; // DeltaMag 끼리의 -연산

            // +만약 카메라가 Orthographic 직교인 경우
            if(Camera.main.orthographic == false) // <- orthographic이라고 함. true인 경우 perspective
            {
                Camera.main.orthographicSize += deltaMagnitudeDiff * Camera_Orthographic_ZoomInOutSpeed;
                Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 0.1f);
            }
            else
            {
                // 카메라 모드가 Perspective인 경우 실행될 공간.
                //Camera.main.fieldOfView += deltaMagnitudeDiff * Camera_Perspective_ZoomInOutSpeed;
                //Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 0.1f, 179.9f);
            }
        }
    }
}
