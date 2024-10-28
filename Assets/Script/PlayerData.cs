using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public int money = 777;  // �����̂���

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

    // �����𑝂₷���\�b�h
    public void AddMoney(int amount)
    {
        money += amount;
        Debug.Log("Current Money: " + money);  
    }
}
