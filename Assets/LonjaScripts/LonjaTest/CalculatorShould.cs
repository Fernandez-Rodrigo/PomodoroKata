using NUnit.Framework;

public class CalculatorShould
{
    Sale sale;
    Cost cost;

    [SetUp]
    public void Setup() {
        sale = new Sale();
        cost = new Cost();
    }
    [Test]
    public void CalculatorShouldSimplePasses()
    {
    }
    [Test]
    public void CalculateSales()
    {   
        //Arrange
        //Act
        float salePrice = sale.CalculateSale(100, 100, 100);
        //Assert
        Assert.AreEqual(20000, salePrice);
    }
    [Test]
    public void CalculateCosts()
    {
        //Arrange
        //Act
        float costPrice = cost.CalculateCost(20000, 800);
        //Assert
        Assert.AreEqual(3205, costPrice);
    }
    [Test]
    public void CalculateFinalEarning()
    {  
        //Arrange
        TotalEarning totalEarning = new TotalEarning();
        float salePrice;
        float costPrice;
        //Act
        salePrice = sale.CalculateSale(100, 100, 100);
        costPrice = cost.CalculateCost(20000, 800);
        float result = totalEarning.CalculateTotalEarnings(salePrice, costPrice);
        //Assert
        Assert.AreEqual(16795, result);
    }
}

