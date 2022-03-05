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

    TotalEarnPresenter _totalEarningPresenter;

    // Start is called before the first frame update
    void Start()
    {
        _totalEarningPresenter = new TotalEarnPresenter(this);
    }

    // Update is called once per frame
    void Update()
    {
        _totalEarningPresenter.ValidarCamposVieira(vieiraPriceField.text);
        _totalEarningPresenter.ValidarCamposCentolla(centollaPriceField.text);
        _totalEarningPresenter.ValidarCamposPulpo(pulpoPriceField.text);
    }
    public string GetVieiraPrice() {
        return vieiraPriceField.text;
    }
    public string GetCentollaPrice() {
        return vieiraPriceField.text;
    }
    public string GetPulpoPrice() {
        return vieiraPriceField.text;
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
        _totalEarningPresenter.ActualizarVista();
    }
}
