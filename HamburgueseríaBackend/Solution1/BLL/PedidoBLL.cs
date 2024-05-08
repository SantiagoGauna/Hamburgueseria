using Clases;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class PedidoBLL
    {
        private readonly Hamburgueseria _Hamburgueseria;

        // Constructor
        public PedidoBLL(Hamburgueseria Hamburgueseria)
        {
            _Hamburgueseria = Hamburgueseria;
        }

        // Obtiene todos los pedidos almacenados en la Base de Datos
        public List<Pedido> ObtenerTodosLosPedidos()
        {
            return _Hamburgueseria.Pedido.ToList();
        }

        // Obtiene un pedido por su ID
        public Pedido ObtenerPedidoPorId(int idPedido)
        {
            return _Hamburgueseria.Pedido.FirstOrDefault(p => p.idPedido == idPedido);
        }

        // Agrega un pedido a la Base de Datos
        public void AgregarPedido(Pedido pedido)
        {
            _Hamburgueseria.Pedido.Add(pedido);
            _Hamburgueseria.SaveChanges();
        }

        // Actualiza un pedido existente en la Base de Datos
        public void ActualizarPedido(Pedido pedido)
        {
            var existingPedido = _Hamburgueseria.Pedido.Find(pedido.idPedido);
            if (existingPedido == null)
            {
                throw new InvalidOperationException("Pedido no encontrado.");
            }

            existingPedido.fecha = pedido.fecha;
            existingPedido.cantidad = pedido.cantidad;
            existingPedido.idCliente = pedido.idCliente;
            existingPedido.idHamburguesa = pedido.idHamburguesa;

            _Hamburgueseria.SaveChanges();
        }

        // Elimina un pedido por su ID
        public bool EliminarPedido(int idPedido)
        {
            var pedido = _Hamburgueseria.Pedido.Find(idPedido);
            if (pedido != null)
            {
                _Hamburgueseria.Pedido.Remove(pedido);
                _Hamburgueseria.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
