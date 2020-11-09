using System;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;

namespace latlon
{
    public class Provider
    {
        public async Task<string> RequestData(string fullAddress)
        {
            using (var client = new HttpClient())
            {
                 // https://operations.osmfoundation.org/policies/nominatim/
                string url = "https://nominatim.openstreetmap.org/search";
                string format = "geojson";
                string email = "MI_EMAIL_REAL_REGISTRADO";
                string myLat = "MI_LAT_REAL_REGISTRADA";
                string myLon = "MI_LON_REAL_REGISTRADA";
                string uri = url + "?q=" + System.Web.HttpUtility.UrlEncode(Encoding.ASCII.GetBytes(fullAddress.ToLower())) +
                                   "&format=" + format +  "&email=" + email +  "&lon=" + myLon +  "&lat=" + myLat;
                Console.WriteLine(uri);                
                //return await client.GetStringAsync(uri);   // COMENTADO HASTA QUE SE PONGAN PARAMETROS REALES             
                await Task.Delay(2000);     // ESPERA DE TIEMPO QUE SIMULA LA EJECUCIÓN REAL
                return @"{'type':'FeatureCollection','licence':'Data © OpenStreetMap contributors, ODbL 1.0. https://osm.org/copyright','features':[{
                    'type':'Feature',
                    'properties':{
                        'place_id':91117036,
                        'osm_type':'way',
                        'osm_id':23221119,
                        'display_name':'Calle del Milagro, Ovina I, Chantrea, Pamplona/Iruña, Navarra - Nafarroa, 31015, España',
                        'place_rank':26,
                        'category':'highway',
                        'type':'residential',
                        'importance':0.5},
                    'bbox':[-1.6327551,42.8243945,-1.6316539,42.8258287],
                    'geometry':{
                        'type':'Point',
                        'coordinates':[-1.6323499,42.8252655]}
                }]}";
            }
        }
    }
}