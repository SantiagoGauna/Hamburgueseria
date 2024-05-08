using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clases
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCliente { get; private set; } // Hacer el set privado para que no me tome el id en el post
        public string nombre { get; set; }
        public string apellido { get; set; }

        // Constructor sin el idCliente
        public Cliente(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }
    }
}
