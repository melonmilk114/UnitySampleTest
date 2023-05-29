using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionData
{
    public float NowValue
    {
        get;
        private set;
    }
    public float MaxValue;
    public float MinValue;

    public OptionData(float min, float max, float initValue = 0)
    {
        MinValue = min;
        MaxValue = max;
        if(initValue == 0)
            NowValue = MinValue;
        else
            NowValue = initValue;
    }

    public void SetNowValue(float value)
    {
        NowValue = value;
    }
}
