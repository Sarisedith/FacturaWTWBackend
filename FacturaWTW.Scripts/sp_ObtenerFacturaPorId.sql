CREATE OR ALTER PROCEDURE sp_ObtenerFacturaPorId
    @IdFactura INT
AS
BEGIN
    BEGIN TRY
        -- Factura
        SELECT Id, FechaEmisionFactura, IdCliente, NumeroFactura, NumeroTotalArticulos,
               SubTotalFacturas, TotalImpuestos, TotalFactura
        FROM TblFacturas WITH (NOLOCK)
        WHERE Id = @IdFactura;

        -- Detalles
        SELECT Id, IdFactura, IdProducto, CantidadDeProducto,
               PrecioUnitarioProducto, SubtotalProducto, Notas
        FROM TblDetallesFactura WITH (NOLOCK)
        WHERE IdFactura = @IdFactura;
		
		-- Clientes
        SELECT *
        FROM TblClientes TC WITH (NOLOCK) 
		INNER JOIN TblFacturas TF  WITH (NOLOCK) 
		ON TC.Id = TF.IdCliente
        WHERE TF.Id = @IdFactura;
    END TRY
    BEGIN CATCH
        INSERT INTO LogErrores (Procedimiento, Mensaje)
        VALUES('sp_ObtenerFacturaPorId', ERROR_MESSAGE());
        THROW;
    END CATCH
END
GO
