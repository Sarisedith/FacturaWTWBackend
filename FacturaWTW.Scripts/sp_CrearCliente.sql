CREATE OR ALTER PROCEDURE sp_CrearCliente
    @RazonSocial NVARCHAR(200),
    @IdTipoCliente INT,
    @RFC NVARCHAR(20)
AS
BEGIN
    BEGIN TRY
        INSERT INTO TblClientes (RazonSocial, IdTipoCliente, FechaCreacion, RFC)
        VALUES (@RazonSocial, @IdTipoCliente, GETDATE(), @RFC);

        SELECT SCOPE_IDENTITY() AS Id;
    END TRY
    BEGIN CATCH
        INSERT INTO LogErrores(Procedimiento, Mensaje) VALUES('sp_CrearCliente', ERROR_MESSAGE());
        THROW;
    END CATCH
END
GO

