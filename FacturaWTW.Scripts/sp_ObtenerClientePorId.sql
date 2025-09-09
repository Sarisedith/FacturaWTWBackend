CREATE OR ALTER PROCEDURE sp_ObtenerClientePorId
    @ClienteId INT
AS
BEGIN
    BEGIN TRY
        SELECT [Id]
		  ,[RazonSocial]
		  ,[IdTipoCliente]
		  ,[FechaCreacion]
		  ,[RFC]
        FROM TblClientes WITH (NOLOCK)
        WHERE Id = @ClienteId;
    END TRY
    BEGIN CATCH
        INSERT INTO LogErrores(Procedimiento, Mensaje) VALUES('sp_ObtenerClientePorId', ERROR_MESSAGE());
        THROW;
    END CATCH
END
GO
