using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipMoveManager : MonoBehaviour
{
    public static ChipMoveManager _instance = null;
    public static ChipMoveManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ChipMoveManager>() as ChipMoveManager;
            }
            return _instance;
        }
    }


    public enum CHIP_TYPE
    {
        CHIP_1 = 1,
        CHIP_2 = 10,
        CHIP_3 = 100,
        CHIP_4 = 1000,
        CHIP_5 = 10000,
    }

    public OptionData ChipMoveSpeed = new OptionData(0.01f, 1f, 0.3f);
    public OptionData ChipCreateWaitTime = new OptionData(0.01f, 1f, 0.5f);
    public OptionData ChipMoveArea_X = new OptionData(1f, 5f, 3f);
    public OptionData ChipMoveArea_Y = new OptionData(1f, 3f, 2f);
    public OptionData BettingValue = new OptionData(1f, 10000f, 4325f);

    public float ChipMoveArea_Center_X = 0;
    public float ChipMoveArea_Center_Y = 0;

    private void Start()
    {
        // 씬이 변경 할때마다 파괴 할예정이기 때문에 굳이 하지 않는다
        //DontDestroyOnLoad(this);
    }
}
