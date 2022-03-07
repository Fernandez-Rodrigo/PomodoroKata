public class Sale
{

    private const float VIEIRAS_QTY = 50;
    private const float CENTOLLAS_QTY = 50;
    private const float PULPO_QTY = 100;
    private float salesTotal;
    public Sale()
    {

    }

    //public float CalculateSale(float vieiraPrice, float centollaPrice, float pulpoPrice)
    //{
    //    salesTotal = (VIEIRAS_QTY * vieiraPrice) + (CENTOLLAS_QTY * centollaPrice) + (PULPO_QTY * pulpoPrice);
    //    return salesTotal;
    //}
      
    public float CalculateSaleStrategy(ICity city)
    {
        salesTotal = (VIEIRAS_QTY * city.VieirasPrice) + (CENTOLLAS_QTY * city.CentollasPrice) + (PULPO_QTY * city.PulpoPrice);
        return salesTotal;
    }

}