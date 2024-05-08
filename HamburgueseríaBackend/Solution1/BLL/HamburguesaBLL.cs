using Clases;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class HamburguesaBLL
    {
        private readonly Hamburgueseria _Hamburgueseria;

        // Constructor
        public HamburguesaBLL(Hamburgueseria Hamburgueseria)
        {
            _Hamburgueseria = Hamburgueseria;
        }

        // Obtiene todas las hamburguesas almacenadas en la Base de Datos
        public List<Hamburguesa> ObtenerTodasLasHamburguesas()
        {
            return _Hamburgueseria.Hamburguesa.ToList();
        }

        // Obtiene una hamburguesa por su ID
        public Hamburguesa ObtenerHamburguesaPorId(int idHamburguesa)
        {
            return _Hamburgueseria.Hamburguesa.FirstOrDefault(h => h.idHamburguesa == idHamburguesa);
        }

        // Agrega una hamburguesa a la Base de Datos
        public void AgregarHamburguesa(Hamburguesa hamburguesa)
        {
            _Hamburgueseria.Hamburguesa.Add(hamburguesa);
            _Hamburgueseria.SaveChanges();
        }


        // Actualiza una hamburguesa existente en la Base de Datos
        public void ActualizarHamburguesa(Hamburguesa hamburguesa)
        {
            var existingHamburguesa = _Hamburgueseria.Hamburguesa.Find(hamburguesa.idHamburguesa);
            if (existingHamburguesa == null)
            {
                throw new InvalidOperationException("Hamburguesa no encontrada.");
            }

            existingHamburguesa.nombreHamburguesa = hamburguesa.nombreHamburguesa;
            existingHamburguesa.precio = hamburguesa.precio;
            existingHamburguesa.descripcion = hamburguesa.descripcion;

            _Hamburgueseria.SaveChanges();
        }

        // Elimina una hamburguesa por su ID
        public bool EliminarHamburguesa(int idHamburguesa)
        {
            var hamburguesa = _Hamburgueseria.Hamburguesa.Find(idHamburguesa);
            if (hamburguesa != null)
            {
                _Hamburgueseria.Hamburguesa.Remove(hamburguesa);
                _Hamburgueseria.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
