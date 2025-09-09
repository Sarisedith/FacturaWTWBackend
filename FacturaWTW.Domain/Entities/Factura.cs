namespace FacturaWTW.Domain.Entities
{
    public class Factura
    {
        public int Id { get; set; }
        public DateTime FechaEmisionFactura { get; set; }
        public int IdCliente { get; set; }
        public int NumeroFactura { get; set; }
        public int NumeroTotalArticulos { get; set; }
        public decimal SubTotalFacturas { get; set; }
        public decimal TotalImpuestos { get; set; }
        public decimal TotalFactura { get; set; }
        public Cliente Cliente { get; set; }
        public List<DetalleFactura> Detalles { get; set; } = new();
    }
}
