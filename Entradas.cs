using System;
using System.Threading;

namespace prodconsthreads
{
    public class Entradas{
        
        int[] incrementos = {200,100,50,200,300,150,50,100,150,200};//1500

        private Caja caja;
        private Thread thread;

        public Entradas(Caja caja)
        {
            this.caja = caja;
        }
        public void Start()
        {
            this.thread = new Thread(() => this.Agenda());
            this.thread.Start();
        }

        public void Finish()
        {
            thread.Join();
        }

        private void Agenda()
        {
            int t;
            Random rnd = new Random();
            for(int i=0;i<10;i++){
                t = rnd.Next(3,5);
                Thread.Sleep(t);
                caja.Incrementar(incrementos[i]);
            }
        }
    }
}