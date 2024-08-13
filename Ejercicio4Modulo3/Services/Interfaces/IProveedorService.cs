using Ejercicio4Modulo3.Domain.Entities;

namespace Ejercicio4Modulo3.Services.Interfaces
{
    public interface IProveedorService
    {
        public Task<List<Proveedor>> getProveedoresAsync();
        public Task<Proveedor> postProveedorAsync(Proveedor proveedor);
    }
}
