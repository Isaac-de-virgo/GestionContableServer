using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Servidor.Entidades;

namespace Servidor.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        DbSet<AsientoRecurrente> AsientoRecurrentes { get; set; }
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Comprobante> Comprobantes { get; set; }
        DbSet<CuentaContable> CuentaContables { get; set; }
        DbSet<Impuesto> Impuestos { get; set; }
        DbSet<Partida> Partidas { get; set; }
        DbSet<Presupuesto> Presupuestos { get; set; }
        DbSet<Transaccion> Transacciones { get; set; }
        DbSet<TransaccionImpuesto> TransaccionImpuestos { get; set; }
    }
}
