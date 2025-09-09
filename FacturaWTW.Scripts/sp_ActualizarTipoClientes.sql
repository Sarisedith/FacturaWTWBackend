CREATE OR ALTER PROCEDURE sp_ActualizarTipoCliente
    @Id INT,
    @TipoCliente NVARCHAR(50)
AS
BEGIN
    BEGIN TRY
        UPDATE CatTipoCliente
        SET TipoCliente = @TipoCliente
        WHERE Id = @Id;

        SELECT @@ROWCOUNT;
    END TRY
    BEGIN CATCH
        INSERT INTO LogErrores (Procedimiento, Mensaje)
        VALUES ('sp_ActualizarTipoCliente', ERROR_MESSAGE());
        THROW;
    END CATCH
END
GO