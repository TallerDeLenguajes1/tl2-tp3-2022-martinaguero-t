namespace Punto2;

public class Persona {

    private int ID;
    private string nombre;
    private string direccion;
    private string telefono;

    public Persona (int ID, string nombre, string direccion, string telefono){
        this.ID = ID;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
    }   

    public virtual void mostrarInformacion(){
        Console.WriteLine("  => DATOS de la persona: ");
        Console.WriteLine($"   -> ID: {this.ID}");
        Console.WriteLine($"   -> Nombre: {this.nombre}");
        Console.WriteLine($"   -> Direccion: {this.direccion}");
        Console.WriteLine($"   -> Teléfono: {this.telefono}");
    }

    public int getID(){
        return this.ID;
    }
}

