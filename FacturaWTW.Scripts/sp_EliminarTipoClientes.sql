CREATE OR ALTER PROCEDURE sp_EliminarTipoCliente
    @Id INT
AS
BEGIN
    BEGIN TRY
        DELETE FROM CatTipoCliente WHERE Id = @Id;

        SELECT @@ROWCOUNT;
    END TRY
    BEGIN CATCH
        INSERT INTO LogErrores (Procedimiento, Mensaje)
        VALUES ('sp_EliminarTipoCliente', ERROR_MESSAGE());
        THROW;
    END CATCH
END
GO