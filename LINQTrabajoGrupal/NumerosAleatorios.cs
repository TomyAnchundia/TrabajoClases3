using System;
using System.Collections.Generic;
using System.Text;

namespace LINQTrabajoGrupal
{
    public class NumerosAleatorios
    {
        private int valor;

        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }
      
      public bool NumerosPrimo(int valor)
        {
            int divisor = 2;
            int resto = 0;
            
            while (divisor < valor)
            {
                resto = valor % divisor;
                if (resto == 0)
                {
                    return false;
                }
                divisor = divisor + 1;
            }
            return true;
            
        }





      
        
        public double NumerosAlCuadrado(int valor)
        {
            Double cuadrado = 0;


            for (int i = 0; i < 50; i++)
            {
                if (i <= 50)
                {
                    cuadrado = Math.Pow(valor, 2);

                }

                return cuadrado;


            }
            return cuadrado;

           
        }
        
                
                
               
    }
            
}
    

