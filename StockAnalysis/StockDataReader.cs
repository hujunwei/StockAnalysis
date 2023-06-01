namespace StockAnalysis;

public static class StockDataReader
{
    public static Dictionary<string, List<StockRecord>> FromCsvFile(string path)
    {
        var stockData = new Dictionary<string, List<StockRecord>>();
        
        using var reader = new StreamReader(path); 
        
        var line = reader.ReadLine();
        if (!line.IsHeader())
        {
            throw new InvalidDataException("Invalid file format: first line must be a header column.");
        }
            
        while (!reader.EndOfStream)
        {
            var stockRecord = StockRecord.CreateStockRecord(reader.ReadLine());
            if (stockRecord == null)
            {
                continue;
            }

            if (stockData.TryGetValue(stockRecord.Name, out var list))
            {
                list.Add(stockRecord);
            }
            else
            {
                stockData[stockRecord.Name] = new List<StockRecord> { stockRecord };
            }
        }

        return stockData;
    }

    private static bool IsHeader(this string line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            return false;
        }

        var data = line.Split(",");

        if (!data[0].Trim().Equals("Name", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        if (!data[1].Trim().Equals("Date", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        if (!data[2].Trim().Equals("Notes", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        if (!data[3].Trim().Equals("Value", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        if (!data[4].Trim().Equals("Change", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        return true;
    }
}