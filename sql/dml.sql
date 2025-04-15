-- Limpar dados antigos 
DELETE FROM Comments;
DELETE FROM Stocks;
DELETE FROM Industries;

-- Resetar identidade 
DBCC CHECKIDENT ('Industries', RESEED, 0);
DBCC CHECKIDENT ('Stocks', RESEED, 0);
DBCC CHECKIDENT ('Comments', RESEED, 0);

-- Populando Industries
INSERT INTO Industries (Description) VALUES ('Technology');         -- 1
INSERT INTO Industries (Description) VALUES ('Automotive');         -- 2
INSERT INTO Industries (Description) VALUES ('Healthcare');         -- 3
INSERT INTO Industries (Description) VALUES ('Finance');            -- 4
INSERT INTO Industries (Description) VALUES ('Retail');             -- 5
INSERT INTO Industries (Description) VALUES ('Energy');             -- 6
INSERT INTO Industries (Description) VALUES ('Telecommunications'); -- 7
INSERT INTO Industries (Description) VALUES ('Consumer Goods');     -- 8
INSERT INTO Industries (Description) VALUES ('Transportation');     -- 9
INSERT INTO Industries (Description) VALUES ('Entertainment');      -- 10

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

-- Populando Comments
INSERT INTO Comments (Title, Content, CreatedOn, Id_Stock)
VALUES 
('Bom investimento', 'Apple continua sendo uma boa escolha para longo prazo.', GETDATE(), 1),
('Ações em alta', 'Google subiu bastante esse mês.', GETDATE(), 2),
('Cuidado com a Tesla', 'Volatilidade alta demais.', GETDATE(), 3),
('Ford estável', 'Bom para dividendos.', GETDATE(), 4),
('Pfizer segura', 'Boa posição na área de saúde.', GETDATE(), 5),
('Dividendos fortes', 'JNJ paga bons dividendos.', GETDATE(), 6),
('Banco sólido', 'JPM é referência no setor.', GETDATE(), 7),
('Cartão sempre em alta', 'Visa sempre cresce bem.', GETDATE(), 8),
('Maior varejista', 'Walmart é líder de mercado.', GETDATE(), 9),
('Crescimento forte', 'Amazon mesmo sem dividendos é ótima.', GETDATE(), 10),
('Apple continua forte', 'A Apple mantém uma performance sólida no mercado.', GETDATE(), 1),
('Google se destaca', 'Google continua a inovar e crescer, ótima escolha.', GETDATE(), 2),
('Tesla continua arriscada', 'A volatilidade ainda é um problema para Tesla.', GETDATE(), 3),
('Ford estável', 'Ford tem mostrado boa recuperação nos últimos tempos.', GETDATE(), 4),
('Pfizer em alta', 'Pfizer se beneficia com novas vacinas e medicamentos.', GETDATE(), 5),
('Johnson & Johnson sólida', 'JNJ é um bom ativo para longo prazo, com consistência.', GETDATE(), 6),
('JPM forte no mercado financeiro', 'JPMorgan está se destacando na recuperação econômica.', GETDATE(), 7),
('Visa boa oportunidade', 'Visa tem bom desempenho, excelente para quem busca estabilidade.', GETDATE(), 8),
('Walmart continua crescendo', 'A Walmart se destaca na transformação digital no varejo.', GETDATE(), 9),
('Amazon com forte presença', 'Amazon continua expandindo suas operações globalmente.', GETDATE(), 10),
('Exxon Mobil em recuperação', 'Exxon está se ajustando bem aos novos desafios do mercado.', GETDATE(), 11),
('Apple líder de mercado', 'A Apple continua dominando o mercado de smartphones e mais.', GETDATE(), 1),
('Google e inovação', 'Google continua sendo um líder em inovação tecnológica.', GETDATE(), 2),
('Tesla e suas flutuações', 'Tesla é uma boa aposta para investidores de risco.', GETDATE(), 3),
('Ford em transição', 'Ford está se reinventando para o futuro dos carros elétricos.', GETDATE(), 4),
('Pfizer ótima escolha', 'Pfizer oferece segurança em tempos incertos.', GETDATE(), 5),
('Johnson & Johnson confiável', 'Johnson & Johnson tem uma trajetória impressionante de crescimento.', GETDATE(), 6),
('JPM de olho no futuro', 'JPMorgan está bem posicionado para os próximos anos.', GETDATE(), 7),
('Visa, uma gigante', 'Visa continua sendo uma das empresas mais valiosas do setor financeiro.', GETDATE(), 8),
('Walmart inovação constante', 'Walmart está transformando sua estratégia de e-commerce.', GETDATE(), 9),
('Amazon sempre à frente', 'Amazon é sinônimo de crescimento e inovação constante.', GETDATE(), 10),
('Exxon Mobil e os desafios', 'Exxon está focada em transição para uma energia mais limpa.', GETDATE(), 11);

