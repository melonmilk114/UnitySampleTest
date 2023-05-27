using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardMoveScene : MonoBehaviour
{
    public GameObject DealerObj;
    public List<GameObject> UserObjList = new List<GameObject>();

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
            CardMoveManager.Instance.CardMoveStart(DealerObj, UserObjList);
        });

        SettingCloseButton.onClick.AddListener(() =>
        {
            SettingObj.gameObject.SetActive(false);
        });

        SettingButton.onClick.AddListener(() =>
        {
            SettingObj.gameObject.SetActive(true);
        });



        SpeedOption.SetData(CardMoveManager.CardSpeedMin, CardMoveManager.CardSpeedMax, CardMoveManager.CardSpeedMin, CardMoveManager.Instance.SetCardSpeed);
        CreateWaitOption.SetData(CardMoveManager.CardCreateWaitTimeMin, CardMoveManager.CardCreateWaitTimeMax, CardMoveManager.CardCreateWaitTimeMin, CardMoveManager.Instance.SetCreateWaitTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
