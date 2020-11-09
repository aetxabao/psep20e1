using System;
using System.Threading;

namespace prodconsthreads
{
    class Program
    {       
        static void Main()
        {
            Caja caja = new Caja(0); 
            Entradas entradas = new Entradas(caja);
            Salidas salidas = new Salidas(caja);

            Console.WriteLine("INI");

            entradas.Start();
            salidas.Start();

            entradas.Finish();
            caja.Avisar();
            salidas.Finish();
            caja.Cerrar();

            Console.WriteLine("FIN");
        }
    }
}

// > dotnet run
// INI
// + 200 --> 200
// - 50 --> 150
// + 100 --> 250
// - 150 --> 100
// + 50 --> 150
// - 200 !!! 150
// + 200 --> 350
// - 200 --> 150
// - 300 !!! 150
// + 300 --> 450
// - 300 --> 150
// + 150 --> 300
// - 150 --> 150
// + 50 --> 200
// - 50 --> 150
// + 100 --> 250
// - 100 --> 150
// + 150 --> 300
// + 200 --> 500
// - 200 --> 300
// AVISO
// - 100 --> 200
// - 200 --> 0
// CIERRE
// FIN