using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ĳ���Ͱ� �ٶ󺸴� ���⿡ ���� sprite image�� ������ �ִٰ� �ʿ��Ҷ� �ܺο��� ������ �� �뵵�� ��ũ��Ʈ.
public class Character_sprite_IMG : MonoBehaviour
{
    [Header("ĳ���Ͱ� ���� �̹����� ��� �ֱ�")]
    [SerializeField] public Sprite[] texture_sprite;

    private void Update()
    {
        //----------------------------------- Test_"AŰ�� ���� ������ �ִ� Sprite�� �����ϱ�"
        //if(Input.GetKeyDown(KeyCode.A))
        //{
        //    if(gameObject.transform.GetChild(0).gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer sr))
        //    {
        //        int random_Index = Random.Range(0, texture_sprite.Length);
        //        sr.sprite = texture_sprite[random_Index];

        //        Debug.Log(random_Index);
        //    }
        //}
        //-----------------------------------------------------------------------------------
    }


}
