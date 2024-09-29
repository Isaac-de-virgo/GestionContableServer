using System.ComponentModel.DataAnnotations;

namespace Servidor.Entidades
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del cliente/proveedor es obligatorio.")]
        [StringLength(150, ErrorMessage = "El nombre no puede exceder los 150 caracteres.")]
        public string Nombre { get; set; }

        [Required]
        public TipoEntidad TipoEntidad { get; set; }

        [Required(ErrorMessage = "El número de documento es obligatorio.")]
        [StringLength(20, ErrorMessage = "El documento no puede exceder los 20 caracteres.")]
        public string DocumentoIdentidad { get; set; }

        public ICollection<Comprobante> Comprobantes { get; set; }
    }
    public enum TipoEntidad
    {
        Cliente, Proveedor
    }
}
