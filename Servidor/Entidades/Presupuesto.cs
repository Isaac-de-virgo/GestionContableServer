using System.ComponentModel.DataAnnotations;

namespace Servidor.Entidades
{
    public class Presupuesto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CuentaContableId { get; set; }

        [Range(2000, 2100, ErrorMessage = "El año debe estar entre 2000 y 2100.")]
        public int Anio { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El monto asignado debe ser un valor positivo.")]
        public double MontoAsignado { get; set; }

        public CuentaContable CuentaContable { get; set; }
    }
}
