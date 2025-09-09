CREATE OR ALTER PROCEDURE sp_EliminarProducto
    @Id INT
AS
BEGIN
    BEGIN TRY
        DELETE FROM CatProductos WHERE Id = @Id;
        SELECT @@ROWCOUNT;
    END TRY
    BEGIN CATCH
        INSERT INTO LogErrores (Procedimiento, Mensaje)
        VALUES ('sp_EliminarProducto', ERROR_MESSAGE());
        THROW;
    END CATCH
END
GO