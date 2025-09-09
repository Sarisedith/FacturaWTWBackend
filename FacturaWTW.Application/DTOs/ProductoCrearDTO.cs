namespace FacturaWTW.Application.DTOs
{
    public class ProductoCrearDTO
    {
        public string NombreProducto { get; set; } = string.Empty;
        public decimal PrecioUnitario { get; set; }
        public byte[]? ImagenProducto { get; set; }
        public string? Ext { get; set; }
    }
}
