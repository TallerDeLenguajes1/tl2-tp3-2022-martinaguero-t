namespace Punto2;
using NLog;

public class RepositorioCadetes {

    public static List<Cadete> obtenerListaCadetes(){
        
        Logger logger = LogManager.GetCurrentClassLogger();

        string ruta = "informacion\\listadoCadetes.csv";
        List<Cadete> cadetes = new List<Cadete>();

        int IDCadete = 0;

        try
        {
            using(StreamReader sr = new StreamReader(ruta)){
                string? linea = sr.ReadLine();
                while(linea != null){

                    string[] datosCadete = linea.Split(";");
                    Int32.TryParse(datosCadete[0], out IDCadete);

                    cadetes.Add(new Cadete(IDCadete,datosCadete[1],datosCadete[2],datosCadete[3]));

                    linea = sr.ReadLine();
                }
            }
            
        }
        catch (FileNotFoundException ex)
        {
            logger.Debug("No se pudo encontrar el archivo con la información de los cadetes. Mensaje de error: "+ex.Message);

            File.Create(ruta);
            throw new FileNotFoundException("No se encontró el archivo con la información de los cadetes.",ex);

        } 
        catch (DirectoryNotFoundException ex2)
        {
            logger.Debug("No se pudo encontrar el directorio con la información de los cadetes. Mensaje de error: "+ex2.Message);

            
            Directory.CreateDirectory("informacion");
            File.Create(ruta);

            throw new DirectoryNotFoundException("No se encontró el directorio con el archivo con la información de los cadetes.",ex2);
            
        } 
        catch (Exception ex3)
        {
            logger.Error("Hubo un error en la carga de los cadetes. Mensaje de error: "+ex3.Message);

            throw new Exception($"Hubo un error. {ex3}.",ex3);

        }

        if(!cadetes.Any()){
            logger.Debug("No se encontró información de cadetes en el archivo.");
            throw new Exception("No se encontró información de cadetes en el archivo.");
        }

        return cadetes; 

    }

}