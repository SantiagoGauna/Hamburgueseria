﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clases
{
    public class Hamburguesa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idHamburguesa { get; private set; }

        public string NombreHamburguesa { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }

        // Constructor
        public Hamburguesa(string nombreHamburguesa, string descripcion, int precio)
        {
            NombreHamburguesa = nombreHamburguesa;
            Descripcion = descripcion;
            Precio = precio;
        }
    }
}
