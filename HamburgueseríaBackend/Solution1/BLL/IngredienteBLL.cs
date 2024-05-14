using Clases;
using DAO;


namespace BLL
{
    public class IngredienteBLL
    {
        private readonly Hamburgueseria _hamburgueseria;

        // Constructor
        public IngredienteBLL(Hamburgueseria hamburgueseria)
        {
            _hamburgueseria = hamburgueseria;
        }

        // Obtiene todos los ingredientes almacenados en la Base de Datos
        public List<Ingrediente> ObtenerTodosLosIngredientes()
        {
            return _hamburgueseria.Ingrediente.ToList();
        }

        // Obtiene un ingrediente por su ID
        public Ingrediente ObtenerIngredientePorId(int idIngrediente)
        {
            return _hamburgueseria.Ingrediente.FirstOrDefault(i => i.idIngrediente == idIngrediente);
        }

        // Agrega un ingrediente a la Base de Datos
        public void AgregarIngrediente(Ingrediente ingrediente)
        {
            _hamburgueseria.Ingrediente.Add(ingrediente);
            _hamburgueseria.SaveChanges();
        }

        // Actualiza un ingrediente existente en la Base de Datos
        public void ActualizarIngrediente(Ingrediente ingrediente)
        {
            var existingIngrediente = _hamburgueseria.Ingrediente.Find(ingrediente.idIngrediente);
            if (existingIngrediente == null)
            {
                throw new InvalidOperationException("Ingrediente no encontrado.");
            }

            existingIngrediente.Nombre = ingrediente.Nombre;
            existingIngrediente.Descripcion = ingrediente.Descripcion;
            existingIngrediente.Precio = ingrediente.Precio;

            // Actualiza otras propiedades según sea necesario

            _hamburgueseria.SaveChanges();
        }

        // Elimina un ingrediente por su ID
        public bool EliminarIngrediente(int idIngrediente)
        {
            var ingrediente = _hamburgueseria.Ingrediente.Find(idIngrediente);
            if (ingrediente != null)
            {
                _hamburgueseria.Ingrediente.Remove(ingrediente);
                _hamburgueseria.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
