using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clases
{
    public class Ingrediente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idIngrediente { get; private set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }

        // Constructor
        public Ingrediente(string nombre, string descripcion, int precio)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
        }
    }
}
