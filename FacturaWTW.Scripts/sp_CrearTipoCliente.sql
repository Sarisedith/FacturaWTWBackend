CREATE OR ALTER PROCEDURE sp_CrearTipoCliente
    @TipoCliente NVARCHAR(50)
AS
BEGIN
    BEGIN TRY
        INSERT INTO CatTipoCliente (TipoCliente)
        VALUES (@TipoCliente);

        SELECT SCOPE_IDENTITY() AS Id;
    END TRY
    BEGIN CATCH
        INSERT INTO LogErrores (Procedimiento, Mensaje)
        VALUES ('sp_CrearTipoCliente', ERROR_MESSAGE());
        THROW;
    END CATCH
END
GO