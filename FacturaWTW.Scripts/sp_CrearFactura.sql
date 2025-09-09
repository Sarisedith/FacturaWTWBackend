CREATE OR ALTER PROCEDURE sp_CrearFactura
    @IdCliente INT,
    @NumeroFactura INT,
	@NumeroTotalArticulos INT,
	@SubTotalFacturas DECIMAL(18,2),
	@TotalImpuestos DECIMAL(18,2),
	@TotalFactura DECIMAL(18,2)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO TblFacturas
        (FechaEmisionFactura, IdCliente, NumeroFactura, NumeroTotalArticulos, SubTotalFacturas, TotalImpuestos, TotalFactura)
        VALUES (GETDATE(), @IdCliente, @NumeroFactura, @NumeroTotalArticulos, @SubTotalFacturas, @TotalImpuestos, @TotalFactura);

        SELECT SCOPE_IDENTITY() AS FacturaId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        INSERT INTO LogErrores (Procedimiento, Mensaje)
        VALUES('sp_CrearFactura', ERROR_MESSAGE());
        THROW;
    END CATCH
END
GO
