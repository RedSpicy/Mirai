using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buillding2 : MonoBehaviour
{
    public GameObject buildingPrefab;       // 建設する建物のPrefab
    public GameObject displayObject;        // 建築後に表示するオブジェクト（子オブジェクト）
    private bool isConstructed = false;     // 建物が建設済みかどうか

    void Start()
    {
        if (displayObject != null)
        {
            displayObject.SetActive(false);
        }
    }

    private void Update()
    {
        // scoreが一定に達した場合
        if (PlayerData.Instance.nScore >= 2000 && !isConstructed)
        {
            // z座標を元に角度を計算
            float zPosition = transform.position.z;
            float rotationY = CalculateRotationAngle(zPosition);

            // 建物を生成
            Instantiate(buildingPrefab, transform.position, Quaternion.Euler(0, rotationY, 0));

            // 表示オブジェクトを有効化
            if (displayObject != null)
            {
                displayObject.SetActive(true);
            }


            //Destroy(gameObject);

            isConstructed = true;

            //ConstructBuilding();
            Debug.Log("建築します！");
        }
    }

    private void ConstructBuilding()
    {
        if (buildingPrefab != null)
        {
            // 現在の空き地の位置に建物を設置
            Instantiate(buildingPrefab, transform.position, Quaternion.identity);

            // 空き地のGameObjectを削除
            Destroy(gameObject);

            isConstructed = true;
        }
    }

    // z座標に応じた回転角度を計算する関数
    private float CalculateRotationAngle(float zPosition)
    {
        // 例えば、zが正の値で右向き、負の値で左向きにする場合
        if (zPosition > 0)
        {
            Debug.Log("右向きます！");
            return 180f; // 右向き
        }
        else
        {
            Debug.Log("左向きます！");
            return 0f; // 正面向き

        }
    }
}