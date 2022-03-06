using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barcelona : MonoBehaviour, ICity
{
    private float vieirasPrice;
    private float centollaPrice;
    private float pulpoPrice;
    public float VieirasPrice { get => 450; set => vieirasPrice = value; }
    public float CentollasPrice { get => 0; set => centollaPrice = value; }
    public float PulpoPrice { get => 120 ; set => pulpoPrice = value; }

    public float km => 1100;

    public void SetVieriasPrice(float price)
    {
        vieirasPrice = price;
    }
}
