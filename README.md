###### Programación de Servicios y Procesos.		                2º DAM	
# Examen 1ª evaluación	
### Nombre y apellidos:  __________________________			
1. Se quiere hacer un programa de Geocoding en el que se obtenga la latitud y longitud de la dirección de una ciudad. Para ello en el programa se solicita primero la ciudad y luego la dirección para construir una url que devuelve un texto en formato JSON con la información que interesa que en otro programa habría que procesar. Si en la ciudad o la dirección no se escribe nada el programa debe finalizar, sino, se podrá consultar todas las direcciones que se deseen. Se puede ver el resultado esperado en la imagen 1.
El programa utiliza una clase Provider que tiene un método que tardará en regresar la información JSON deseada. En la línea 22 de este fichero se imprime la url que se utiliza y si se prueba en un navegador funciona. En las policies de este servicio se avisa que no se debe hacer más de una consulta por segundo,  de hecho es lento y puede tardar más.
El problema está en la clase Program que da un error. Utiliza tus conocimientos de programación de tareas asíncronas y escribe una solución para que se pueda imprimir el resultado correctamente.
La corrección del código supone menos de cinco palabras clave. Razona los cambios para que la respuesta sea dada por valida. 2,5 puntos.

2. Se quiere demostrar que el acceso a un recurso compartido sobre el cual se hacen operaciones que deberían ser atómicas si no se utiliza un “lock” sobre un objeto común los resultados son inesperados.
Para ello en el fichero Program.cs se ha creado una clase Caja que tiene las operaciones Incrementar y Decrementar con el la sentencia lock(token) comentada. En el método principal, Main, de la clase Program se instancia una caja y se han definido dos arrays de 10 enteros cuya suma es la misma. Es decir, si a la caja se le suma todos los valores de un array y se le resta todos los valores del otro array, el valor de la caja será el que tendría al inicio, independientemente de si esto se hace 100 veces.
Escribir el código en el que dos tareas independientes incrementarán y decrementarán estos valores 100 veces sobre la misma caja. Dentro de estas tareas se ejecutarán los métodos caja.Incrementar y caja.Decrementar pasándoles como argumento el valor de cada array correspondiente en cada iteración, de forma que al final se habrán incrementado y decrementado 1000 valores cuya suma es igual.
Escribe el código que ejecute estas dos tareas y espere su finalización para que al final se imprima el valor de la caja y se demuestre la necesidad de utilizar los lock. El código pedido debería ocupar de 10 a 20 líneas, no más. 2,5 puntos.

3. Se quiere implementar el problema del productor consumidor utilizando hilos. La clase Entradas incrementará la caja cada vez con un valor del array incrementos. Por otra parte, la clase Salidas decrementará la caja utilizando el array decrementos. El problema es que no se debe permitir que el valor de la caja sea menor que cero en ningún momento. Cuando se vaya a decrementar un valor, si el resultado de la caja fuese negativo, el hilo debe esperar a ser notificado para comprobar nuevamente si se puede realizar la operación. Cuando se pueda realizar, se restará al Valor de la caja el valor pasado cómo parámetro y se ejecutará un return para salir del método. Según la circunstancia se imprimirá un mensaje de log u otro. Se tiene que tener en cuenta que la comprobación se hará siempre y cuando la caja no esté cerrada. En concreto, hay que escribir el código que falta del método Decrementar de la clase Caja. Incluyendo las líneas que sólo contienen una llave el código a escribir sería menor a 15 líneas (sólo código menos de 10 incluyendo los logs). 2,5 puntos.

4. Continuando con el planteamiento del ejercicio anterior, escribe el código del método Main para que haya dos hilos de entradas y dos hilos de salidas. Entre los mensajes “INI” y “FIN” se deben iniciar todos los hilos y esperar al fin de su ejecución. La caja se debe empezar con un valor 0 y primero se tienen que iniciar los hilos de salidas (al menos en el orden que se escribe el código). Qué sucede si el primer hilo intenta sacar 50, luego el siguiente hilo intenta sacar otros 50 y a continuación se ingresa 200 en otro hilo? En el código del ejercicio 3 se notificaría a ambos hilos? Qué instrucción se debería utilizar para ser más eficientes? Por qué crees que se debe avisar que se va a cerrar la caja, esperar a que terminen las salidas y finalmente cerrar la caja? Escribe el código solicitado similar al del ejercicio 3 pero con 2 entradas y 2 salidas y responde a las preguntas realizadas. La puntuación de las respuestas de las preguntas es 1,5 y el código 1 punto.

<br>

## Ejercicio 1.

<br>

![Alt text](/assets/imagen1.png?raw=true "Imagen 1")
<p style="text-align: center;">
- Imagen 1.  Ejecución esperada del programa 1 funcionando correctamente. -
</p>
<br>

![Alt text](/assets/imagen2.png?raw=true "Imagen 2")
<p style="text-align: center;">
- Imagen 2.  Código de la clase Provider que tiene el método que solicita la información. -
</p>
<br>

![Alt text](/assets/imagen3.png?raw=true "Imagen 3")
<p style="text-align: center;">
- Imagen 3.  Código del método principal erróneo del programa. -
</p>
<br>
<br>
<br>
<br>
<br>

*Escribir sobre el código las correcciones y encima de esta línea el razonamiento.*

<br>
<br>

## Ejercicio 2.

<br>

![Alt text](/assets/imagen4.png?raw=true "Imagen 4")
<p style="text-align: center;">
- Imagen 4.  Resultados de la ejecución del programa si no se utiliza lock. -
</p>
<br>

![Alt text](/assets/imagen5.png?raw=true "Imagen 5")
<p style="text-align: center;">
- Imagen 5.  Clase Caja con las líneas 13 y 19 comentadas. -
</p>
<br>

![Alt text](/assets/imagen6.png?raw=true "Imagen 6")
<p style="text-align: center;">
- Imagen 6.  Método principal en el que se tiene que escribir el código. -
</p>
<br>

*Escribir en el espacio libre el código solicitado.*

<br>
<br>

## Ejercicio 3.

<br>

```csharp
using System;

namespace prodconsthreads
{
    class Program
    {       
        static void Main()
        {
            Caja caja = new Caja(0); 
            Entradas entradas = new Entradas(caja);
            Salidas salidas = new Salidas(caja);
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

// > dotnet run
// INI
// + 200 --> 200
// - 50 --> 150
// + 100 --> 250
// - 150 --> 100
// + 50 --> 150
// - 200 !!! 150
// + 200 --> 350
// - 200 --> 150
// - 300 !!! 150
// + 300 --> 450
// - 300 --> 150
// + 150 --> 300
// - 150 --> 150
// + 50 --> 200
// - 50 --> 150
// + 100 --> 250
// - 100 --> 150
// + 150 --> 300
// + 200 --> 500
// - 200 --> 300
// AVISO
// - 100 --> 200
// - 200 --> 0
// CIERRE
// FIN

```

<p style="text-align: center;">
- Código 1.  Método principal y resultado de una ejecución. -
</p>
<br>

```csharp
using System;
using System.Threading;

namespace prodconsthreads
{
    public class Entradas{
        
        int[] incrementos = {200,100,50,200,300,150,50,100,150,200};//1500

        private Caja caja;
        private Thread thread;

        public Entradas(Caja caja)
        {
            this.caja = caja;
        }
        public void Start()
        {
       this.thread = new Thread(() => this.Agenda());
       this.thread.Start();
        }

        public void Finish()
        {
            thread.Join();
        }

        private void Agenda()
        {
            int t;
            Random rnd = new Random();
            for(int i=0;i<10;i++){
                t = rnd.Next(3,5);
                Thread.Sleep(t);
                caja.Incrementar(incrementos[i]);
            }
        }
    }
```

```csharp
using System;
using System.Threading;

namespace prodconsthreads
{
    public class Salidas{
        
        int[] decrementos = {50,150,200,300,150,50,100,200,100,200};//1500

        private Caja caja;
        private Thread thread;

        public Salidas(Caja caja)
        {
            this.caja = caja;
        }
        public void Start()
        {
       this.thread = new Thread(() => this.Agenda());
       this.thread.Start();
        }

        public void Finish()
        {
            thread.Join();
        }

        private void Agenda()
        {
            int t;
            Random rnd = new Random();
            for(int i=0;i<10;i++){
                t = rnd.Next(3,5);
                Thread.Sleep(t);
                caja.Decrementar(decrementos[i]);
            }
        }
    }
}

```

<p style="text-align: center;">
- Código 2 y 3.  Clases Entradas y Salidas respectivamente. -
</p>
<br>



```csharp
using System;
using System.Threading;

namespace prodconsthreads
{
    public class Caja{

        private readonly object token = new object();
        public int Valor {get;set;}
        private bool estaCerrada = false;

        public Caja(int valor){
            this.Valor = valor;
        }

        public void Avisar()
        {
            lock (token)
            {
                Console.WriteLine("AVISO");
                Monitor.PulseAll(token);
            }
        }
        
        public void Cerrar()
        {
            lock (token)
            {
                this.estaCerrada = true;
                Console.WriteLine("CIERRE");
                Monitor.PulseAll(token);
            }
        }

        public void Incrementar(int valor){
            lock (token)
            {
                if (!estaCerrada){
                    this.Valor += valor;
                    Console.WriteLine("+ {0} --> {1}", valor, Valor);
                    Monitor.Pulse(token);
                }
            }
        }

        public void Decrementar(int valor){
            lock (token)
            {













                        Console.WriteLine("- {0} !!! {1}", valor, Valor);













                        Console.WriteLine("- {0} --> {1}", valor, Valor);












            }
        }
        
    }

}
```

<p style="text-align: center;">
- Código 4.  Clase Caja cuyo método Decrementar hay que escribir. -
</p>
<br>

<br>
<br>

## Ejercicio 4.

<br>


```csharp
using System;
using System.Threading;

namespace prodconsthreads
{
    class Program
    {
        static void Main()
        {
            Caja caja = new Caja(0);











            Console.WriteLine("INI");
























            Console.WriteLine("FIN");
        }
    }
}
```

<p style="text-align: center;">
- Código 5.  Método Main a escribir. -
</p>
<br>
