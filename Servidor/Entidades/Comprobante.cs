using System.ComponentModel.DataAnnotations;

namespace Servidor.Entidades
{
    public class Comprobante
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El número del comprobante es obligatorio.")]
        [StringLength(50, ErrorMessage = "El número no puede exceder los 50 caracteres.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "La fecha de emisión es obligatoria.")]
        public DateTime FechaEmision { get; set; }

        [Required]
        public TipoComprobante TipoComprobante { get; set; }

        [Required]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }
        public ICollection<Transaccion> Transacciones { get; set; }
    }
    public enum TipoComprobante
    {
        Factura, Boleta, NotaCredito
    }
}
