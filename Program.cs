﻿using System;
using System.Threading.Tasks;

namespace taskprodcons
{
    class Caja{
        private readonly object token = new object();
        public int Valor {get;set;}
        public Caja(int valor){
            this.Valor = valor;
        }
        public void Incrementar(int valor){
            //lock (token)
            {
                this.Valor += valor;
            }
        }
        public void Decrementar(int valor){
            //lock (token)
            {
                this.Valor -= valor;
            }
        }
    }

    class Program
    {       
        static void Main()
        {
            Caja caja = new Caja(0); 
            int[] incrementos = {200,100,50,200,300,150,50,100,150,200};//1500
            int[] decrementos = {50,150,200,300,150,50,100,200,100,200};//1500

            Task t1 = Task.Run(() => {
                for(int i=0;i<1000;i++)
                    caja.Incrementar(incrementos[i%10]);
            });
            
            Task t2 = Task.Run(() => {
                for(int i=0;i<1000;i++)
                    caja.Decrementar(decrementos[i%10]);
            });

            t1.Wait();
            t2.Wait();
            
            Console.WriteLine("Caja: {0}",caja.Valor);
        }
    }
}
