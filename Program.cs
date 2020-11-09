using System;
using System.Threading.Tasks;

namespace latlon
{
    public class Program
    {
        public static void Main()
        {
            string city = "";
            string address = "";
            string fullAddress = "";
            Provider provider = new Provider();

            Console.WriteLine("\nGEOCODING\n");
            Console.WriteLine("https://nominatim.openstreetmap.org/ui/search.html");
            Console.WriteLine("Escribe los datos que se solicitan correctamente.");
            Console.WriteLine("Por ejemplo,");
            Console.WriteLine("Ciudad: Pamplona");
            Console.WriteLine("Dirección: Calle del Milagro");
            Console.WriteLine("Para salir pulsa enter sin escribir nada.\n");

            while(true)
            {
                Console.Write("Ciudad:");
                city = Console.ReadLine();
                if (city.Trim().Length==0) break;
                Console.Write("Dirección:");
                address = Console.ReadLine();
                if (address.Trim().Length==0) break;

                fullAddress = address + ", " + city + ", spain";

                string json = provider.RequestData(fullAddress).Result;               
                
                Console.WriteLine("Respuesta: " + json);
                
                Console.WriteLine("\n");
            }

            Console.WriteLine("FIN\n");

        }

    }
}


// > dotnet run
//
// GEOCODING
//
// https://nominatim.openstreetmap.org/ui/search.html
// Escribe los datos que se solicitan correctamente.
// Por ejemplo,
// Ciudad: Pamplona
// Dirección: Calle del Milagro
// Para salir pulsa enter sin escribir nada.
//
// Ciudad: Pamplona
// Dirección: Plaza Consistorial
// https://nominatim.openstreetmap.org/search?q=plaza+consistorial%2c+pamplona%2c+spain&format=geojson&email=MI_EMAIL_REAL_REGISTRADO&lon=MI_LON_REAL_REGISTRADA&lat=MI_LAT_REAL_REGISTRADA
// Respuesta json: {"type":"FeatureCollection","licence":"Data © OpenStreetMap contributors, ODbL 1.0. https://osm.org/copyright","features":[{"type":"Feature","properties":{"place_id":82758966,"osm_type":"way","osm_id":8403048,"display_name":"Plaza Consistorial, Casco Antiguo, Pamplona/Iruña, Navarra - Nafarroa, 31001, España","place_rank":26,"category":"highway","type":"pedestrian","importance":0.4},"bbox":[-1.6442647,42.8179964,-1.6437161,42.8184623],"geometry":{"type":"Point","coordinates":[-1.6440389684832293,42.81822365]}}]}
//
//
// Ciudad:
// FIN
//