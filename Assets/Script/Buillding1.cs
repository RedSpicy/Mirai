using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buillding1 : MonoBehaviour
{
    public GameObject buildingPrefab;       // ���݂��錚����Prefab
    private bool isConstructed = false;     // ���������ݍς݂��ǂ���
    private int Score = PlayerData.Instance.nScore;

    private GameObject ManageData;
    private BuilldingData builldingData;

    void Start()
    {
        ManageData = GameObject.Find("ManageData");
        builldingData = ManageData.GetComponent<BuilldingData>();
    }

    void Update()
    {
        // score�����ɒB�����ꍇ
        if (PlayerData.Instance.nMoney > 1000 && !isConstructed)
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
            // ���X�g�ɓo�^
            builldingData.AddBuillding();

            // �󂫒n��GameObject���폜
            Destroy(gameObject);

            isConstructed = true;
        }
    }

}