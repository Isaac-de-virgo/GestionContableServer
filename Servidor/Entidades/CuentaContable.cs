using System.ComponentModel.DataAnnotations;

namespace Servidor.Entidades
{
    public class CuentaContable
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El código es obligatorio.")]
        [StringLength(20, ErrorMessage = "El código no puede exceder los 20 caracteres.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre de la cuenta es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El tipo de cuenta es obligatorio.")]
        public TipoCuenta TipoCuenta { get; set; }

        public int? CuentaPadreId { get; set; }

        public CuentaContable CuentaPadre { get; set; }
        public ICollection<CuentaContable> SubCuentas { get; set; }
    }
    public enum TipoCuenta
    {
        Activo, Pasivo, Patrimonio, Ingreso, Gasto
    }
}
