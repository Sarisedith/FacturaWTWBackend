CREATE OR ALTER PROCEDURE sp_CrearProducto
    @NombreProducto NVARCHAR(50),
    @ImagenProducto IMAGE = NULL,
    @PrecioUnitario DECIMAL(18,2),
    @Ext NVARCHAR(5) = NULL
AS
BEGIN
    BEGIN TRY
        INSERT INTO CatProductos (NombreProducto, ImagenProducto, PrecioUnitario, Ext)
        VALUES (@NombreProducto, @ImagenProducto, @PrecioUnitario, @Ext);

        SELECT SCOPE_IDENTITY() AS Id;
    END TRY
    BEGIN CATCH
        INSERT INTO LogErrores (Procedimiento, Mensaje)
        VALUES ('sp_CrearProducto', ERROR_MESSAGE());
        THROW;
    END CATCH
END
GO