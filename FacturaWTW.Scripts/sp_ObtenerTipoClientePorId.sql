CREATE OR ALTER PROCEDURE sp_ObtenerTipoClientePorId
    @Id INT
AS
BEGIN
    BEGIN TRY
        SELECT Id, TipoCliente
        FROM CatTipoCliente WITH (NOLOCK)
        WHERE Id = @Id;
    END TRY
    BEGIN CATCH
        INSERT INTO LogErrores (Procedimiento, Mensaje)
        VALUES ('sp_ObtenerTipoClientePorId', ERROR_MESSAGE());
        THROW;
    END CATCH
END
GO