using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipObj : MonoBehaviour
{
    public SpriteRenderer ChipImg;

    private Vector3 StartPos;
    private Vector3 EndPos;
    private float WaitTimeSec;
    private float WaitTimeSec_Save;

    [System.NonSerialized]
    public bool mIsMoveEnd = false;

    [System.NonSerialized]
    public ChipMoveScene.UpdateChipTower mUpdateChipTower;

    [System.NonSerialized]
    public ChipMoveManager.CHIP_TYPE mChipType;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetData(Vector3 startPos, Vector3 endPos, float waitSec, ChipMoveManager.CHIP_TYPE chipType, ChipMoveScene.UpdateChipTower updateChipTower)
    {
        StartPos = startPos;
        endPos.z = -0.1f;
        EndPos = endPos;
        WaitTimeSec = waitSec;
        WaitTimeSec_Save = 0;
        this.gameObject.SetActive(false);
        this.transform.localPosition = startPos;
        mIsMoveEnd = false;

        mUpdateChipTower = updateChipTower;
        mChipType = chipType;

        switch (chipType)
        {
            case ChipMoveManager.CHIP_TYPE.CHIP_1:
                ChipImg.sprite = Resources.Load("ChipsMoveScene/chip_1", typeof(Sprite)) as Sprite;
                break;
            case ChipMoveManager.CHIP_TYPE.CHIP_2:
                ChipImg.sprite = Resources.Load("ChipsMoveScene/chip_2", typeof(Sprite)) as Sprite;
                break;
            case ChipMoveManager.CHIP_TYPE.CHIP_3:
                ChipImg.sprite = Resources.Load("ChipsMoveScene/chip_3", typeof(Sprite)) as Sprite;
                break;
            case ChipMoveManager.CHIP_TYPE.CHIP_4:
                ChipImg.sprite = Resources.Load("ChipsMoveScene/chip_4", typeof(Sprite)) as Sprite;
                break;
            case ChipMoveManager.CHIP_TYPE.CHIP_5:
                ChipImg.sprite = Resources.Load("ChipsMoveScene/chip_5", typeof(Sprite)) as Sprite;
                break;
            default:
                break;
        }
    }

    public void UpdateMove()
    {
        WaitTimeSec_Save += Time.deltaTime;
        if (WaitTimeSec_Save > WaitTimeSec && mIsMoveEnd == false)
        {
            this.gameObject.SetActive(true);
            transform.position = Vector3.MoveTowards(gameObject.transform.position, EndPos, ChipMoveManager.Instance.ChipMoveSpeed.NowValue);
            //transform.position = Vector3.Lerp(gameObject.transform.position, EndPos, ChipMoveManager.Instance.ChipMoveSpeed);
        }

        if (mIsMoveEnd ==false && Vector3.Distance(transform.position, EndPos) <= 0.001f)
        {
            mIsMoveEnd = true;
            mUpdateChipTower((int)mChipType);
        }
    }
}
