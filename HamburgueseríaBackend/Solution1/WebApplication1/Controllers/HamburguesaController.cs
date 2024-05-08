using BLL;
using Clases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HamburguesaController : ControllerBase
    {
        private readonly HamburguesaBLL _hamburguesaBLL; // Instancia de HamburguesaBLL

        public HamburguesaController(HamburguesaBLL hamburguesaBLL)
        {
            _hamburguesaBLL = hamburguesaBLL; // Constructor que inicializa la instancia de HamburguesaBLL
        }

        // Método para obtener todas las hamburguesas
        [HttpGet]
        public ActionResult<IEnumerable<Hamburguesa>> Get()
        {
            return _hamburguesaBLL.ObtenerTodasLasHamburguesas();
        }

        // Método para obtener una hamburguesa por su ID
        [HttpGet("{idHamburguesa}")]
        public ActionResult<Hamburguesa> Get(int idHamburguesa)
        {
            var hamburguesa = _hamburguesaBLL.ObtenerHamburguesaPorId(idHamburguesa);
            if (hamburguesa == null)
            {
                return NotFound();
            }
            return hamburguesa;
        }
        [HttpPost]
        public ActionResult Post([FromBody] Hamburguesa hamburguesa)
        {

            _hamburguesaBLL.AgregarHamburguesa(hamburguesa);
            return Ok();
        }


        // Método para actualizar una hamburguesa existente
        [HttpPut("{idHamburguesa}")]
        public IActionResult UpdateHamburguesa(int idHamburguesa, [FromBody] Hamburguesa hamburguesa)
        {
            try
            {
                // Obtener la hamburguesa existente por su ID
                var existingHamburguesa = _hamburguesaBLL.ObtenerHamburguesaPorId(idHamburguesa);
                if (existingHamburguesa == null)
                {
                    return NotFound("Hamburguesa no encontrada.");
                }

                // Actualizar los campos
                existingHamburguesa.nombreHamburguesa = hamburguesa.nombreHamburguesa;
                existingHamburguesa.descripcion = hamburguesa.descripcion;
                existingHamburguesa.precio = hamburguesa.precio;

                // Llamar al método de la BLL para actualizar la hamburguesa
                _hamburguesaBLL.ActualizarHamburguesa(existingHamburguesa);

                return Ok("Hamburguesa actualizada correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar la hamburguesa: {ex.Message}");
            }
        }

        // Método para eliminar una hamburguesa por su ID
        [HttpDelete("{idHamburguesa}")]
        public ActionResult Delete(int idHamburguesa)
        {
            var result = _hamburguesaBLL.EliminarHamburguesa(idHamburguesa);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
