using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billding : MonoBehaviour
{
    public GameObject buildingPrefab;       // ���݂��錚����Prefab
    private bool isConstructed = false;     // ���������ݍς݂��ǂ���

    private void Update()
    {
        // ��score�������I�ɖ������߁AE�L�[�ő�p

        // E�L�[��������A�������܂����݂���Ă��Ȃ��ꍇ
        if (Input.GetKeyDown(KeyCode.E) && !isConstructed)
        {
            ConstructBuilding();
        }
    }

    private void ConstructBuilding()
    {
        if (buildingPrefab != null)
        {
            // ���݂̋󂫒n�̈ʒu�Ɍ�����ݒu
            Instantiate(buildingPrefab, transform.position, Quaternion.identity);

            // �󂫒n��GameObject���폜
            Destroy(gameObject);

            isConstructed = true;
        }
    }
}