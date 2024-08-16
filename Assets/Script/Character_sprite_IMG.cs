using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 캐릭터가 바라보는 방향에 따라 sprite image를 가지고 있다가 필요할때 외부에서 가져다 쓸 용도의 스크립트.
public class Character_sprite_IMG : MonoBehaviour
{
    [Header("캐릭터가 가질 이미지들 모두 넣기")]
    [SerializeField] public Sprite[] texture_sprite;

    private void Update()
    {
        //----------------------------------- Test_"A키를 눌러 가지고 있는 Sprite를 변경하기"
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
