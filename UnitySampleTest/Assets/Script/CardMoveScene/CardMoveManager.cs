using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMoveManager : MonoBehaviour
{
    public static CardMoveManager _instance = null;
    public static CardMoveManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CardMoveManager>() as CardMoveManager;
            }
            return _instance;
        }
    }

    public OptionData CardSpeed = new OptionData(0.01f, 1f, 0.3f);
    public OptionData CardCreateWaitTime = new OptionData(0.1f, 1f, 0.3f);

    void Start()
    {
        // ���� ���� �Ҷ����� �ı� �ҿ����̱� ������ ���� ���� �ʴ´�
        //DontDestroyOnLoad(this);
    }
    
    

    // Update is called once per frame
    void Update()
    {
    }
}
