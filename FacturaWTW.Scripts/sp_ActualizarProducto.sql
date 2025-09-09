CREATE PROCEDURE sp_ActualizarProducto
    @Id INT,
    @NombreProducto NVARCHAR(50),
    @ImagenProducto IMAGE = NULL,
    @PrecioUnitario DECIMAL(18,2),
    @Ext NVARCHAR(5) = NULL
AS
BEGIN
    BEGIN TRY
        UPDATE CatProductos
        SET NombreProducto = @NombreProducto,
            ImagenProducto = @ImagenProducto,
            PrecioUnitario = @PrecioUnitario,
            Ext = @Ext
        WHERE Id = @Id;

        SELECT @@ROWCOUNT;
    END TRY
    BEGIN CATCH
        INSERT INTO LogErrores (Procedimiento, Mensaje)
        VALUES ('sp_ActualizarProducto', ERROR_MESSAGE());
        THROW;
    END CATCH
END
GO