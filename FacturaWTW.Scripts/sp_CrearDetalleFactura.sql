CREATE PROCEDURE sp_CrearDetalleFactura
    @IdFactura INT,
    @IdProducto INT,
    @CantidadDeProducto INT,
    @PrecioUnitarioProducto DECIMAL(18,2),
    @SubtotalProducto DECIMAL(18,2),
    @Notas NVARCHAR(200) = NULL
AS
BEGIN
    BEGIN TRY
        INSERT INTO TblDetallesFactura
        (IdFactura, IdProducto, CantidadDeProducto, PrecioUnitarioProducto, SubtotalProducto, Notas)
        VALUES (@IdFactura, @IdProducto, @CantidadDeProducto, @PrecioUnitarioProducto, @SubtotalProducto, @Notas);
    END TRY
    BEGIN CATCH
        INSERT INTO LogErrores (Procedimiento, Mensaje)
        VALUES('sp_CrearDetalleFactura', ERROR_MESSAGE());
        THROW;
    END CATCH
END
GO
