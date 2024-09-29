using System.ComponentModel.DataAnnotations;

namespace Servidor.Entidades
{
    public class Impuesto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del impuesto es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del impuesto no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }

        [Range(0, 100, ErrorMessage = "El porcentaje debe estar entre 0 y 100.")]
        public double Porcentaje { get; set; }

        [Required]
        public TipoImpuesto TipoImpuesto { get; set; }

        public ICollection<TransaccionImpuesto> Transacciones { get; set; }
    }
    public enum TipoImpuesto
    {
        IVA, Renta, Otros
    }
}
