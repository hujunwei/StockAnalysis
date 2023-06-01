using NUnit.Framework;

namespace StockAnalysis.Tests;

[TestFixture]
public class AnalyzerTests
{
    [Test]
    public void EmptyCsv_ShouldThrowException()
    {
        Assert.Throws<InvalidDataException>(() => Analyzer.FromCsv("Data/Empty.csv"));
    }

    [TestCase("Data/Invalid_1.csv")]
    [TestCase("Data/Invalid_2.csv")]
    public void InvalidCsv_ShouldThrowException(string path)
    {
        Assert.Throws<InvalidDataException>(() => Analyzer.FromCsv(path));
    }
    
    [Test]
    public void Stock_1_ShouldReturnResultCorrectly()
    {
        var result = Analyzer.FromCsv("Data/Stock_1.csv");
        
        Assert.IsTrue(result.HasAbsoluteIncrease);
        Assert.AreEqual("DLV", result.StockName);
        Assert.AreEqual(58.32, result.IncreasedPrice);
    }
    
    [Test]
    public void Stock_2_ShouldReturnResultCorrectly()
    {
        var result = Analyzer.FromCsv("Data/Stock_2.csv");
        
        Assert.IsFalse(result.HasAbsoluteIncrease);
    }

    [Test]
    public void Stock_Full_ShouldReturnResultCorrectly()
    {
        var result = Analyzer.FromCsv("Data/Stock_Full.csv");
        
        Assert.IsTrue(result.HasAbsoluteIncrease);
        Assert.AreEqual("OQB", result.StockName);
        Assert.AreEqual(850, result.IncreasedPrice);
    }
}