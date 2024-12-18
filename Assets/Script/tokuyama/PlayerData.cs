using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public int nMoney = 777;  // �����̂���
    public int nScore = 0;  // ������Score
    public float nTime = 0;    //���ԊǗ�  ���v�Ƃ��\�����鎞�p
    //�X�e�[�W�Ǘ��p   �X�e�[�W�����W�x�̂���
    public int nCurrentStage = 0;  
    public int nMaxStage = 3;

    //�����ɂ��ĂƂ�����ꂽ����(�L������)�̂��߂ɗp�ӂ������
    //�����Ȃ�̂ł�������ŕ�����
    public int nSumMoney = 0;
    public float nCountFade = 0;    //�����x   
    private float nFadeSpeed = 0.006f;
    public bool bAppear=false;
    void Awake()
    {
        // �V���O���g��
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        nTime+=0.1f;


        // �f�o�b�O�p
        // �X�y�[�X�L�[�������ꂽ��X�R�A�𑝂₷
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nScore += 200; // �X�R�A��100���₷
        }

        if (bAppear)
        {
            nCountFade-=nFadeSpeed;

            if (nCountFade <= 0)
            {
                nMoney += nSumMoney;
                nSumMoney = 0;
                bAppear = false;
                nCountFade = 0; //����񂯂ǈꉞ
            }
        }
       
        
    }


    // �����𑝂₷���\�b�h
    public void AddMoney(int amount)
    {
        nSumMoney += amount;
        bAppear = true;
        nCountFade = 1;   //�����x   
    }

    public void AddScore(int amount)
    {
        nScore += amount;
    }
}
