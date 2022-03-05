public class Sale
{

    private const float VIEIRAS_QTY = 50;
    private const float CENTOLLAS_QTY = 50;
    private const float PULPO_QTY = 100;
    private float salesTotal;
    private ICity city;
    public Sale()
    {

    }

    public float CalculateSale(float vieiraPrice, float centollaPrice, float pulpoPrice)
    {
        salesTotal = (VIEIRAS_QTY * vieiraPrice) + (CENTOLLAS_QTY * centollaPrice) + (PULPO_QTY * pulpoPrice);
        return salesTotal;
    }


    public void SetCity(ICity _city) // Esto se puede hacer en el presentador donde se ejecutan los métodos
    {
        city = _city;
    }
    public float CalculateSaleStrategy(ICity city)
    {
        salesTotal = (VIEIRAS_QTY * city.vieirasPrice) + (CENTOLLAS_QTY * city.centollasPrice) + (PULPO_QTY * city.pulpoPrice);
        return salesTotal;
    }

}