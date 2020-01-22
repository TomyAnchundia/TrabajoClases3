using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factura.Clases
{
    public class Factur
    {

        
        
            private String observacion;

            public String Observacion
            {
                get { return observacion; }
                set { observacion = value; }
            }

            private int idCliente;

            public int IdCliente
            {
                get { return idCliente; }
                set { idCliente = value; }
            }


            private String fecha;

            public String Fecha
            {
                get { return fecha; }
                set { fecha = value; }
            }
            private int año;

            public int Año
            {
                get { return año; }
                set { año = value; }
            }


            private float total;

            public float Total
            {
                get { return total; }
                set { total = value; }
            }

           
        
    }
}
