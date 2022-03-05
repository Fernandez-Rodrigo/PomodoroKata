using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Madrid : ICity
{
    public float vieirasPrice { get => 5; set => SetValue(2); }
    public float centollasPrice { get => 5 ; set => SetValue(2); }
    public float pulpoPrice { get => 10 ; set => SetValue(2); }
    public float km { get => 5  ; set => SetValue(2); }


    public float SetValue(float value)
    {
        return value;
    }
}
