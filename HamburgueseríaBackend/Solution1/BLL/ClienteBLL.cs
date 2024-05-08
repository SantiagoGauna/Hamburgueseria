using Clases;
using DAO;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class ClienteBLL
    {
        private readonly Hamburgueseria _Hamburgueseria;

        //Constructor
        public ClienteBLL(Hamburgueseria Hamburgueseria)
        {
            _Hamburgueseria = Hamburgueseria;
        }

        // Obtiene todos los clientes almacenados en la Base de Datos
        public List<Cliente> ObtenerTodosLosClientes()
        {
            return _Hamburgueseria.Cliente.ToList();
        }

        // Obtiene un cliente por su ID
        public Cliente ObtenerClientePorId(int idCliente)
        {
            return _Hamburgueseria.Cliente.FirstOrDefault(c => c.idCliente == idCliente);
        }

        // Agrega un cliente a la Base de Datos
        public void AgregarCliente(Cliente cliente)
        {
            _Hamburgueseria.Cliente.Add(cliente);
            _Hamburgueseria.SaveChanges();
        }

        // Actualiza un cliente existente en la Base de Datos
        public void UpdateCliente(Cliente cliente)
        {
            var existingCliente = _Hamburgueseria.Cliente.Find(cliente.idCliente);
            if (existingCliente == null)
            {
                throw new InvalidOperationException("Cliente no encontrado.");
            }

            existingCliente.nombre = cliente.nombre;
            existingCliente.apellido = cliente.apellido;

            _Hamburgueseria.SaveChanges();
        }


        // Elimina un cliente por su ID
        public bool EliminarCliente(int idCliente)
        {
            var cliente = _Hamburgueseria.Cliente.Find(idCliente);
            if (cliente != null)
            {
                _Hamburgueseria.Cliente.Remove(cliente);
                _Hamburgueseria.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
