namespace FacturaWTW.Application.DTOs
{
    public class ClienteUpdateDTO
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; } = string.Empty;
        public int IdTipoCliente { get; set; }
        public string RFC { get; set; } = string.Empty;
    }
}
