using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lisboa : MonoBehaviour, ICity
{
    private float vieirasPrice;
    private float centollaPrice;
    private float pulpoPrice;
    public float VieirasPrice { get => 600; set => vieirasPrice = value; }
    public float CentollasPrice { get => 500; set => centollaPrice = value; }
    public float PulpoPrice { get => 100; set => pulpoPrice = value; }

    public float km => 600;
    public void SetVieriasPrice(float price)
    {
        vieirasPrice = price;
    }
}
