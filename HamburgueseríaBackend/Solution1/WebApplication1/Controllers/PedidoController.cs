using BLL;
using Clases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoBLL _pedidoBLL;
        private readonly ClienteBLL _clienteBLL;
        private readonly HamburguesaBLL _hamburguesaBLL;

        public PedidoController(PedidoBLL pedidoBLL, ClienteBLL clienteBLL, HamburguesaBLL hamburguesaBLL)
        {
            _pedidoBLL = pedidoBLL;
            _clienteBLL = clienteBLL;
            _hamburguesaBLL = hamburguesaBLL;
        }

        // Método para obtener todos los pedidos
        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> Get()
        {
            var pedidos = _pedidoBLL.ObtenerTodosLosPedidos();

            // Obtener detalles de cliente y hamburguesa para cada pedido
            foreach (var pedido in pedidos)
            {
                pedido.Cliente = _clienteBLL.ObtenerClientePorId(pedido.idCliente);
                pedido.Hamburguesa = _hamburguesaBLL.ObtenerHamburguesaPorId(pedido.idHamburguesa);
            }

            return pedidos;
        }

        // Método para obtener un pedido por su ID
        [HttpGet("{idPedido}")]
        public ActionResult<Pedido> Get(int idPedido)
        {
            var pedido = _pedidoBLL.ObtenerPedidoPorId(idPedido);
            if (pedido == null)
            {
                return NotFound();
            }

            // Obtener detalles del cliente
            pedido.Cliente = _clienteBLL.ObtenerClientePorId(pedido.idCliente);
            // Obtener detalles de la hamburguesa
            pedido.Hamburguesa = _hamburguesaBLL.ObtenerHamburguesaPorId(pedido.idHamburguesa);

            return pedido;
        }


        // Método para agregar un nuevo pedido
        [HttpPost]
        public ActionResult<Pedido> Post([FromBody] Pedido pedido)
        {
            try
            {
                // Verificar si el cliente y la hamburguesa existen
                var cliente = _clienteBLL.ObtenerClientePorId(pedido.idCliente);
                var hamburguesa = _hamburguesaBLL.ObtenerHamburguesaPorId(pedido.idHamburguesa);

                if (cliente == null)
                {
                    return NotFound("Cliente no encontrado.");
                }

                if (hamburguesa == null)
                {
                    return NotFound("Hamburguesa no encontrada.");
                }

                // Rellenar el pedido con los detalles del cliente y la hamburguesa
                pedido.Cliente = cliente;
                pedido.Hamburguesa = hamburguesa;

                // Agregar el pedido
                _pedidoBLL.AgregarPedido(pedido);

                // Retornar el pedido creado con los detalles del cliente y la hamburguesa
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al agregar el pedido: {ex.Message}");
            }
        }



        // Método para actualizar un pedido existente
        [HttpPut("{idPedido}")]
        public IActionResult UpdatePedido(int idPedido, [FromBody] Pedido pedido)
        {
            try
            {
                // Obtener el pedido existente por su ID
                var existingPedido = _pedidoBLL.ObtenerPedidoPorId(idPedido);
                if (existingPedido == null)
                {
                    return NotFound("Pedido no encontrado.");
                }

                // Actualizar los campos
                existingPedido.fecha = pedido.fecha;
                existingPedido.cantidad = pedido.cantidad;
                existingPedido.idCliente = pedido.idCliente;
                existingPedido.idHamburguesa = pedido.idHamburguesa;

                // Llamar al método de la BLL para actualizar el pedido
                _pedidoBLL.ActualizarPedido(existingPedido);

                return Ok("Pedido actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el pedido: {ex.Message}");
            }
        }

        // Método para eliminar un pedido por su ID
        [HttpDelete("{idPedido}")]
        public ActionResult Delete(int idPedido)
        {
            var result = _pedidoBLL.EliminarPedido(idPedido);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
