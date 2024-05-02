using Formulario.Data;
using Formulario.Model;

namespace Formulario.Service
{
    public class FormacionService
    {
        private readonly FormularioContext _context;

        public FormacionService(FormularioContext context)
        {
            _context = context;
        }

        public async Task GuardarFormacion(Formacion formacion)
        {
            _context.Formaciones.Add(formacion);
            await _context.SaveChangesAsync();
        }
    }
}