namespace Punto2;
using NLog;

public class RepositorioCadeteria {
    
    public static Cadeteria obtenerInfoCadeteria(){
        
        Cadeteria? cadeteria = null; 

        Logger logger = LogManager.GetCurrentClassLogger();

        string ruta = "informacion\\infoCadeteria.csv";

        try
        {
            using(StreamReader sr = new StreamReader(ruta)){

                string? linea = sr.ReadLine();
                
                if(linea != null){
                    
                    string[] infoCadeteria = linea.Split(";");

                    cadeteria = new Cadeteria(infoCadeteria[0], infoCadeteria[1]);
                    
                }

            }
            
        }
        catch (FileNotFoundException ex)
        {
            logger.Debug("No se pudo encontrar el archivo con la información de la cadetería. Se creará un archivo vacío. Mensaje de error: "+ex.Message);

            File.Create(ruta);

            throw new FileNotFoundException("No se encontró el archivo con la información de la cadetería.",ex);

        } 
        catch (DirectoryNotFoundException ex2)
        {
            logger.Debug("No se pudo encontrar el directorio con la información de la cadetería. Se creará el directorio y un archivo vacío. Mensaje de error: "+ex2.Message);

            Directory.CreateDirectory("informacion");
            File.Create(ruta);

            throw new DirectoryNotFoundException("No se encontró el directorio con el archivo con la información de la cadetería.",ex2);
            
        } 
        catch (Exception ex3)
        {
            logger.Error("Hubo un error en la carga de la cadetería. Mensaje de error: "+ex3.Message);

            throw new Exception($"Hubo un error en la carga de la cadetería. Mensaje de error: {ex3.Message}",ex3);
        }

        if(cadeteria == null){
            logger.Debug("No se pudo encontrar información de la cadetería en el archivo.");
            throw new Exception("No se encontró información de la cadetería en el archivo.");
        }

        return cadeteria;
    }

}