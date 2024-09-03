using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSelector : MonoBehaviour
{
    [System.Serializable]
    public class SpriteToPrefab
    {
        public Sprite sprite; // ��ư �̹���
        public GameObject prefab; // �����ϴ� ������
    }

    public List<SpriteToPrefab> spriteToPrefabs; // �̹����� �������� ����Ʈ
    private GameObject currentPrefabInstance; // ���� ������ ������ �ν��Ͻ�

    // ��������Ʈ�� ���� ������ ����
    public void SpawnPrefabBasedOnButton(Sprite buttonSprite)
    {
        // ������ ������ �������� �ִٸ� ����
        if (currentPrefabInstance != null)
        {
            Destroy(currentPrefabInstance);
        }

        foreach (var item in spriteToPrefabs)
        {
            if (item.sprite == buttonSprite)
            {
                // ���콺�� ����ٴϴ� ������ ����
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
            // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f; // ī�޶󿡼� ������ �Ÿ�
            currentPrefabInstance.transform.position = Camera.main.ScreenToWorldPoint(mousePos);

            yield return null;
        }
    }
}
