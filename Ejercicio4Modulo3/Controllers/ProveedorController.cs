using Ejercicio4Modulo3.Domain.Entities;
using Ejercicio4Modulo3.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio4Modulo3.Controllers
{
    [Route("proveedor")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private IProveedorService _proveedorService;
        public ProveedorController(IProveedorService proveedorService) {
            _proveedorService = proveedorService;
        }

        [HttpGet]
        public async Task<IActionResult> getProveedores()
        {
            var result = await _proveedorService.getProveedoresAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> postProveedores([FromBody] Proveedor proveedor)
        {
            var result = await _proveedorService.postProveedorAsync(proveedor);
            return Ok(result);
        }
    }
}
