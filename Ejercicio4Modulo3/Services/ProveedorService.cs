using Ejercicio4Modulo3.Domain.Entities;
using Ejercicio4Modulo3.Repository;
using Ejercicio4Modulo3.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio4Modulo3.Services
{
    public class ProveedorService : IProveedorService
    {
        private Clase4Modulo3Context _context;
        public ProveedorService(Clase4Modulo3Context context) {
            _context = context;
        }

        public async Task<List<Proveedor>> getProveedoresAsync()
        {
            return await _context.Proveedor.ToListAsync();
        }

        public async Task<Proveedor> postProveedorAsync(Proveedor proveedor)
        {
            await _context.Proveedor.AddAsync(proveedor);
            await _context.SaveChangesAsync();
            return proveedor;
        }
    }
}
