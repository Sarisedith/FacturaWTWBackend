CREATE OR ALTER PROCEDURE sp_ActualizarCliente
    @Id INT,
    @RazonSocial NVARCHAR(200),
    @IdTipoCliente INT,
    @RFC NVARCHAR(20)
AS
BEGIN
    BEGIN TRY
        UPDATE TblClientes
        SET RazonSocial = @RazonSocial,
            IdTipoCliente = @IdTipoCliente,
            RFC = @RFC
        WHERE Id = @Id;

        SELECT @@ROWCOUNT;
    END TRY
    BEGIN CATCH
        INSERT INTO LogErrores(Procedimiento, Mensaje) VALUES('sp_ActualizarCliente', ERROR_MESSAGE());
        THROW;
    END CATCH
END
GO
