namespace Punto2;

public class Cliente : Persona {
    private string datosReferenciaDireccion;
    public Cliente(int ID, string nombre, string direccion, string telefono, string datosReferenciaDireccion):base(ID,nombre,direccion,telefono){
        this.datosReferenciaDireccion = datosReferenciaDireccion;
    }

}