namespace StockAnalysis.Models;

/// <summary>
/// Data model represents one line in CSV.
/// </summary>
public class StockRecord
{
    public string Name { get; private init; } = default!;
    public DateTime Date { get; private init; }
    public decimal Value { get; private init; }
    
    private StockRecord() { }

    /// <summary>
    /// Creates a StockRecord from a csv row.
    /// Returns null if line is invalid.
    /// </summary>
    /// <param name="csvRow">Line read from csv</param>
    /// <returns>StockRecord object</returns>
    public static StockRecord? Create(string? csvRow)
    {
        if (CanCreateFrom(csvRow))
        {
            var data = csvRow!.Split(",");
            return new StockRecord
            {
                Name = data[0].Trim(),
                Date = DateTime.Parse(data[1].Trim()),
                Value = decimal.Parse(data[3].Trim())
            };
        }

        return null;
    }
    
    /// <summary>
    /// Judge if a csv row is valid header.
    /// </summary>
    /// <param name="csvRow">A csv row.</param>
    /// <returns>Whether a csv row is a valid record.</returns>
    public static bool IsValidHeader(string? csvRow)
    {
        if (string.IsNullOrWhiteSpace(csvRow))
        {
            return false;
        }

        var data = csvRow.Split(",");

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

    /// <summary>
    /// Validates a csv row.
    /// </summary>
    /// <param name="csvRow">A csv row.</param>
    /// <returns>Whether csvRow is valid data can create a StockRecord object from it.</returns>
    private static bool CanCreateFrom(string? csvRow)
    {
        if (string.IsNullOrWhiteSpace(csvRow))
        {
            return false;
        }

        var data = csvRow.Split(",");
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

