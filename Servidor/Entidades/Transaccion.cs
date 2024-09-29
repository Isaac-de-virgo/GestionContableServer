using System.ComponentModel.DataAnnotations;

namespace Servidor.Entidades
{
    public class Transaccion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(255, ErrorMessage = "La descripción no puede exceder los 255 caracteres.")]
        public string Descripcion { get; set; }

        [Required]
        public int ComprobanteId { get; set; }        
        public Comprobante Comprobante { get; set; }        

        public ICollection<Partida> Partidas { get; set; }
        public ICollection<TransaccionImpuesto> Impuestos { get; set; }
    }
}
