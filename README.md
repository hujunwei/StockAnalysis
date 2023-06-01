# StockAnalysis

A simple console application to find stock with the largest absolute increase from its first recording to its last recording. 

Given a CSV with:

| Name | Date      | notes | Value   | Change    |
| ---- | --------- | ----- | ------- | --------- |
| IQZ  | 2015/7/8  | notes | 656.36  | INCREASED |
| DLV  | 2015/8/8  | notes | 173.35  | INCREASED |
| DLV  | 2015/10/4 | notes | 231.67  | INCREASED |
| DLV  | 2015/9/7  | notes | 209.57  | DECREASED |
| IQZ  | 2015/9/7  | notes | 641.23  | DECREASED |
| IQZ  | 2015/10/4 | notes | 657.32  | INCREASED |
| DLV  | 2015/8/18 | notes | 233.43  | INCREASED |
| DLV  | 2015/9/15 | notes | 158.73  | DECREASED |
| IQZ  | 2015/10/8 | notes | 537.53  | DECREASED |
| IQZ  | 2015/10/6 | notes | Invalid | UNKNOWN   |

Output:

`PS C:\Users\hualong\Desktop> StockAnalysis.exe C:\Users\hualong\Desktop\Stock_1.csv`
`**Company: DLV, Largest price increase: 58.32**`



### How to run

1. Install .NET Core 7 from [下载 .NET 7.0 SDK (v7.0.302) - Windows x64 Installer (microsoft.com)](https://dotnet.microsoft.com/zh-cn/download/dotnet/thank-you/sdk-7.0.302-windows-x64-installer)

2. Download `StockAnalysis-win-x64.zip` from `StockAnalysis.Artifacts` folder

3. Run `StockAnalysis.exe FULL_ABSOLUTE_PATH_TO_CSV`

   e.g.  `StockAnalysis.exe C:\Users\XXX\Desktop\Stock_1.csv`