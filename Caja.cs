using System;
using System.Threading;

namespace prodconsthreads
{
    public class Caja{
        private readonly object token = new object();
        public int Valor {get;set;}
        private bool estaCerrada = false;

        public Caja(int valor){
            this.Valor = valor;
        }
        public void Incrementar(int valor){
            lock (token)
            {
                if (!estaCerrada){
                    this.Valor += valor;
                    Console.WriteLine("+ {0} --> {1}", valor, Valor);
                    Monitor.Pulse(token);
                }
            }
        }
        public void Decrementar(int valor){
            lock (token)
            {
                if(!estaCerrada){
                    while (this.Valor < valor){
                        if (estaCerrada) return;
                        Console.WriteLine("- {0} !!! {1}", valor, Valor);
                        Monitor.Wait(token);
                    }
                    if (!estaCerrada){
                        this.Valor -= valor;
                        Console.WriteLine("- {0} --> {1}", valor, Valor);
                    }
                }
            }
        }
        
        public void Avisar()
        {
            lock (token)
            {
                Console.WriteLine("AVISO");
                Monitor.PulseAll(token);
            }
        }
        
        public void Cerrar()
        {
            lock (token)
            {
                this.estaCerrada = true;
                Console.WriteLine("CIERRE");
                Monitor.PulseAll(token);
            }
        }
    }

}
