using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour
{
    // ĳ���Ͱ� �̵��� ������ �Դϴ�.
    private Vector2 target_Pos = Vector2.zero;

    // ĳ���Ͱ� random_time(��) ���� �����Դϴ�.
    private float random_time = 0f;

    private void Start()
    {
        StartCoroutine("Random_move");

        //---------------SendMessage�� ���ؼ�---------------
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

        // �������� ���� ������Ʈ�� � ������Ʈ�� ����� �����Ϸ��� ���ӿ�����Ʈ - ������Ʈ ���� - ������Ʈ Ŭ������ ��ü���� �޼ҵ� ����
        // �̾��ٸ� SendMessage�� ���ӿ�����Ʈ �ڿ� SendMessage�� ���̰� �޼ҵ���� ���ڿ��� ������ (�Ű����ڰ� �ʿ��ϸ� �Ű������� ���� ����, ������ ���� ����)
        // ���ӿ�����Ʈ�� ���� ������Ʈ�� �߿��� �ش� ���ڿ��� �ش��ϴ� �޼ҵ� ���� (���� �̸��� �޼ҵ带 ��� ���������� ��)

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
