using System.ComponentModel.DataAnnotations;

namespace Servidor.Entidades
{
    public class TransaccionImpuesto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TransaccionId { get; set; }

        [Required]
        public int ImpuestoId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El monto debe ser un valor positivo.")]
        public double Monto { get; set; }

        public Transaccion Transaccion { get; set; }
        public Impuesto Impuesto { get; set; }
    }
}
