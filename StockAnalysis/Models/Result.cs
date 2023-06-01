namespace StockAnalysis.Models;

/// <summary>
/// Result DTO indicates the analyzer result.
/// </summary>
public class Result
{
    public decimal IncreasedPrice { get; init; }
    public string StockName { get; init; } = default!;
    public bool HasAbsoluteIncrease { get; init; }
}