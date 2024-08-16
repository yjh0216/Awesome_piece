using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour
{
    // 캐릭터가 이동할 목적지 입니다.
    private Vector2 target_Pos = Vector2.zero;

    // 캐릭터가 random_time(초) 동안 움직입니다.
    private float random_time = 0f;

    private void Start()
    {
        StartCoroutine("Random_move");

        //---------------SendMessage에 대해서---------------
        //if(gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer sr))
        //{
        //    //sr.SendMessage();
        //}

        //if (gameObject.TryGetComponent<Transform>(out Transform tr))
        //{
        //    tr.SendMessage
        //}

        //gameObject.SendMessage()

        //if (gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer sr))
        //{
        //    //sr.SendMessage();
        //}

        // 기존에는 게임 오브젝트가 어떤 컴포넌트의 기능을 실행하려면 게임오브젝트 - 컴포넌트 참조 - 컴포넌트 클래스의 객체에서 메소드 실행
        // 이었다면 SendMessage는 게임오브젝트 뒤에 SendMessage를 붙이고 메소드명을 문자열로 넣으면 (매개인자가 필요하면 매개변수도 전달 가능, 수신자 여부 결정)
        // 게임오브젝트가 가진 컴포넌트들 중에서 해당 문자열에 해당하는 메소드 실행 (같은 이름의 메소드를 모두 실행할지는 모름)

        //-------------------------------------------------
    }

    private IEnumerator Random_move()
    {
        yield return null;
        bool CanIMove = true;
        while(CanIMove)
        {
            //target_Pos = Screen.
        }

    }





}
