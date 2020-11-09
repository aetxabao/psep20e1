using System;
using System.Threading;

namespace prodconsthreads
{
    class Program
    {       
        static void Main()
        {
            Caja caja = new Caja(0); 
            Entradas entradas1 = new Entradas(caja);
            Entradas entradas2 = new Entradas(caja);
            Salidas salidas1 = new Salidas(caja);
            Salidas salidas2 = new Salidas(caja);

            Console.WriteLine("INI");

            salidas1.Start();
            salidas2.Start();
            entradas1.Start();
            entradas2.Start();

            entradas1.Finish();
            entradas2.Finish();
            caja.Avisar();
            salidas1.Finish();
            salidas2.Finish();
            caja.Cerrar();

            Console.WriteLine("FIN");
        }
    }
}

// > dotnet run
// INI
// - 50 !!! 0
// - 50 !!! 0
// + 200 --> 200
// + 200 --> 400
// - 50 --> 350
// - 50 --> 300
// + 100 --> 400
// - 150 --> 250
// - 150 --> 100
// + 100 --> 200
// + 50 --> 250
// + 50 --> 300
// - 200 --> 100
// - 200 !!! 100
// - 300 !!! 100
// + 200 --> 300
// - 200 --> 100
// + 200 --> 300
// - 300 --> 0
// + 300 --> 300
// + 300 --> 600
// - 300 --> 300
// - 150 --> 150
// + 150 --> 300
// + 150 --> 450
// - 150 --> 300
// - 50 --> 250
// + 50 --> 300
// + 50 --> 350
// - 100 --> 250
// - 50 --> 200
// + 100 --> 300
// + 100 --> 400
// - 200 --> 200
// + 150 --> 350
// - 100 --> 250
// + 150 --> 400
// - 100 --> 300
// - 200 --> 100
// + 200 --> 300
// + 200 --> 500
// AVISO
// - 200 --> 300
// - 100 --> 200
// - 200 --> 0
// CIERRE
// FIN