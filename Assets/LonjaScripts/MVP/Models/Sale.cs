public class Sale
{

    private const float VIEIRAS_QTY = 50;
    private const float CENTOLLAS_QTY = 50;
    private const float PULPO_QTY = 100;
    private float salesTotal;
    public Sale()
    {

    }
      
    public float CalculateSale(ICity city)
    {
        salesTotal = (VIEIRAS_QTY * city.VieirasPrice) + (CENTOLLAS_QTY * city.CentollasPrice) + (PULPO_QTY * city.PulpoPrice);
        return salesTotal;
    }

}