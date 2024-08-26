using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class Sprite_Layer_Sort : MonoBehaviour
{
    // SpriteRenderer 컴포넌트를 가진 게임 오브젝트들의 보여지는 정렬 기준을 center에서 pivot으로 변경합니다.
    [MenuItem("Yjh Menu/Change the sorting criteria of all game objects from center to pivot.")]
    static void Sorting_center_to_pivot()
    {
        // SpriteRenderer 컴포넌트 타입들을 여러개 담을 배열을 만든다.
        SpriteRenderer[] sr_array;

        // 씬 내에 존재하는 게임 오브젝트들 중, SpriteRenederer컴포넌트를 가진 오브젝트들의 spriteRenderer를 배열에 담는다.
        sr_array = GameObject.FindObjectsOfType<SpriteRenderer>();

        // for문을 sr_array의 크기만큼 돌린다.
        for(int i = 0; i < sr_array.Length; i++)
        {
            // 만약 배열 내의 spriteRenderer 컴포넌트 중, spriteSortPoint가 Center인 값을 Pivot으로 변경.
            if (sr_array[i].spriteSortPoint == SpriteSortPoint.Center)
                sr_array[i].spriteSortPoint = SpriteSortPoint.Pivot;
        }

    }

    // SpriteRenderer 컴포넌트를 가진 오브젝트들의 레이어와 이름을 디버깅합니다.
    [MenuItem("Yjh Menu/Object layer setup with Sprite Renderer component")]
    static void SpriteRenderer_Order_in_Layer()
    {
        SpriteRenderer[] sr;
        sr = GameObject.FindObjectsOfType<SpriteRenderer>();

        for(int i = 0; i < sr.Length; i++)
        {
            //sr[i].sortingOrder = 0;

            Debug.Log("오브젝트의 현재 레이어 : " + sr[i].sortingOrder + " / 해당 오브젝트의 이름 : " + sr[i].gameObject.name);
        }

    }



}
