using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factura.Clases;

namespace Factura
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cliente> clientes = new List<Cliente>()
            {
                new Cliente(){Id = 1, Nombre="Ana"},
                new Cliente(){Id = 2, Nombre = "polar"},
                new Cliente(){Id = 3, Nombre = "tomy"},
                new Cliente(){Id = 4, Nombre = "Dios"},
                new Cliente(){Id = 5, Nombre = "gaby"},
                new Cliente(){Id = 6, Nombre = "Gay"},
                new Cliente(){Id = 7, Nombre = "andy"},
                new Cliente(){Id = 8, Nombre = "sonia"},
                new Cliente(){Id = 9, Nombre = "Jesus"},
                new Cliente(){Id = 10, Nombre = "Karen"},
            };

            List<Factur> facturas = new List<Factur>()
            {
                new Factur(){Observacion = "Platos",IdCliente = 1, Fecha = "19/08/2020",Año =2020, Total = 25.550f},
                new Factur(){Observacion = "gas",IdCliente = 1, Fecha = "21/10/2019",Año =2019, Total = 20.550f},
                new Factur(){Observacion = "perro",IdCliente = 3, Fecha = "18/02/2020",Año =2020, Total = 30.550f},
                new Factur(){Observacion = "Plato",IdCliente = 4, Fecha = "19/10/2019",Año =2019, Total = 28.550f},
                new Factur(){Observacion = "Plato",IdCliente = 5, Fecha = "24/12/2019",Año =2019, Total = 50.550f},
                new Factur(){Observacion = "Nluz",IdCliente = 1, Fecha = "15/08/2020",Año =2020, Total = 60.550f},
                new Factur(){Observacion = "Plato",IdCliente = 7, Fecha = "12/07/2020",Año =2020, Total = 70.550f},
                new Factur(){Observacion = "hola",IdCliente = 9, Fecha = "15/07/2020",Año =2020, Total = 60.550f},
                new Factur(){Observacion = "manzana",IdCliente = 9, Fecha = "31/12/2019",Año =2019, Total = 80.550f},
                new Factur(){Observacion = "Plato",IdCliente = 10, Fecha = "24/12/2020",Año =2020, Total = 100.550f},
            };

            //los 3 primeros mayores
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("\n*****LOS 3 CLIENTES CON MAS VENTAS**********\n");
            Console.WriteLine("-----------------------------------------");
            var consulta1 = from cliente in clientes
                            join fac in facturas.Where(x => x.Total > 70.000f)
                            on cliente.Id equals fac.IdCliente
                            select new { clienteNombre = cliente.Nombre, facturaTotal = fac.Total };

            consulta1.ToList().ForEach(x =>
                    {
                        Console.WriteLine("NOMBRE:{0} VENTA: {1}", x.clienteNombre, x.facturaTotal);
                    });
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------");

            //Los 3 primeros clientes con menos 
            Console.WriteLine("\n*****LOS 3 CLIENTES CON MENOS VENTAS **************\n");
            Console.WriteLine("-----------------------------------------");
            var consulta2 = from cliente in clientes
                            join fac in facturas.Where(x => x.Total <= 28.550f)
                            on cliente.Id equals fac.IdCliente
                            select new { clienteNombre = cliente.Nombre, facturaToTal = fac.Total };

            consulta2.ToList().ForEach(x =>
                {
                    Console.WriteLine("NOMBRE:{0} TOTAL: {1}", x.clienteNombre, x.facturaToTal);
                }); Console.WriteLine("");
            Console.WriteLine("-----------------------------------------");

            //Clientes con mas ventas realizadas
            Console.WriteLine("\n*****CLIENTE CON MAS VENTAS******\n");
            Console.WriteLine("-----------------------------------------");
            var consulta3 = from cliente in clientes
                            where cliente.Nombre.ToUpper() == "A".ToUpper()
                            join fac in facturas on cliente.Id equals fac.IdCliente
                            group cliente by fac.Total into resumen
                            select new
                            {
                                ventas = resumen.Key,
                                NombreDelCliente = (from res in resumen
                                                    select res.Nombre.ToString()).Min(),

                            };
            consulta3.ToList().ForEach(x =>
                {
                    Console.WriteLine("NOMBRE={0} VENTAS= {1}", x.NombreDelCliente, x.ventas);
                });
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------");

            //Cada cliente y su cantidad de ventas realizadas

            Console.WriteLine("\nL**********LISTA DE CLIENTES***********\n");
            Console.WriteLine("-----------------------------------------");
            var consulta4 = from cliente in clientes
                            join fac in facturas on cliente.Id equals fac.IdCliente
                            select new
                            {
                                nombreCliente = cliente.Nombre,
                                cantidadVentas = fac.Total,
                                detalle = fac.Observacion
                            };


            consulta4.ToList().ForEach(x =>
                {
                    Console.WriteLine("NOMNRE={0} VENTA= {1} en {2}", x.nombreCliente, x.cantidadVentas, x.detalle);
                });
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------");
            //Ventas realizadas en el año 2019

            Console.WriteLine("*********Ventas realizadas en el 2019*********\n");
            Console.WriteLine("-----------------------------------------");

            var consulta5 = from cliente in clientes
                            join fac in facturas on cliente.Id equals fac.IdCliente
                            where fac.Año == 2019
                            select new
                            {
                                fecha = fac.Fecha,
                                nombreCliente = cliente.Nombre,
                                cantidadVentas = fac.Total,
                                detalle = fac.Observacion
                            };

            consulta5.ToList().ForEach(x =>
                {

                    Console.WriteLine("NOMBRE={0}VENTA = {1} en {2} Fecha={3}", x.nombreCliente, x.cantidadVentas, x.detalle, DateTime.Now.ToString(x.fecha));
                    Console.WriteLine();
                });
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------");

            //La venta mas antigua
            Console.WriteLine("***VENTA ANTIGUA*****");
            Console.WriteLine("-----------------------------------------");

            var consulta6 = from cliente in clientes
                            join fac in facturas on cliente.Id equals fac.IdCliente
                            where fac.Fecha == "19/10/2019"
                            select new
                            {
                                fecha = fac.Fecha,
                                nombreCliente = cliente.Nombre,
                                cantidadVentas = fac.Total,
                                detalle = fac.Observacion
                            };
            consulta6.ToList().ForEach(x =>
                {

                    Console.WriteLine("NOMBE={0} VENTAN = {1}$ en {2} Fecha={3}", x.nombreCliente, x.cantidadVentas, x.detalle, DateTime.Now.ToString(x.fecha));
                    Console.WriteLine();
                });
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------");

            //Los clientes que tengan una venta cuya observación comience con "Plato"

            Console.WriteLine("***CLIENTES QUE LLEVAN PLATOS**********");
            Console.WriteLine("-----------------------------------------");

            var consulta7 = from cliente in clientes
                            join fac in facturas on cliente.Id equals fac.IdCliente
                            where fac.Observacion.ToUpper() == "plato".ToUpper() || fac.Observacion.ToUpper() == "platos".ToUpper()
                            select new
                            {
                                fecha = fac.Fecha,
                                nombreCliente = cliente.Nombre,
                                cantidadVentas = fac.Total,
                                detalle = fac.Observacion
                            };
            consulta7.ToList().ForEach(x =>
                {

                    Console.WriteLine("NOMBRE={0} VENTA= {1}$ en {2} Fecha={3}", x.nombreCliente, x.cantidadVentas, x.detalle, DateTime.Now.ToString(x.fecha));
                });
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------");











        }  
    }
}
