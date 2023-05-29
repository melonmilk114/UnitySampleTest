using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardMoveScene : MonoBehaviour
{
    public GameObject mDealerObj;
    public List<GameObject> mUserObjList = new List<GameObject>();

    public GameObject mCardObjRoot;
    private List<CardObj> mCardObjList = new List<CardObj>();

    public Button BackButton;
    public Button SettingButton;
    public Button StartButton;

    public GameObject SettingObj;
    public Button SettingCloseButton;

    public SliderOption SpeedOption;
    public SliderOption CreateWaitOption;

    private void Awake()
    {
        StartButton.onClick.AddListener(() =>
        {
            CardMoveStart();
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

        SpeedOption.SetData(ref CardMoveManager.Instance.CardSpeed);
        CreateWaitOption.SetData(ref CardMoveManager.Instance.CardCreateWaitTime);
    }

    private void Start()
    {
        StartCoroutine(Co_UpdateMove());
    }

    public void CardMoveStart()
    {
        for (int i = 0; i < mCardObjList.Count; i++)
        {
            DestroyImmediate(mCardObjList[i].gameObject);
        }
        mCardObjList.Clear();


        var dealerPos = mDealerObj.transform.position;
        float createWaitTime = 0;

        for (int i = 0; i < mUserObjList.Count; i++)
        {
            if (mUserObjList[i].activeSelf)
            {
                for (int k = 0; k < 2; k++)
                {
                    var slotObj = Instantiate(Resources.Load("CardMoveScene/CardObj"), mCardObjRoot.transform) as GameObject;
                    var slot = slotObj.GetComponent<CardObj>();
                    slot.SetData(dealerPos, mUserObjList[i].transform.position, k, createWaitTime + (k * 0.1f));
                    mCardObjList.Add(slot);
                    slot.gameObject.SetActive(false);
                }

                createWaitTime += CardMoveManager.Instance.CardCreateWaitTime.NowValue;
            }
        }
    }

    public IEnumerator Co_UpdateMove()
    {
        while (true)
        {
            for (int i = 0; i < mCardObjList.Count; i++)
            {
                mCardObjList[i].UpdateMove();
            }

            yield return null;
        }
    }

}

