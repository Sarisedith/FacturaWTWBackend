namespace FacturaWTW.Application.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public decimal PrecioUnitario { get; set; }
        public string? Ext { get; set; }
    }
}
