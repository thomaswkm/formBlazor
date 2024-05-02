using Microsoft.EntityFrameworkCore;
using Formulario.Model;


namespace Formulario.Data
{
    public class FormularioContext : DbContext
    {
        public FormularioContext(DbContextOptions<FormularioContext> options) : base(options)
        {
        }

        public DbSet<Formacion> Formaciones { get; set; }
    }
}