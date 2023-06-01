using NUnit.Framework;
using StockAnalysis.Models;

namespace StockAnalysis.Tests.Models;

[TestFixture]
public class StockRecordTests
{
    [TestCase("Company A,2023-05-31,Some notes,100.50,1.2")]
    [TestCase(" Company A, 2023-05-31, Some notes, 100.50, 1.2")]
    [TestCase("Company A ,2023-05-31 ,Some notes ,100.50 , 1.2 ")]
    [TestCase(" Company A,2023-05-31,Some notes,100.50,1.2 ")]
    public void Create_ValidCsvRow_ReturnsStockRecordObject(string csvRow)
    {
        var result = StockRecord.Create(csvRow)!;
        
        Assert.IsNotNull(result);
        Assert.AreEqual("Company A", result.Name);
        Assert.AreEqual(new DateTime(2023, 05, 31), result.Date);
        Assert.AreEqual(100.50m, result.Value);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("Company A,2023-05-31,Some notes,100.50")]
    [TestCase("Company A,2023-05-31,Some notes,100.50x,INCREASE")]
    [TestCase("Company A,2023-05-312,Some notes,100.50,INCREASE")]
    public void Create_InvalidCsvRow_ReturnsNull(string csvRow)
    {
        Assert.IsNull(StockRecord.Create(csvRow));
    }

   
    [TestCase("Name,Date,Notes,Value,Change")]
    [TestCase(" Name,Date,Notes,Value,Change ")]
    [TestCase(" Name, Date, Notes, Value, Change")]
    [TestCase("Name ,Date ,Notes ,Value ,Change ")]
    public void IsValidHeader_ValidHeader_ReturnsTrue(string csvHeader)
    {
        Assert.IsTrue(StockRecord.IsValidHeader(csvHeader));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase(" Name, Notes, Value, Change")]
    public void IsValidHeader_InvalidHeader_ReturnsFalse(string csvHeader)
    {
        Assert.IsFalse(StockRecord.IsValidHeader(csvHeader));
    }
}