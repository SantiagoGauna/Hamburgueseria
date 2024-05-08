using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clases
{
    public class Hamburguesa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idHamburguesa { get; private set; }
        public string nombreHamburguesa { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }


        public Hamburguesa(string nombreHamburguesa, string descripcion, int precio)
        {
            this.nombreHamburguesa = nombreHamburguesa;
            this.descripcion = descripcion;
            this.precio = precio;
        }
    }

}
