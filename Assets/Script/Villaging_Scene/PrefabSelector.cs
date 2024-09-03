using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSelector : MonoBehaviour
{
    [System.Serializable]
    public class SpriteToPrefab
    {
        public Sprite sprite; // 버튼 이미지
        public GameObject prefab; // 대응하는 프리팹
    }

    public List<SpriteToPrefab> spriteToPrefabs; // 이미지와 프리팹의 리스트
    private GameObject currentPrefabInstance; // 현재 생성된 프리팹 인스턴스

    // 스프라이트에 따라 프리팹 생성
    public void SpawnPrefabBasedOnButton(Sprite buttonSprite)
    {
        // 이전에 생성된 프리팹이 있다면 삭제
        if (currentPrefabInstance != null)
        {
            Destroy(currentPrefabInstance);
        }

        foreach (var item in spriteToPrefabs)
        {
            if (item.sprite == buttonSprite)
            {
                // 마우스를 따라다니는 프리팹 생성
                currentPrefabInstance = Instantiate(item.prefab);
                StartCoroutine(FollowMouse());
                break;
            }
        }
    }

    private IEnumerator FollowMouse()
    {
        while (currentPrefabInstance != null)
        {
            // 마우스 위치를 월드 좌표로 변환
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f; // 카메라에서 떨어진 거리
            currentPrefabInstance.transform.position = Camera.main.ScreenToWorldPoint(mousePos);

            yield return null;
        }
    }
}
