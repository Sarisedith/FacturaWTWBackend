namespace FacturaWTW.Application.DTOs
{
    public class ClienteCreateDTO
    {
        public string RazonSocial { get; set; } = string.Empty;
        public int IdTipoCliente { get; set; }
        public string RFC { get; set; } = string.Empty;
    }
}
