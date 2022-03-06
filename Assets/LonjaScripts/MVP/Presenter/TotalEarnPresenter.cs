using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TotalEarnPresenter
{
    ITotalEarningView totalEarningView;
    private TotalEarning totalEarning;
    private Sale sale;
    private Cost cost;
    private ICity city;
    float totalSale;
    float totalCost;

    public TotalEarnPresenter(ITotalEarningView totalEarningView)
    {

        this.totalEarningView = totalEarningView;
        totalEarning = new TotalEarning();
        sale = new Sale();
        cost = new Cost();
    }

  
    private float CalculateSalePrice(float vieirasPrice, float centollaPrice, float pulpoPirce)
    {
        float result = sale.CalculateSale(vieirasPrice, centollaPrice, pulpoPirce);
        return result;
    }
    private float CalculateCostPrice(float salePrice, float kms)
    {
        float result = cost.CalculateCost(salePrice, kms);
        return result;
    }



    private float CalculateTotalEarning()
    {
        //float vieirasPrice = float.Parse(totalEarningView.GetVieiraPrice());
        //float centollaPrice = float.Parse(totalEarningView.GetCentollaPrice());
        //float pulpoPrice = float.Parse(totalEarningView.GetPulpoPrice());
        totalSale = CalculateSalePrice(city.VieirasPrice, city.CentollasPrice, city.PulpoPrice);
        totalCost = CalculateCostPrice(totalSale, city.km);
        return totalEarning.CalculateTotalEarnings(totalSale, totalCost);
    }
       
    public void ActualizarVista() {

        totalEarningView.SetResultText(CalculateTotalEarning().ToString());
    }


    public void ValidarCamposVieira(string str)
    {
        if (str.StartsWith("-"))
        {
            totalEarningView.SetVieiraPrice("");
        }
        if (str.Equals(""))
        {
            totalEarningView.SetVieiraPrice("0");
        }
    }
    public void ValidarCamposCentolla(string str)
    {
        if (str.StartsWith("-"))
        {
            totalEarningView.SetCentollaPrice("");
        }
        if (str.Equals(""))
        {
            totalEarningView.SetCentollaPrice("0");
        }
    }
    public void ValidarCamposPulpo(string str)
    {
        if (str.StartsWith("-"))
        {
            totalEarningView.SetPulpoPrice("");
        }
        if (str.Equals(""))
        {
            totalEarningView.SetPulpoPrice("0");
        }
    }




    public void SetInitialPrices(ICity city)
    {
        totalEarningView.SetCentollaPrice(city.CentollasPrice.ToString());
        totalEarningView.SetVieiraPrice(city.VieirasPrice.ToString());
        totalEarningView.SetPulpoPrice(city.PulpoPrice.ToString());
    }

    public void SetCity(ICity _city)
    {
        city = _city;
    }

}
