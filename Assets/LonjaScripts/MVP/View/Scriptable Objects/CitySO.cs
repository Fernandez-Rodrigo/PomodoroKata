using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "City")]
public class CitySO : ScriptableObject, ICity
{
    [SerializeField]
    private float vieirasPrice;
    [SerializeField]
    private float centollaPrice;
    [SerializeField]
    private float pulpoPrice;
    [SerializeField]
    private float km;
    public float Km { get => km; }
    public float VieirasPrice { get => vieirasPrice; set => vieirasPrice = value; }
    public float CentollasPrice { get => centollaPrice; set => centollaPrice = value; }
    public float PulpoPrice { get => pulpoPrice; set => pulpoPrice = value; }

}
