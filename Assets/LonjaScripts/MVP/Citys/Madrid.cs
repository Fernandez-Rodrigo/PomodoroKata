using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Madrid : MonoBehaviour, ICity
{
    private float vieirasPrice;
    private float centollaPrice;
    private float pulpoPrice;
    public float VieirasPrice { get => 500; set => vieirasPrice = value; }
    public float CentollasPrice { get => 450 ; set => centollaPrice = value; }
    public float PulpoPrice { get => 0 ; set => pulpoPrice = value; }
    public float km { get => 800; }

    public void SetVieriasPrice(float price)
    {
        vieirasPrice = price;
    }
}
