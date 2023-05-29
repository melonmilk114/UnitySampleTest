using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipTower : MonoBehaviour
{
    private int mChipValue = 0; // 현재 칩
    private List<ChipTowerObj> mMiniChipTowerObj = new List<ChipTowerObj>(); // 칩 오브젝트 리스트

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ResetValue()
    {
        mChipValue = 0;

        for (int i = 0; i < mMiniChipTowerObj.Count; i++)
        {
            DestroyImmediate(mMiniChipTowerObj[i].gameObject);
        }
        mMiniChipTowerObj.Clear();
    }

    public void SetData(int value)
    {
        mChipValue += value;
        // 칩타워 전부 제거
        for (int i = 0; i < mMiniChipTowerObj.Count; i++)
        {
            DestroyImmediate(mMiniChipTowerObj[i].gameObject);
        }
        mMiniChipTowerObj.Clear();

        CreateMiniChip(mChipValue, ChipMoveManager.CHIP_TYPE.CHIP_1);
        CreateMiniChip(mChipValue, ChipMoveManager.CHIP_TYPE.CHIP_2);
        CreateMiniChip(mChipValue, ChipMoveManager.CHIP_TYPE.CHIP_3);
        CreateMiniChip(mChipValue, ChipMoveManager.CHIP_TYPE.CHIP_4);
        CreateMiniChip(mChipValue, ChipMoveManager.CHIP_TYPE.CHIP_5);
    }

    public void CreateMiniChip(int value, ChipMoveManager.CHIP_TYPE divideValue)
    {
        int tempValue = value / (int)divideValue;
        tempValue %= 10;

        for (int i = 0; i < tempValue; i++)
        {
            var slotObj = Instantiate(Resources.Load("ChipsMoveScene/ChipTowerObj"), this.transform) as GameObject;
            var slot = slotObj.GetComponent<ChipTowerObj>();

            switch (divideValue)
            {
                case ChipMoveManager.CHIP_TYPE.CHIP_1:
                    slot.SetData(divideValue, -1.6f, i);
                    break;
                case ChipMoveManager.CHIP_TYPE.CHIP_2:
                    slot.SetData(divideValue, -0.8f, i);
                    break;
                case ChipMoveManager.CHIP_TYPE.CHIP_3:
                    slot.SetData(divideValue, 0, i);
                    break;
                case ChipMoveManager.CHIP_TYPE.CHIP_4:
                    slot.SetData(divideValue, 0.8f, i);
                    break;
                case ChipMoveManager.CHIP_TYPE.CHIP_5:
                    slot.SetData(divideValue, 1.6f, i);
                    break;
                default:
                    break;
            }
            mMiniChipTowerObj.Add(slot);
        }
    }

}
