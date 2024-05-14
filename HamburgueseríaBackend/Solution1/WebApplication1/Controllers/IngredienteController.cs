using BLL;
using Clases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredienteController : ControllerBase
    {
        private readonly IngredienteBLL _ingredienteBLL; // Instancia de IngredienteBLL

        public IngredienteController(IngredienteBLL ingredienteBLL)
        {
            _ingredienteBLL = ingredienteBLL; // Constructor que inicializa la instancia de IngredienteBLL
        }

        // Método para obtener todos los ingredientes
        [HttpGet]
        public ActionResult<IEnumerable<Ingrediente>> Get()
        {
            return _ingredienteBLL.ObtenerTodosLosIngredientes();
        }

        // Método para obtener un ingrediente por su ID
        [HttpGet("{idIngrediente}")]
        public ActionResult<Ingrediente> Get(int idIngrediente)
        {
            var ingrediente = _ingredienteBLL.ObtenerIngredientePorId(idIngrediente);
            if (ingrediente == null)
            {
                return NotFound();
            }
            return ingrediente;
        }

        // Método para agregar un ingrediente
        [HttpPost]
        public ActionResult Post([FromBody] Ingrediente ingrediente)
        {
            _ingredienteBLL.AgregarIngrediente(ingrediente);
            return Ok();
        }

        // Método para actualizar un ingrediente existente
        [HttpPut("{idIngrediente}")]
        public IActionResult UpdateIngrediente(int idIngrediente, [FromBody] Ingrediente ingrediente)
        {
            try
            {
                // Obtener el ingrediente existente por su ID
                var existingIngrediente = _ingredienteBLL.ObtenerIngredientePorId(idIngrediente);
                if (existingIngrediente == null)
                {
                    return NotFound("Ingrediente no encontrado.");
                }

                // Actualizar los campos
                existingIngrediente.Nombre = ingrediente.Nombre;
                existingIngrediente.Descripcion = ingrediente.Descripcion;
                existingIngrediente.Precio = ingrediente.Precio;
                // Actualizar otras propiedades según sea necesario

                // Llamar al método de la BLL para actualizar el ingrediente
                _ingredienteBLL.ActualizarIngrediente(existingIngrediente);

                return Ok("Ingrediente actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el ingrediente: {ex.Message}");
            }
        }

        // Método para eliminar un ingrediente por su ID
        [HttpDelete("{idIngrediente}")]
        public ActionResult Delete(int idIngrediente)
        {
            var result = _ingredienteBLL.EliminarIngrediente(idIngrediente);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
