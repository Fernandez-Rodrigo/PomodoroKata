using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barcelona : MonoBehaviour, ICity
{
    private float vieirasPrice;
    private float centollaPrice;
    private float pulpoPrice;
    public float VieirasPrice { get => vieirasPrice; set => vieirasPrice = value; }
    public float CentollasPrice { get => centollaPrice; set => centollaPrice = value; }
    public float PulpoPrice { get => pulpoPrice; set => pulpoPrice = value; }
    public float km => 1100;

    private void Awake()
    { //TODO: intentar sacar monob y poner un constructor
        vieirasPrice = 450;
        centollaPrice = 0;
        pulpoPrice = 120;
    } 


}
