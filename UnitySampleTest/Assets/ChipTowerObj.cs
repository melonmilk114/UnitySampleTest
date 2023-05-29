using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipTowerObj : MonoBehaviour
{
    private int mIndex = 0; // ¿Œµ¶Ω∫∑Œ ¡¬æiπÂ¿ª ¡§«‘
    private ChipMoveManager.CHIP_TYPE mChipType = ChipMoveManager.CHIP_TYPE.CHIP_1;
    public SpriteRenderer mChipImg;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetData(ChipMoveManager.CHIP_TYPE chipType, float xPos, int index)
    {
        mIndex = index;
        switch (chipType)
        {
            case ChipMoveManager.CHIP_TYPE.CHIP_1:
                mChipImg.sprite = Resources.Load("ChipsMoveScene/chip_1_side", typeof(Sprite)) as Sprite;
                break;
            case ChipMoveManager.CHIP_TYPE.CHIP_2:
                mChipImg.sprite = Resources.Load("ChipsMoveScene/chip_2_side", typeof(Sprite)) as Sprite;
                break;
            case ChipMoveManager.CHIP_TYPE.CHIP_3:
                mChipImg.sprite = Resources.Load("ChipsMoveScene/chip_3_side", typeof(Sprite)) as Sprite;
                break;
            case ChipMoveManager.CHIP_TYPE.CHIP_4:
                mChipImg.sprite = Resources.Load("ChipsMoveScene/chip_4_side", typeof(Sprite)) as Sprite;
                break;
            case ChipMoveManager.CHIP_TYPE.CHIP_5:
                mChipImg.sprite = Resources.Load("ChipsMoveScene/chip_5_side", typeof(Sprite)) as Sprite;
                break;
            default:
                break;
        }

        this.transform.localPosition = new Vector3(xPos, 0.125f * mIndex, 0f);
    }
}
