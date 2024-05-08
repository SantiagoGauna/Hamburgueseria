using BLL;
using Clases;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteBLL _clienteBLL; // Instancia de ClienteBLL

        public ClienteController(ClienteBLL clienteBLL)
        {
            _clienteBLL = clienteBLL; // Constructor que inicializa la instancia de ClienteBLL
        }

        // Método para obtener todos los clientes
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            return _clienteBLL.ObtenerTodosLosClientes();
        }

        // Método para obtener un cliente por su ID
        [HttpGet("{idCliente}")]
        public ActionResult<Cliente> Get(int idCliente)
        {
            var cliente = _clienteBLL.ObtenerClientePorId(idCliente);
            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }


        // Método para agregar un nuevo cliente
        [HttpPost]
        public ActionResult Post([FromBody] Cliente cliente)
        {
            
            _clienteBLL.AgregarCliente(cliente);
            return Ok();
        }

        // Método para actualizar un cliente existente
        [HttpPut("{id}")]
        public IActionResult UpdateCliente(int id, [FromBody] Cliente cliente)
        {
            try
            {
                // Obtener el cliente existente por su ID
                var existingCliente = _clienteBLL.ObtenerClientePorId(id);
                if (existingCliente == null)
                {
                    return NotFound("Cliente no encontrado.");
                }

                // Actualizar solo los campos 
                existingCliente.nombre = cliente.nombre;
                existingCliente.apellido = cliente.apellido;

                // Llamar al método de la BLL para actualizar el cliente
                _clienteBLL.UpdateCliente(existingCliente);

                return Ok("Cliente actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar el cliente: {ex.Message}");
            }
        }



        // Método para eliminar un cliente por su ID
        [HttpDelete("{idCliente}")]
        public ActionResult Delete(int idCliente)
        {
            var result = _clienteBLL.EliminarCliente(idCliente);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
