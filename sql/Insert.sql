/* Inserir Indústrias */
INSERT INTO Industry (Description) VALUES ('Automotive');
INSERT INTO Industry (Description) VALUES ('Technology');

/* Inserir Ações */
INSERT INTO Stocks (Symbol, CompanyName, Purchase, LastDiv, Industry, MarketCap)
VALUES ('TSLA', 'Tesla', 100.00, 2.00, 2, 234234234);
INSERT INTO Stocks (Symbol, CompanyName, Purchase, LastDiv, Industry, MarketCap)
VALUES ('MSFT', 'Microsoft', 100.00, 1.20, 2, 234234234);

/* Inserir Comments */
INSERT INTO Comments (Title, Content, CreatedOn, StockId)
VALUES ('teste', 'content', NOW(), 1);
INSERT INTO Comments (Title, Content, CreatedOn, StockId)
VALUES ('teste', 'content', NOW(), 1);
