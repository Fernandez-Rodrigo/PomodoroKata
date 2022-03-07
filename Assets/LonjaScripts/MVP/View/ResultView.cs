using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultView : MonoBehaviour, ISaleView, ICostView, ITotalEarningView
{
    [SerializeField]
    private InputField vieiraPriceField;
    [SerializeField]
    private InputField centollaPriceField;
    [SerializeField]
    private InputField pulpoPriceField;
    [SerializeField]
    private TextMeshProUGUI resultText;
    [SerializeField]
    private CitySO city;
    TotalEarnPresenter _totalEarningPresenter;

    void Start()
    {
        _totalEarningPresenter = new TotalEarnPresenter(this);
        SetInitialValues(); // Agregado
      
    }

    public string GetVieiraPrice() {
        return vieiraPriceField.text;
    }
    public string GetCentollaPrice() {
        return centollaPriceField.text;
    }
    public string GetPulpoPrice() {
        return pulpoPriceField.text;
    }
    public void SetVieiraPrice(string str)
    {
        vieiraPriceField.text = str;
    }
    public void SetCentollaPrice(string str)
    {
        centollaPriceField.text = str;
    }
    public void SetPulpoPrice(string str)
    {
        pulpoPriceField.text = str;
    }

    public void SetResultText(string value) {
        resultText.text = value;
    }
    public void calculateButton_Listener()
    {
        SetCity(); // Agregado
        _totalEarningPresenter.ActualizarVista();
    }

    public void SetCity()
    {
       _totalEarningPresenter.SetCity(city);
    }

    public void SetInitialValues()
    {
       _totalEarningPresenter.SetInitialPrices(city);
    }
}
