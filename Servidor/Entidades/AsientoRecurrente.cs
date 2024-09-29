using System.ComponentModel.DataAnnotations;

namespace Servidor.Entidades
{
    public class AsientoRecurrente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CuentaContableId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El monto debe ser un valor positivo.")]
        public double Monto { get; set; }

        [Required]
        public Frecuencia Frecuencia { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public DateTime FechaInicio { get; set; }

        public CuentaContable CuentaContable { get; set; }
    }
    public enum Frecuencia
    {
        Mensual, Trimestral, Anual
    }
}
