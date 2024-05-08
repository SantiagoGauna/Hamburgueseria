namespace Clases
{
    public class Pedido
    {
        public int idPedido { get; private set; }
        public DateTime fecha { get; set; }
        public int cantidad { get; set; }
        public int idCliente { get; set; } // ID del cliente asociado al pedido
        public int idHamburguesa { get; set; } // ID de la hamburguesa asociada al pedido

        // Propiedades de navegación para acceder a los detalles del cliente y la hamburguesa
        public Cliente Cliente { get; set; }
        public Hamburguesa Hamburguesa { get; set; }

        // Constructor
        public Pedido(int idPedido, DateTime fecha, int cantidad, int idCliente, int idHamburguesa)
        {
            this.fecha = fecha;
            this.cantidad = cantidad;
            this.idCliente = idCliente;
            this.idHamburguesa = idHamburguesa;
        }
    }
}
