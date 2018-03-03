using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stat
{

    private barScript bar;

    private float maxVal;

    private float currentVal;

    public float CurrentVal
    {
        get
        {
            return currentVal;
        }

        set
        {

            this.currentVal = value;
            bar.Value = currentVal;
        }
    }

    public float MaxVal
    {
        get
        {
            return MaxVal;
        }

        set
        {
            this.MaxVal = value;
            bar.MaxValue = maxVal;
        }
    }
}

