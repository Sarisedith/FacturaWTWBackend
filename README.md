Esta solución contiene los proyectos:
- FacturaWTW.API
- FacturaWTW.Application
- FacturaWTW.Domain
- FacturaWTW.Infrastructure

Pasos rápidos:
1. Abrir la solución `FacturaWTW.sln` en Visual Studio o usar `dotnet` CLI.
2. Actualizar `appsettings.json` con la cadena de conexión real.
3. Ejecutar scripts SQL en `FacturaWTW.Scripts` para crear tablas y procedimientos.
4. `dotnet restore` y `dotnet build`.
5. Ejecutar API: `dotnet run --project FacturaWTW.API`

Notas:
- Repositorios usan Dapper y stored procedures.
- Las consultas en SP usan `WITH (NOLOCK)` y los SPs registran errores en `LogErrores`.
- Validación con FluentValidation y mapeo con AutoMapper.
