namespace StockAnalysis;

internal static class Program
{
    internal static void Main(string[] args)
    {
        try
        {
            if (args.Length == 0)
            {
                throw new ArgumentNullException(nameof(args), "Please provide file path");
            }

            var result = Analyzer.FromCsv(args[0]);
            
            Print(result.HasAbsoluteIncrease ? $"Company: {result.StockName}, Largest price increase: {result.IncreasedPrice}" : "nil");
        }
        catch (Exception ex)
        {
            Print(ex.ToString(), isError: true);
        }
    }

    private static void Print(string message, bool isError = false)
    {
        Console.ForegroundColor = isError ? ConsoleColor.Red : ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}