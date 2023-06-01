using StockAnalysis;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Step 1: Read the data from the file
            var stockData = StockDataReader.FromCsvFile("Data/Stock_1.csv");
            
            // Step 2: Sort the data within each group based on date
            decimal globalLargestIncreasingPrice = 0;
            var largestIncreasingPriceStockName = string.Empty;
            foreach (var kv in stockData)
            {
                var timeOrderedPrices = kv.Value.OrderBy(sr => sr.Date).Select(sr => sr.Value).ToList();
                var largestIncrease = timeOrderedPrices.FindLargestIncreasingPrice();

                if (largestIncrease > globalLargestIncreasingPrice)
                {
                    globalLargestIncreasingPrice = largestIncrease;
                    largestIncreasingPriceStockName = kv.Key;
                }
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.IsNullOrWhiteSpace(largestIncreasingPriceStockName) ? "nil" : $"Company: {largestIncreasingPriceStockName}, Largest price increase: {globalLargestIncreasingPrice}");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex);
            Console.ResetColor();
        }
    }
}
