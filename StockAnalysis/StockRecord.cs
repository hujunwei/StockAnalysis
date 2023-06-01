namespace StockAnalysis;

public class StockRecord
{
    public string Name { get; private init; }
    public DateTime Date { get; private init; }
    public decimal Value { get; private init; }
    
    private StockRecord() { }

    public static StockRecord? CreateStockRecord(string line)
    {
        if (CanCreateStockRecord(line))
        {
            var data = line.Split(",");
            return new StockRecord
            {
                Name = data[0].Trim(),
                Date = DateTime.Parse(data[1].Trim()),
                Value = decimal.Parse(data[3].Trim())
            };
        }

        return null;
    }

    private static bool CanCreateStockRecord(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            return false;
        }

        var data = line.Split(",");
        if (data.Length != 5)
        {
            return false;
        }
        
        var date = data[1].Trim();
        if (!DateTime.TryParse(date, out _))
        {
            return false;
        }
        
        var value = data[3].Trim();
        if (!decimal.TryParse(value, out _))
        {
            return false;
        }

        return true;
    }
}

