using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChipMoveScene : MonoBehaviour
{
    public delegate void UpdateChipTower(int plusValue);

    public List<GameObject> mUserObjList = new List<GameObject>();
    public ChipTower mChipTower;

    public GameObject mChipObjRoot;
    private List<ChipObj> mChipObjList = new List<ChipObj>();


    public Button BackButton;
    public Button SettingButton;
    public Button StartButton;

    public GameObject SettingObj;
    public Button SettingCloseButton;

    public SliderOption SpeedOption;
    public SliderOption CreateWaitOption;
    public SliderOption AreaXOption;
    public SliderOption AreaYOption;
    public SliderOption BettingValueOption;

    private void Awake()
    {
        StartButton.onClick.AddListener(() =>
        {
            CreateMoveChip();
        });

        SettingCloseButton.onClick.AddListener(() =>
        {
            SettingObj.gameObject.SetActive(false);
        });

        SettingButton.onClick.AddListener(() =>
        {
            SettingObj.gameObject.SetActive(true);
        });

        BackButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainScene");
        });

        SpeedOption.SetData(ref ChipMoveManager.Instance.ChipMoveSpeed);
        CreateWaitOption.SetData(ref ChipMoveManager.Instance.ChipCreateWaitTime);
        AreaXOption.SetData(ref ChipMoveManager.Instance.ChipMoveArea_X);
        AreaYOption.SetData(ref ChipMoveManager.Instance.ChipMoveArea_Y);
        AreaYOption.SetData(ref ChipMoveManager.Instance.ChipMoveArea_Y);
        BettingValueOption.SetData(ref ChipMoveManager.Instance.BettingValue);
        
    }

    private void Start()
    {
        StartCoroutine(Co_UpdateMove());
    }

    public void CreateMoveChip()
    {
        mChipTower.ResetValue();
        for (int i = 0; i < mChipObjList.Count; i++)
        {
            DestroyImmediate(mChipObjList[i].gameObject);
        }
        mChipObjList.Clear();

        for (int i = 0; i < mUserObjList.Count; i++)
        {
            int betValue = (int)ChipMoveManager.Instance.BettingValue.NowValue;
            if (mUserObjList[i].activeSelf)
            {
                CreateChip(betValue, i, ChipMoveManager.CHIP_TYPE.CHIP_1);
                CreateChip(betValue, i, ChipMoveManager.CHIP_TYPE.CHIP_2);
                CreateChip(betValue, i, ChipMoveManager.CHIP_TYPE.CHIP_3);
                CreateChip(betValue, i, ChipMoveManager.CHIP_TYPE.CHIP_4);
                CreateChip(betValue, i, ChipMoveManager.CHIP_TYPE.CHIP_5);
            }
        }
    }

    public void CreateChip(int value, int index, ChipMoveManager.CHIP_TYPE divideValue)
    {
        int tempValue = value / (int)divideValue;
        tempValue %= 10;

        for (int i = 0; i < tempValue; i++)
        {
            Vector3 endPos = GetRandomPos();

            var slotObj = Instantiate(Resources.Load("ChipsMoveScene/ChipObj"), mChipObjRoot.transform) as GameObject;
            var slot = slotObj.GetComponent<ChipObj>();
            slot.SetData(mUserObjList[index].transform.position, endPos, ChipMoveManager.Instance.ChipCreateWaitTime.NowValue * index, divideValue, UpdateChipTowerFunc);
            mChipObjList.Add(slot);
            slot.gameObject.SetActive(false);
        }
    }

    public Vector3 GetRandomPos()
    {
        Vector3 returnPos;
        
        float x = Random.Range(
            ChipMoveManager.Instance.ChipMoveArea_Center_X - ChipMoveManager.Instance.ChipMoveArea_X.NowValue / 2,
            ChipMoveManager.Instance.ChipMoveArea_Center_X + ChipMoveManager.Instance.ChipMoveArea_X.NowValue / 2);
        float y = Random.Range(
            ChipMoveManager.Instance.ChipMoveArea_Center_Y - ChipMoveManager.Instance.ChipMoveArea_Y.NowValue / 2,
            ChipMoveManager.Instance.ChipMoveArea_Center_Y + ChipMoveManager.Instance.ChipMoveArea_Y.NowValue / 2);
        
        returnPos = new Vector2(x, y);
        
        return returnPos;
    }

    public void UpdateChipTowerFunc(int plusValue)
    {
        mChipTower.SetData(plusValue);
    }

    public IEnumerator Co_UpdateMove()
    {
        while(true)
        {
            for (int i = 0; i < mChipObjList.Count; i++)
            {
                mChipObjList[i].UpdateMove();
            }

            yield return null;
        }
    }
}
