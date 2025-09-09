CREATE OR ALTER PROCEDURE sp_BuscarFacturas
AS
BEGIN
    BEGIN TRY
        SELECT Id, FechaEmisionFactura, IdCliente, NumeroFactura,
               NumeroTotalArticulos, SubTotalFacturas, TotalImpuestos, TotalFactura
        FROM TblFacturas WITH (NOLOCK);
    END TRY
    BEGIN CATCH
        INSERT INTO LogErrores (Procedimiento, Mensaje)
        VALUES('sp_BuscarFacturas', ERROR_MESSAGE());
        THROW;
    END CATCH
END
GO
