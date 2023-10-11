CREATE TRIGGER Trigger1
ON RentDetails
AFTER INSERT
AS
BEGIN
    UPDATE rd
    SET rd.Name = c.Name,
        rd.Title = m.Title,
        rd.TotalPrice = i.TotalPrice
    FROM RentDetails rd
    JOIN INSERTED i ON rd.OrderId = i.OrderId
    JOIN Customers c ON i.CustomerId = c.CustomerId
    JOIN Movies m ON i.MovieId = m.MovieId;
END;
