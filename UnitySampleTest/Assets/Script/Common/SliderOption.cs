using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderOption : MonoBehaviour
{
    public Slider SliderObj;
    public InputField InputObj;

    private OptionData mOptionData;

    // Start is called before the first frame update
    void Start()
    {
        InputObj.onEndEdit.AddListener(InputEnd);
        SliderObj.onValueChanged.AddListener(UpdateValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetData(ref OptionData optionData)
    {
        mOptionData = optionData;
        SliderObj.value = (mOptionData.NowValue - mOptionData.MinValue) / (mOptionData.MaxValue - mOptionData.MinValue);
        InputObj.text = string.Format("{0:0.##}", mOptionData.NowValue);
    }


    public void InputEnd(string text)
    {
        float value = mOptionData.MinValue;
        try
        {
            value = float.Parse(text);
        }
        catch(Exception e)
        {
            value = mOptionData.MinValue;
        }

        if (value < mOptionData.MinValue)
            value = mOptionData.MinValue;
        if (value > mOptionData.MaxValue)
            value = mOptionData.MaxValue;

        mOptionData.SetNowValue(value);
        SliderObj.value = (mOptionData.NowValue - mOptionData.MinValue) / (mOptionData.MaxValue - mOptionData.MinValue);
        InputObj.text = value.ToString();
    }

    public void UpdateValue(float v)
    {
        float value = mOptionData.MinValue + ((mOptionData.MaxValue - mOptionData.MinValue) * v);
        InputObj.text = string.Format("{0:0.##}", value);
        mOptionData.SetNowValue(value);
        Debug.Log(value + " " + v);
    }
}
