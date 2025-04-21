-- Limpar dados antigos 
DELETE FROM Comments;
DELETE FROM Stocks;
DELETE FROM Industries;

-- Resetar identidade 
DBCC CHECKIDENT ('Industries', RESEED, 0);
DBCC CHECKIDENT ('Stocks', RESEED, 0);
DBCC CHECKIDENT ('Comments', RESEED, 0);

-- Populando Industries
INSERT INTO Industries (Description) VALUES 
('Technology'),         -- 1
('Automotive'),         -- 2
('Healthcare'),         -- 3
('Finance'),            -- 4
('Retail'),             -- 5
('Energy'),             -- 6
('Telecommunications'), -- 7
('Consumer Goods'),     -- 8
('Transportation'),     -- 9
('Entertainment');      -- 10

-- Populando Stocks
INSERT INTO Stocks (Symbol, CompanyName, Purchase, LastDiv, Id_Industry, MarketCap)
VALUES 
('AAPL', 'Apple Inc.', 150.00, 0.82, 1, 2000000000000),
('GOOG', 'Google LLC', 120.00, 0.55, 1, 1800000000000),
('TSLA', 'Tesla Motors', 700.00, 0.0, 2, 800000000000),
('F', 'Ford Motor Company', 12.00, 0.30, 2, 55000000000),
('PFE', 'Pfizer Inc.', 40.00, 0.80, 3, 220000000000),
('JNJ', 'Johnson & Johnson', 165.00, 1.00, 3, 430000000000),
('JPM', 'JPMorgan Chase', 130.00, 1.10, 4, 500000000000),
('V', 'Visa Inc.', 210.00, 0.90, 4, 460000000000),
('WMT', 'Walmart', 140.00, 0.60, 5, 410000000000),
('AMZN', 'Amazon', 100.00, 0.0, 5, 1600000000000),
('XOM', 'Exxon Mobil', 85.00, 0.70, 6, 300000000000)


