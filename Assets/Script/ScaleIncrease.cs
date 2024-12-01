using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleIncrease : MonoBehaviour
{
    private bool isScaled = false;
    // �g��{��
    public Vector3 scaleIncrease = new Vector3(1.0f, 1.0f, 1.0f);
    // ���̃T�C�Y��ۑ�
    private Vector3 originalScale;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ScaleIncrease");
        // �����T�C�Y��ۑ�
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // ���N���b�N�����m
        if (Input.GetMouseButtonDown(0)) // 0: ���N���b�N
        {
            // �}�E�X�̈ʒu����Ray���΂�
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            // Ray�����������I�u�W�F�N�g�𔻒�
            if (Physics.Raycast(ray, out hit))
            {
                // ���̃X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g���N���b�N�����ꍇ
                if (hit.transform == transform)
                {
                    // �T�C�Y��؂�ւ���
                    if (!isScaled)
                    {
                        Debug.Log("off");
                        StartCoroutine(SmoothScale(originalScale + scaleIncrease));
                        Debug.Log("on");
                    }

                    isScaled = !isScaled; // ��Ԃ�؂�ւ���
                }
            }
        }
    }

    IEnumerator SmoothScale(Vector3 targetScale)
    {
        float duration = 0.5f; // �g��ɂ����鎞��
        Vector3 startScale = transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
    }
}
