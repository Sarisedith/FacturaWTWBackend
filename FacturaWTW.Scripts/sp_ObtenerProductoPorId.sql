CREATE OR ALTER PROCEDURE sp_ObtenerProductoPorId
    @Id INT
AS
BEGIN
    BEGIN TRY
        SELECT Id, NombreProducto, ImagenProducto, PrecioUnitario, Ext
        FROM CatProductos WITH (NOLOCK)
        WHERE Id = @Id;
    END TRY
    BEGIN CATCH
        INSERT INTO LogErrores (Procedimiento, Mensaje)
        VALUES ('sp_ObtenerProductoPorId', ERROR_MESSAGE());
        THROW;
    END CATCH
END
GO