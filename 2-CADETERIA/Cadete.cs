namespace Punto2;

public class Cadete : Persona {

    private List<Pedido> pedidos;
    public Cadete(int ID, string nombre, string direccion, string telefono):base(ID,nombre,direccion,telefono){
        this.pedidos = new List<Pedido>();
    }

    public void asignarPedido(Pedido pedido){
        this.pedidos.Add(pedido);
    }

    public void borrarPedido(int nroPedido){
  
        Pedido? buscado = this.pedidos.Find(pedido => pedido.getNumero() == nroPedido);

        if(buscado != null && buscado.pedidoRealizado() != true){
            // No elimino un pedido que ya esté realizado.
            this.pedidos.Remove(buscado);
        }

    }

    public Pedido? quitarPedido(int nroPedido){

        Pedido? buscado = this.pedidos.Find(pedido => pedido.getNumero() == nroPedido);

        if(buscado != null && buscado.pedidoRealizado() != true){
            // No elimino un pedido que ya esté realizado.
            this.pedidos.Remove(buscado);
        } else {

            if(buscado == null){
                Console.WriteLine("El pedido buscado no existe o no está asignado a este cadete.");
                // logger - si
            } else {
                Console.WriteLine("No se pueden eliminar pedidos ya realizados por el cadete.");
            }

        }

        return buscado;
    }

    public void entregarPedido(Pedido pedido){
        pedido.marcarComoRealizado();
    }

    public double jornalACobrar(){
        double jornal = pedidos.Where(pedido => pedido.pedidoRealizado() == true).Count() * 300;
        return jornal;
    }

    public int obtenerNumeroPedidosEntregados(){
        int numPedidos = pedidos.Where(pedido => pedido.pedidoRealizado() == true).Count();
        return numPedidos;
    }

}