using StockAnalysis.Models;

namespace StockAnalysis;

/// <summary>
/// Analyze the stock data.
/// </summary>
public static class Analyzer
{
    public static Result FromCsv(string filePath)
    {
        var stockData = new Dictionary<string, StockSummary>();
        
        using var reader = new StreamReader(filePath);

        // Read the header line, if first line is not header, we deem csv file is invalid.
        var line = reader.ReadLine();
        if (!StockRecord.IsValidHeader(line))
        {
            throw new InvalidDataException("Invalid file format: first line must be a valid header row.");
        }

        // Read record line by line.
        while (!reader.EndOfStream)
        {
            var record = StockRecord.Create(reader.ReadLine());
            // If line is not valid, skip it.
            if (record == null)
            {
                continue;
            }

            // If record is stored in the dict, updates its earliest time price and latest time price.
            if (stockData.TryGetValue(record.Name, out var summary))
            {
                if (record.Date == summary.Earliest.Date || record.Date == summary.Latest.Date)
                {
                    throw new InvalidDataException($"Duplicated date found for Stock: {record.Name} with Name: {record.Date}");
                }
                
                if (record.Date < summary.Earliest.Date)
                {
                    stockData[record.Name].Earliest = DateTimePrice.FromRecord(record);
                }

                if (record.Date > summary.Latest.Date)
                {
                    stockData[record.Name].Latest = DateTimePrice.FromRecord(record);
                }
            }
            // If record has not been stored in dict, initialize a new summary for it. 
            else
            {
                stockData[record.Name] = new StockSummary
                {
                    Earliest = DateTimePrice.FromRecord(record),
                    Latest = DateTimePrice.FromRecord(record)
                };
            }
        }

        // Calculates current stock increase and compare against all stocks' increase.
        decimal globalLargestIncreasingPrice = 0;
        var largestIncreasingPriceStockName = string.Empty;
        foreach (var kv in stockData)
        {
            var increase = kv.Value.GetIncrease();
            if (increase > globalLargestIncreasingPrice)
            {
                globalLargestIncreasingPrice = increase;
                largestIncreasingPriceStockName = kv.Key;
            }
        }

        return new Result
        {
            HasAbsoluteIncrease = !string.IsNullOrWhiteSpace(largestIncreasingPriceStockName),
            StockName = largestIncreasingPriceStockName,
            IncreasedPrice = globalLargestIncreasingPrice
        };
    }
}