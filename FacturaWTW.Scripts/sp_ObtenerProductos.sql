CREATE OR ALTER PROCEDURE sp_ObtenerProductos
AS
BEGIN
    BEGIN TRY
        SELECT Id, NombreProducto, ImagenProducto, PrecioUnitario, Ext
        FROM CatProductos WITH (NOLOCK);
    END TRY
    BEGIN CATCH
        INSERT INTO LogErrores (Procedimiento, Mensaje)
        VALUES ('sp_ObtenerProductos', ERROR_MESSAGE());
        THROW;
    END CATCH
END
GO