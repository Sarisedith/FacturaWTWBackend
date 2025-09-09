CREATE OR ALTER PROCEDURE sp_ObtenerTiposCliente
AS
BEGIN
    BEGIN TRY
        SELECT Id, TipoCliente
        FROM CatTipoCliente WITH (NOLOCK);
    END TRY
    BEGIN CATCH
        INSERT INTO LogErrores (Procedimiento, Mensaje)
        VALUES ('sp_ObtenerTiposCliente', ERROR_MESSAGE());
        THROW;
    END CATCH
END
GO