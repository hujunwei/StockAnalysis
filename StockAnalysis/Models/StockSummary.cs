namespace StockAnalysis.Models;

/// <summary>
/// Represents a given stock's earliest time price and latest time price.
/// </summary>
public class StockSummary
{
    public DateTimePrice Earliest { get; set; } = null!;

    public DateTimePrice Latest { get; set; } = null!;

    public decimal GetIncrease()
    {
        return Latest.Price - Earliest.Price;
    }
}

/// <summary>
/// A simple model represents Date and Price pair.
/// </summary>
public class DateTimePrice
{
    public DateTime Date { get; init; }
    
    public decimal Price { get; init; }

    public static DateTimePrice FromRecord(StockRecord record)
    {
        return new DateTimePrice
        {
            Date = record.Date,
            Price = record.Value
        };
    }
}