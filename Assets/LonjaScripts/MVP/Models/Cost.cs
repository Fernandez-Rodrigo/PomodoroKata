public class Cost
{
    private const float truckLoadingCost = 5;
    private const float kmPrice = 2;
    private const float kmDeprecation = 0.01f;
    private const float kmsNeededForDeprecationApply = 100;

    private float costsTotal;
    public Cost()
    {
    }

    public float CalculateCost(float salesTotal, ICity city)
    {
        costsTotal = truckLoadingCost + (city.Km * kmPrice) + (salesTotal * ((city.Km / kmsNeededForDeprecationApply) * kmDeprecation));
        return costsTotal;
    }
}