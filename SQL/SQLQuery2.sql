USE UD13_ar222da_Faktura;

-- UPPGIFT 3A --
-- Tar reda på vilket id som gäller för kategori Låg --
SELECT KategoriID FROM Kategori
WHERE Kategori = 'Låg'; -- ID = 1 --  
 
-- Lägger till kund --
-- Lägger först till angivna uppgifter och kategoriID --
INSERT INTO Kund
VALUES ('Danielssons Elektriska AB', 'Storgatan 128', '123 56', 'Stockholm', '', '0.03', 1)
-- KundID = 10 --
SELECT * FROM Teltyp -- Tar reda på vilka ID som gäller för arbete (växel) och mobil Arbete = 1, Mobil = 5
-- Lägger till telefonnummer --
INSERT INTO Telefon (Telenr, TeltypID, KundID)
VALUES ('08-8970200', 1, 10)
INSERT INTO Telefon (Telenr, TeltypID, KundID)
VALUES ('070-5470287', 5, 10) 



-- UPPGIFT 3B--
-- Lägger till artiklar --
INSERT INTO Artikel (Artnamn, Antal, Pris, Rabatt)
VALUES ('Bildskärm, platt, 10 ms', 47, 2176.00, 0),
		('Tangentbord', 36, 280.00, 0),
		('Nätkabel, TP kat 5', 1020, 2.50, 0)


-- UPPGIFT 3C --
-- Skapar en ny faktura med angivna uppgifter --
INSERT INTO Faktura (Datum, Betvillkor, KundID)
VALUES ('2012-04-20', 25, 10)
SELECT * FROM Faktura -- Ta reda på FakturaID, man vet redan att KundID = 10 -- 
SELECT * FROM Fakturarad -- Ta reda på FakturaradID, man vet att FakturaID = 7 --
SELECT * FROM Artikel -- Ta reda på ArtikelID för de två artiklarna --
SELECT * FROM Moms -- Ta reda på MomsID --
-- Lägger till fakturarader --
INSERT INTO Fakturarad (FakturaID, ArtikelID, Antal, Pris, Rabatt, MomsID)
VALUES (7, 5, 2, 2176.00, 0.03, 1), (7, 1, 22, 6.70, 0.03, 1) 



-- UPPGIFT 3D --
SELECT * FROM Kategori
INSERT INTO Kategori (Kategori)
VALUES ('Standard')



 
-- UPPGIFT 4A --
-- Tar reda på KundID för Svensson Mekaniska AB --
SELECT * FROM Kund -- KundID = 1 --
-- Tar reda på KategoriID för Standard --
SELECT * FROM Kategori -- KategoriID = 5 --

UPDATE Kund
SET KategoriID = 5
WHERE KundID = 1

-- UPPGIFT 4B --
-- Tar reda på KundID --
SELECT * FROM Kund -- KundID = 2 --
-- Tar reda på nuvarande telefon --
SELECT * FROM Telefon -- Aktuellt telefonnummer och dess kategori --

UPDATE Telefon
SET Telenr = '0480-492239' 
WHERE KundID = 2 AND TeltypID = 1


-- UPPGIFT 4C --
UPDATE Artikel
SET Pris = Pris * 1.08


-- UPPGIFT 4D --
-- Nytt fält i Artikel --


-- UPPGIFT 4E --
UPDATE Artikel
SET Plats = 'HLP 25'
WHERE Artnamn Like '%Bildskärm%'


-- UPPGIFT 4F --
UPDATE Artikel
SET Plats = 'Förråd 10'
WHERE Plats IS NULL


-- UPPGIFT 4G --
-- Tar reda på ArtikelID --
SELECT * FROM Artikel

UPDATE Fakturarad
SET Pris = Pris * 1.08
WHERE ArtikelID = 2


-- UPPGIFT 5A --
-- Tar reda på KundID och TeltypID 
SELECT * FROM Kund -- KundID = 10 --
SELECT * FROM Teltyp -- TeltypID = 1 --

DELETE 
FROM Telefon
WHERE KundID = 10 AND TeltypID = 1


-- UPPGIFT 5B --
-- Tar reda på ArtikelID --
SELECT * FROM Artikel -- ArtikelID = 4 --

DELETE
FROM Fakturarad
WHERE ArtikelID = 4


-- UPPGIFT 5C --
-- Tar reda på KategoriID --
SELECT * FROM Kategori -- KategoriID = 5 --

DELETE
FROM Kategori
WHERE KategoriID = 5
-- Fungerar ej på grund av referentiell integritet. Det får inte finnas några kunder av kategorin om man ska ta bort den --



-- UPPGIFT 6A --
SELECT * FROM KUND


-- UPPGIFT 6B --
SELECT Namn, Postnr, Ort FROM Kund


-- UPPGIFT 6C --
SELECT Namn, Postnr, Ort FROM Kund
ORDER BY Postnr DESC


-- UPPGIFT 6D --
SELECT Namn, Adress, Postnr + ' ' + Ort AS Postadress FROM Kund
ORDER BY Ort ASC


-- UPPGIFT 6E --
SELECT ArtikelID, Artnamn, Antal, Pris, FLOOR(Antal * Pris) AS Artikelvärde FROM Artikel
SELECT * FROM Artikel


-- UPPGIFT 6F --
SELECT ArtikelID AS Artikelnr, Artnamn AS Namn, Plats, Antal,  + '_______' AS 'Nytt antal' FROM Artikel


-- UPPGIFT 6G --
SELECT ArtikelID AS Artikelnr, Artnamn AS Namn, Plats, Antal,  + '_______' AS 'Nytt antal' FROM Artikel
WHERE Antal > 22 AND Plats = 'Förråd 10'


-- UPPGIFT 6H --
SELECT TOP 5 * FROM Artikel
ORDER BY Artvarde DESC


-- UPPGIFT 7A --
SELECT Namn, Ort, Telenr FROM Kund
INNER JOIN Telefon ON Kund.KundID = Telefon.KundID
ORDER BY Namn ASC


-- UPPGIFT 7B --
SELECT * FROM Faktura
SELECT * FROM Fakturarad
SELECT * FROM Artikel


SELECT CONVERT(char(10),Datum, 120), Betvillkor, Artnamn, Fakturarad.Antal, Fakturarad.Pris,
FLOOR (Moms * 100) AS Moms, Fakturarad.Rabatt, (Fakturarad.Antal * Fakturarad.Pris * (1 + Moms)) AS Summa FROM Fakturarad
-- Rabatt med i summan? -- 
INNER JOIN Faktura ON Fakturarad.FakturaID = Faktura.FakturaID
INNER JOIN Artikel ON Fakturarad.ArtikelID = Artikel.ArtikelID
INNER JOIN Moms ON Fakturarad.MomsID = Moms.MomsID


-- UPPGIFT 7C!! --
SELECT CONVERT(char(10),Datum, 120) AS Datum, Betvillkor, CONVERT (char(10), DATEADD(day, Betvillkor, Datum), 120) AS Förfallodatum, Fakturarad.Antal, Fakturarad.Pris,
FLOOR (Moms * 100) AS Moms, Fakturarad.Rabatt, (Fakturarad.Antal * Fakturarad.Pris * (1 + Moms)) AS Summa FROM Fakturarad
INNER JOIN Faktura ON Fakturarad.FakturaID = Faktura.FakturaID
INNER JOIN Artikel ON Fakturarad.ArtikelID = Artikel.ArtikelID
INNER JOIN Moms ON Fakturarad.MomsID = Moms.MomsID
 
 
 -- UPPGIFT 7D --
 SELECT Namn, Kategori, CONVERT(char(10), Datum, 120) AS Datum, Betvillkor FROM Kund
 INNER JOIN Kategori ON Kund.KategoriID = Kategori.KategoriID
 INNER JOIN Faktura ON Kund.KundID = Faktura.KundID
 
 
 -- UPPGIFT 7E --
 SELECT Namn, Kategori, CONVERT(char(10), Datum, 120) AS Datum, Betvillkor FROM Kund
 INNER JOIN Kategori ON Kund.KategoriID = Kategori.KategoriID
 INNER JOIN Faktura ON Kund.KundID = Faktura.KundID
 WHERE Datum BETWEEN '2013-01-01' AND '2014-03-01'
 
 
 -- UPPGIFT 7F!! --
 SELECT Namn, Kund.KundID FROM KUND
 INNER JOIN Faktura
 ON Faktura.KundID = NULL
 
 
 -- UPPGIFT 7G!! --
 
 
 
 -- UPPGIFT 8A --
 SELECT COUNT(*) AS 'Antal kunder'  FROM Kund
 
 
 -- UPPGIFT 8B --
 SELECT SUM(Artvarde) FROM Artikel
 
 
 -- UPPGIFT 8C --
 SELECT SUM(Antal) AS 'Antal artiklar', CEILING(ROUND(SUM(Artvarde),0)) AS 'Summa artikelvärde', 
 CEILING(ROUND(MAX(Artvarde),0)) AS 'Högsta artikelvärde', CEILING(ROUND(MIN(Artvarde), 0)) AS 'Minsta artikelvärde',
 CEILING(ROUND(AVG(Artvarde), 0)) AS 'Medel artikelvärde' FROM Artikel


-- UPPGIFT 8D !!--
SELECT SUM(Antal) AS 'Antal artiklar', MAX(Pris) AS 'Högsta pris', MIN(Pris) AS 'Lägsta pris',
AVG(Pris) AS 'Medelvärde pris' FROM Artikel



-- UPPGIFT 8E --
SELECT Faktura.FakturaID, Datum, SUM((Fakturarad.Antal * Fakturarad.Pris) - (100 * Rabatt)) AS Summa, 
SUM((Fakturarad.Antal * Fakturarad.Pris) * (1 - Rabatt) * (1 + Moms)) AS 'Summa med moms' FROM Faktura
INNER JOIN Fakturarad ON Faktura.FakturaID = Fakturarad.FakturaID
INNER JOIN Moms ON Fakturarad.MomsID = Moms.MomsID 
GROUP BY Faktura.FakturaID, Datum



-- UPPGIFT 9A --
SELECT CONVERT(char(10),Datum, 120) AS Datum, Betvillkor, CONVERT (char(10), DATEADD(day, Betvillkor, Datum), 120) AS Förfallodatum, Fakturarad.Antal, Fakturarad.Pris,
FLOOR (Moms * 100) AS Moms, Fakturarad.Rabatt, (Fakturarad.Antal * Fakturarad.Pris * (1 + Moms)) AS Summa FROM Fakturarad
INNER JOIN Faktura ON Fakturarad.FakturaID = Faktura.FakturaID
INNER JOIN Artikel ON Fakturarad.ArtikelID = Artikel.ArtikelID
INNER JOIN Moms ON Fakturarad.MomsID = Moms.MomsID


-- UPPGIFT 9B --
SELECT Namn, Adress, SUBSTRING(Postnr,1,3) AS Postnr, Ort, Anteckningar, Rabatt,KategoriID FROM KUND


-- UPPGIFT 9C --
SELECT UPPER(Artnamn) AS Artikelnamn, ' ' AS ' ', ' ' AS ' ', Antal*Pris AS Artikelvärde FROM Artikel 


-- UPPGIFT 9D --
SELECT DATEDIFF(day, GETDATE(),'2015-01-01') AS 'Dagar kvar till årsskifte', 
DATEDIFF(day, GETDATE(), '2015-02-05') AS 'Dagar kvar till min födelsedag',
DATENAME (WEEKDAY, '2015-02-05') AS 'Veckodag' 
