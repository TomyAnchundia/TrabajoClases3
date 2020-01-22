using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQTrabajoGrupal
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creamos una lista de numeros aletorios
            List<NumerosAleatorios> numerosAleatorios = new List<NumerosAleatorios>();


            for (int i = 0; i < 50; i++)
            {
                Random numeros = new Random();
                int aleatorio = numeros.Next(1, 100);
                numerosAleatorios.Add(new NumerosAleatorios { Valor = aleatorio });

            }

            //busqueda de los numeros primos
            Console.WriteLine("Lista de numeros aleatorios");
            foreach (var item in numerosAleatorios)
            {
                Console.WriteLine(item.Valor);
            }
            Console.WriteLine("numeros primos");



            IEnumerable<NumerosAleatorios> consulta = from NumerosAleatorios in numerosAleatorios
                                                      where NumerosAleatorios.NumerosPrimo(NumerosAleatorios.Valor) == true

                                                      select NumerosAleatorios;
            foreach (var item in consulta)
            {
                Console.WriteLine("{0} ", item.Valor);

            }

            Console.WriteLine("Sumatoria");


             
            Console.WriteLine(numerosAleatorios.Sum(r => r.Valor));


            //new list al cuadrado
            Console.WriteLine("Segunda lista al cuadrado");
            List<NumerosAleatorios> listaAlCuadrado = new List<NumerosAleatorios>();

            foreach (NumerosAleatorios item in numerosAleatorios)
            {
                double cua = item.NumerosAlCuadrado(item.Valor);

                listaAlCuadrado.Add(new NumerosAleatorios { Valor = Convert.ToInt32(cua) });
            }


            foreach (NumerosAleatorios item2 in listaAlCuadrado)
            {
                Console.WriteLine(item2.Valor);
            }


            Console.WriteLine("Numeros que no son primos");

            IEnumerable<NumerosAleatorios> consulta2 = from NumerosAleatorios in numerosAleatorios
                                                      where NumerosAleatorios.NumerosPrimo(NumerosAleatorios.Valor) == false

                                                      select NumerosAleatorios;
            foreach (var item in consulta2)
            {
                Console.WriteLine("{0} ", item.Valor);

            }

            //obtener Promedio de numeros >50

            Console.WriteLine("Promedio de los numeros mayores a 50");
            IEnumerable<NumerosAleatorios> promedio = from NumerosAleatorios in numerosAleatorios
                                                      where NumerosAleatorios.Valor > 50
                                                      select NumerosAleatorios;


            double pro = numerosAleatorios.Sum(p => p.Valor);
            
            Console.WriteLine(pro = pro / 50);

            // pares e impares
            Console.WriteLine("Pares e impares");
             
            IEnumerable<NumerosAleatorios> paresEImpares = from NumerosAleatorios in numerosAleatorios
                                                      where NumerosAleatorios.Valor%2==0
                                                      select NumerosAleatorios;
            int pares = paresEImpares.Count();
            Console.WriteLine("pares= "+pares+ "  Impares= "+(50-pares) );


            // cantidad de veces repetidos
            Console.WriteLine("se repite");
            foreach (var item3 in numerosAleatorios.GroupBy(x => x))


                Console.WriteLine($"{item3.Key.Valor} encontrado {item3.Count()} veces");





        }

    }
}
