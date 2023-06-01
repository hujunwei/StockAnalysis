namespace StockAnalysis;

public static class Algorithm
{
    public static decimal FindLargestIncreasingPrice(this IList<decimal> timeOrderedPrices)
    {
        if (timeOrderedPrices.Count < 2)
        {
            return 0; // Absolute increase,
        }
        
        var prevMin = timeOrderedPrices[0];
        decimal largestIncreasingPrice = 0;
        for (var i = 1; i < timeOrderedPrices.Count; i++)
        {
            largestIncreasingPrice = Math.Max(largestIncreasingPrice, timeOrderedPrices[i] - prevMin);
            prevMin = Math.Min(prevMin, timeOrderedPrices[i]);
        }

        return largestIncreasingPrice;
    }
}