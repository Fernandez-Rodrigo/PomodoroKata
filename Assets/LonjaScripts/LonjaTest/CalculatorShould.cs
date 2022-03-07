using NUnit.Framework;
using NSubstitute;
public class CalculatorShould
{
    Sale sale;
    Cost cost;
    ICity city;

    float salePrice;
    float costPrice;

    [SetUp]
    public void Setup() {
        sale = new Sale();
        cost = new Cost();
        city = Substitute.For<ICity>();
        city.VieirasPrice.Returns(100);
        city.PulpoPrice.Returns(100);
        city.CentollasPrice.Returns(100);
        city.Km.Returns(800);
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
        salePrice = sale.CalculateSale(city);
        //Assert
        Assert.AreEqual(20000, salePrice);
    }
    [Test]
    public void CalculateCosts()
    {
        //Arrange
        //Act
        salePrice = sale.CalculateSale(city);
        costPrice = cost.CalculateCost(salePrice, city);
        //Assert
        Assert.AreEqual(3205, costPrice);
    }
    [Test]
    public void CalculateFinalEarning()
    {  
        //Arrange
        TotalEarning totalEarning = new TotalEarning();
        //Act
        salePrice = sale.CalculateSale(city);
        costPrice = cost.CalculateCost(salePrice, city);
        float result = totalEarning.CalculateTotalEarnings(salePrice, costPrice);
        //Assert
        Assert.AreEqual(16795, result);
    }
}

