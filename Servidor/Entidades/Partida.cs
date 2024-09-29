using System.ComponentModel.DataAnnotations;

namespace Servidor.Entidades
{
    public class Partida
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TransaccionId { get; set; }

        [Required]
        public int CuentaContableId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El monto en el Debe debe ser un valor positivo.")]
        public double Debe { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El monto en el Haber debe ser un valor positivo.")]
        public double Haber { get; set; }

        public Transaccion Transaccion { get; set; }
        public CuentaContable CuentaContable { get; set; }
    }
}
