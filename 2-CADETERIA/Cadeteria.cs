namespace Punto2;
using NLog;
public class Cadeteria {

    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    private string nombre;
    private string telefono;
    private List<Cadete> cadetes;
    public Cadeteria(string nombre, string telefono){
        this.nombre = nombre;
        this.telefono = telefono;
        this.cadetes = new List<Cadete>();
    }

    public void asignarPedido(int IDCadete, Pedido pedido){
        Cadete? cadete = this.cadetes.Find(cadete => cadete.getID() == IDCadete);
        if(cadete == null){
            Console.WriteLine("No se encontró el cadete al que se desea asignar el pedido. ");
        } else {
            cadete.asignarPedido(pedido);
        }
    }
    public void listarCadetes(){
        Console.WriteLine(" - Listado de cadetes: ");
        if (cadetes.Any())
        {
            foreach(var cadete in cadetes){
                cadete.mostrarInformacion();
            }
        } else {
            Console.WriteLine("No se encontraron cadetes. ");
        }
    }

    public void cargarCadetes(List<Cadete> listadoCadetes){
        cadetes = listadoCadetes;
    }

    public void mostrarInformacion(){
        Console.WriteLine("=> Información de la cadetería: ");
        Console.WriteLine($" - Nombre: {this.nombre}");
        Console.WriteLine($" - Teléfono: {this.telefono}");
        this.listarCadetes();
    }

    public void reasignarPedido(Cadete cadete1, Cadete cadete2, int nroPedido){

        Pedido? reasignar = cadete1.quitarPedido(nroPedido);

        if(reasignar != null){
            cadete2.asignarPedido(reasignar);
            logger.Info($"Se reasignó un pedido del cadete ID {cadete1.getID()}al cadete ID {cadete2.getID()}");
        } 
        
    }

    public void mostrarResumen(){
        Console.WriteLine("=> RESUMEN: ");
        int numPedidosEntregados = 0;
        foreach (Cadete cadete in this.cadetes)
        {
            numPedidosEntregados = cadete.obtenerNumeroPedidosEntregados();
            Console.WriteLine($"  -> Cantidad de envíos del cadete de ID {cadete.getID()}: {numPedidosEntregados}");
        }
        Console.WriteLine($"  -> Cantidad total de envíos: {this.obtenerTotalEnvios()}");
        Console.WriteLine($"  -> Cantidad de envíos promedio por cadete: {this.calcularEnviosPromedioPorCadete()}");
        Console.WriteLine($"  -> Monto ganado por los cadetes: {this.obtenerMontoGanado()}");

    }
    public int obtenerTotalEnvios(){
        int totalEnvios = 0;
        foreach (Cadete cadete in this.cadetes)
        {
            totalEnvios+=cadete.obtenerNumeroPedidosEntregados();
        }
        return totalEnvios;
    }
    public double obtenerMontoGanado(){
        double montoGanado = 0;
        foreach (Cadete cadete in this.cadetes)
        {
            montoGanado += cadete.jornalACobrar();
        }
        return montoGanado;
    }

    public int calcularEnviosPromedioPorCadete(){

        int enviosPromedio = 0;
        foreach (Cadete cadete in this.cadetes)
        {
            enviosPromedio += cadete.obtenerNumeroPedidosEntregados();
        }
        enviosPromedio = (int) (enviosPromedio/this.cadetes.Count());

        return enviosPromedio;
    }
    
}