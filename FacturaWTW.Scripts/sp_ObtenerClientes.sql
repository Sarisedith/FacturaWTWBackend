CREATE OR ALTER PROCEDURE sp_ObtenerClientes
AS
BEGIN
    BEGIN TRY
        SELECT [Id]
		  ,[RazonSocial]
		  ,[IdTipoCliente]
		  ,[FechaCreacion]
		  ,[RFC]
        FROM TblClientes WITH (NOLOCK);
    END TRY
    BEGIN CATCH
        INSERT INTO LogErrores(Procedimiento, Mensaje) VALUES('sp_ObtenerClientes', ERROR_MESSAGE());
        THROW;
    END CATCH
END
GO
