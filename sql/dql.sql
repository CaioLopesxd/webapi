/*  */
SELECT Stocks.Id_Stock,
       Stocks.Symbol,
       Stocks.CompanyName,
       Stocks.Purchase,
       Stocks.LastDiv,
       Stocks.MarketCap,
       Stocks.Id_Industry,
       Industry.Description FROM Stocks LEFT JOIN Industry ON Industry.Id_Industry = Stocks.Id_Industry