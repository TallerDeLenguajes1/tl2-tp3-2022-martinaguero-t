namespace Punto2;

public class Pedido {

    private static int autonumerico = 0; // GUID
    private int numero;
    private string observaciones;
    private bool estaRealizado;

    Cliente cliente; 

    public Pedido(int IDCliente, string nombreCliente, string direccionCliente, string telefonoCliente, string datosReferenciaDireccionCliente, string observaciones = ""){
        this.numero = autonumerico;
        autonumerico++;
        this.observaciones = observaciones;
        this.estaRealizado = false;
        this.cliente = new Cliente(IDCliente, nombreCliente, direccionCliente, telefonoCliente, datosReferenciaDireccionCliente);
    }
    public int getNumero(){
        return this.numero;
    }
    public bool pedidoRealizado(){
        return this.estaRealizado;
    }

    public void marcarComoRealizado(){
        this.estaRealizado = true;
    }

    public void mostrarInformacionPedido(){
        Console.WriteLine(" > Información del pedido: ");
        Console.WriteLine($"  - Información del cliente: ");
        this.cliente.mostrarInformacion();
        Console.WriteLine($"  - Número: {this.numero}");
        string estado = this.estaRealizado ? "Realizado" : "Pendiente";
        Console.WriteLine($"  - Estado: {estado}");
        string observaciones = this.observaciones == "" ? "Sin observaciones" : this.observaciones;
        Console.WriteLine($"  - Observaciones: {observaciones}");
    }
    


}