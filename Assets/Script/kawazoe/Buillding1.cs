using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buillding1 : MonoBehaviour
{
    public GameObject buildingPrefab;       // ���݂��錚����Prefab
    public GameObject displayObject;        // ���z��ɕ\������I�u�W�F�N�g�i�q�I�u�W�F�N�g�j
    private bool isConstructed = false;     // ���������ݍς݂��ǂ���

    void Start()
    {
        if (displayObject != null)
        {
            displayObject.SetActive(false);
        }
    }

    void Update()
    {
        // score�����ɒB�����ꍇ
        if (PlayerData.Instance.nScore >= 1000 && !isConstructed)
        {
            // z���W�����Ɋp�x���v�Z
            float zPosition = transform.position.z;
            float rotationY = CalculateRotationAngle(zPosition);

            // �����𐶐�
            Instantiate(buildingPrefab, transform.position, Quaternion.Euler(0, rotationY, 0));

            // �\���I�u�W�F�N�g��L����
            if (displayObject != null)
            {
                displayObject.SetActive(true);
            }

            //Destroy(gameObject);

            isConstructed = true;

            //ConstructBuilding();
            Debug.Log("���z���܂��I");
        }

    }

    private void ConstructBuilding()
    {
        if (buildingPrefab != null)
        {
            // ���݂̋󂫒n�̈ʒu�Ɍ�����ݒu
            Instantiate(buildingPrefab, transform.position, Quaternion.identity);

            Debug.Log("!!!!!");
            // �󂫒n��GameObject���폜
            Destroy(gameObject);

            isConstructed = true;
        }
    }

    // z���W�ɉ�������]�p�x���v�Z����֐�
    private float CalculateRotationAngle(float zPosition)
    {
        // �Ⴆ�΁Az�����̒l�ŉE�����A���̒l�ō������ɂ���ꍇ
        if (zPosition > 0)
        {
            Debug.Log("�E�����܂��I");
            return 180f; // �E����
        }
        else
        {
            Debug.Log("�������܂��I");
            return 0f; // ���ʌ���

        }
    }
}