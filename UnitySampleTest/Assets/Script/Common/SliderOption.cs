using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderOption : MonoBehaviour
{
    public delegate void OnValueChange(float value);
    private OnValueChange onValueChange = null;

    public Slider SliderObj;
    public InputField InputObj;

    private float MaxValue = 1;
    private float MinValue = 0;

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

    public void SetData(float minValue, float maxValue, float initValue, OnValueChange dOnValueChange)
    {
        MaxValue = maxValue;
        MinValue = minValue;
        SliderObj.value = initValue;
        onValueChange = dOnValueChange;
        InputObj.text = string.Format("{0:0.##}", initValue);
    }


    public void InputEnd(string text)
    {
        float value = MinValue;
        try
        {
            value = float.Parse(text);
        }
        catch(Exception e)
        {
            value = MinValue;
        }

        if (value < MinValue)
            value = MinValue;
        if (value > MaxValue)
            value = MaxValue;

        SliderObj.value = (value - MinValue) / (MaxValue - MinValue);
        InputObj.text = value.ToString();

    }

    public void UpdateValue(float v)
    {
        float value = MinValue + ((MaxValue - MinValue) * v);
        InputObj.text = string.Format("{0:0.##}", value);
        onValueChange(value);
        Debug.Log(value + " " + v);
    }
}
