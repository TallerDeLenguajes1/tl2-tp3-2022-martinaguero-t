namespace Punto2;
using NLog;
class Program {
    static int Main(string[] args){
        
        Logger logger = LogManager.GetCurrentClassLogger();

        Console.WriteLine("===> SISTEMA DE PEDIDOS: ");


        try
        {
            Cadeteria cadeteria = RepositorioCadeteria.obtenerInfoCadeteria();

            List<Cadete> cadetes = RepositorioCadetes.obtenerListaCadetes();

            cadeteria.cargarCadetes(cadetes);

            cadeteria.mostrarInformacion();

            Pedido p1 = new Pedido(1,"Juan","Avenida America 342","3816432854","Porton amarillo frente a heladería");

            Pedido p2 = new Pedido(2,"Sofia","Avenida America 4325","3816432434","Portón blanco");

            Pedido p3 = new Pedido(3,"Pablo","Avenida Sarmiento 435","3816432324","Esquina");

            Pedido p4 = new Pedido(4,"José","Avenida Belgrano 4355","3816434324","Frente a local de ropa");

            cadeteria.asignarPedido(1,p1);
            cadeteria.asignarPedido(2,p2);
            cadeteria.asignarPedido(3,p3);
            cadeteria.asignarPedido(1,p4);

            cadetes[0].entregarPedido(p1);
            cadetes[1].entregarPedido(p2);
            cadetes[0].entregarPedido(p4);
            cadetes[2].entregarPedido(p3);

            cadeteria.mostrarResumen();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hubo un error. El programa se detendrá.");
            logger.Error($"Hubo un error y el programa se detuvo. Mensaje de error: {ex.ToString()}");            
        }

        
        
        return 0;

    }
}