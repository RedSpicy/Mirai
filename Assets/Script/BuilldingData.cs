using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilldingData : MonoBehaviour
{
    
    public GameObject prefab; // ���ƂȂ�Prefab
    private List<GameObject> prefabList = new List<GameObject>(); // �N���[�����Ǘ����郊�X�g

    public Vector3 scaleIncrease = new Vector3(1.0f, 1.0f, 1.0f); // �g��T�C�Y

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddBuillding()
    {
        prefabList.Add(prefab);
    }
}
