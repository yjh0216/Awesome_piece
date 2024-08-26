using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class Sprite_Layer_Sort : MonoBehaviour
{
    // SpriteRenderer ������Ʈ�� ���� ���� ������Ʈ���� �������� ���� ������ center���� pivot���� �����մϴ�.
    [MenuItem("Yjh Menu/Change the sorting criteria of all game objects from center to pivot.")]
    static void Sorting_center_to_pivot()
    {
        // SpriteRenderer ������Ʈ Ÿ�Ե��� ������ ���� �迭�� �����.
        SpriteRenderer[] sr_array;

        // �� ���� �����ϴ� ���� ������Ʈ�� ��, SpriteRenederer������Ʈ�� ���� ������Ʈ���� spriteRenderer�� �迭�� ��´�.
        sr_array = GameObject.FindObjectsOfType<SpriteRenderer>();

        // for���� sr_array�� ũ�⸸ŭ ������.
        for(int i = 0; i < sr_array.Length; i++)
        {
            // ���� �迭 ���� spriteRenderer ������Ʈ ��, spriteSortPoint�� Center�� ���� Pivot���� ����.
            if (sr_array[i].spriteSortPoint == SpriteSortPoint.Center)
                sr_array[i].spriteSortPoint = SpriteSortPoint.Pivot;
        }

    }

    // SpriteRenderer ������Ʈ�� ���� ������Ʈ���� ���̾�� �̸��� ������մϴ�.
    [MenuItem("Yjh Menu/Object layer setup with Sprite Renderer component")]
    static void SpriteRenderer_Order_in_Layer()
    {
        SpriteRenderer[] sr;
        sr = GameObject.FindObjectsOfType<SpriteRenderer>();

        for(int i = 0; i < sr.Length; i++)
        {
            //sr[i].sortingOrder = 0;

            Debug.Log("������Ʈ�� ���� ���̾� : " + sr[i].sortingOrder + " / �ش� ������Ʈ�� �̸� : " + sr[i].gameObject.name);
        }

    }



}
