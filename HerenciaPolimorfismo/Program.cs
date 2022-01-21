using Entidades;
using Basicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaPolimorfismo
{
    class Program
    {
        private static List<ICliente> DatosClientes = new List<ICliente>();
        private static List<Producto> DatosProductos = new List<Producto>();
        private static List<Venta> DatosVentas = new List<Venta>();

        private static string[] Opciones = { "Gestionar Cliente", "Gestionar Producto", "Gestionar Venta", "Reportes", "Salir" };
        private static string[] OpcionesCliente = { "Registrar Cliente", "Modificar Cliente", "Listar Cliente", "Eliminar Cliente", "Retornar" };
        private static string[] TipoCliente = { "Persona", "Empresa", "Trabajador"};
        private static string[] OpcionesProducto = { "Registrar Producto", "Modificar Producto", "Listar Producto", "Eliminar Producto", "Retornar" };
        private static string[] OpcionesVenta = { "Registrar Venta", "Modificar Venta", "Listar Venta", "Dar de baja una Venta", "Retornar" };
        private static string[] OpcionesReporte = { "Listado detallado de las ventas realizadas a empresas", "Listado de ventas por un producto solicitado", "Listado resumen de ventas por producto", "Retornar" };
    
        static void Main(string[] args)
        {
            int opcion;

            do{
                opcion = Funciones.LeerMenu("- MENU PRINCIPAL -", Opciones, "Ingrese opcion: ", "* Opcion incorrecta");

                switch (opcion) {
                    case 1: GestionarCliente();
                        break;
                    case 2: GestionarProducto();
                        break;
                    case 3: GestionarVenta();
                        break;
                    case 4: ListadoReportes();
                        break;
                }
            }while(opcion != Opciones.Length);
        }

        private static void ListadoReportes()
        {
            int opcion;

            do
            {
                opcion = Funciones.LeerMenu("REPORTES", OpcionesReporte, "Ingrese opcion: ", "* Opcion incorrecta");

                switch (opcion)
                {
                    case 1: ListadoDetalladoVentasEmpresa();
                        break;
                    case 2: ListadoVentasSegunUnProducto();
                        break;
                    case 3: ListadoResumenVentasPorProducto();
                        break;
                }
            } while (opcion != OpcionesReporte.Length);
        }

        private static void ListadoResumenVentasPorProducto()
        {
            int i = 1;
            Console.WriteLine("\nLISTADO DETALLADO DE VENTAS POR PRODUCTO");
            foreach (var producto in DatosProductos)
            {
                int cantidadTotal = 0;
                double montoTotal = 0;

                foreach (var venta in DatosVentas)
                {
                    if (venta.Producto.Nombre.Equals(producto.Nombre))
                    {
                        cantidadTotal += venta.Cantidad;
                        montoTotal += venta.Monto();
                    }
                }
                Console.WriteLine(i + ".- " + producto.Nombre + " - " + cantidadTotal + " - S/." + montoTotal);
                i++;
            }
            Console.WriteLine(".................................................");

            i = 1;
            IEnumerable<IGrouping<string, Venta>> resultado;

            resultado = DatosVentas.GroupBy(venta => venta.Producto.Nombre);
            Console.WriteLine("Tipo dato : " + resultado.GetType());
            Console.WriteLine("\nLISTADO DETALLADO DE VENTAS POR PRODUCTO");
            foreach (var ventas in resultado)
            {
                Console.WriteLine(i + ".- " + ventas.Key + " - " + ventas.Sum(venta => venta.Cantidad) + " - S/." + ventas.Sum(venta => venta.Monto()));
                i++;
            }
            Console.WriteLine(".................................................");
        }

        private static void ListadoVentasSegunUnProducto()
        {
            int i = 1;
            string nombre;

            Console.Write("Nombre de producto : ");
            nombre = Console.ReadLine();
            Console.WriteLine("\nLISTADO DE VENTAS DE " + nombre.ToUpper());
            foreach (var venta in DatosVentas)
            {
                if (venta.Producto.Nombre.Equals(nombre))
                {
                    Console.WriteLine(i + ".- " + venta.Cliente.Identidad + " - " + venta.Serie + " - " + venta.Numero);
                    i++;
                }
            }
            Console.WriteLine(".................................................");

            i = 1;
            IEnumerable<Venta> resultado;

            Console.Write("Nombre de producto : ");
            nombre = Console.ReadLine();
            resultado = DatosVentas.Where(venta => venta.Producto.Nombre.Equals(nombre));


            Console.WriteLine("\nLISTADO DE VENTAS DE " + nombre.ToUpper());
            foreach (var venta in resultado)
            {
                Console.WriteLine(i + ".- " + venta.Cliente.Identidad + " - " + venta.Serie + " - " + venta.Numero);
                i++;
            }
            Console.WriteLine(".................................................");
        }

        private static void ListadoDetalladoVentasEmpresa()
        {
            int i = 1;
            Console.WriteLine("\nLISTADO DETALLADO DE VENTAS REALIZADAS A EMPRESAS");
            foreach (var venta in DatosVentas)
            {
                if(venta.Cliente is Empresa){
                    Console.WriteLine(i + ".- " + ((Empresa)venta.Cliente).RazonSocial + " - " + venta.Fecha + " - S/." + venta.Monto());
                    i++;
                }
            }
            Console.WriteLine(".................................................");

            i = 1;
            IEnumerable<Venta> resultado;

            resultado = DatosVentas.Where(venta => venta.Cliente is Empresa);
            Console.WriteLine("\nLISTADO DETALLADO DE VENTAS REALIZADAS A EMPRESAS");
            foreach (var venta in resultado)
            {
                Console.WriteLine(i + ".- " + ((Empresa)venta.Cliente).RazonSocial + " - " + venta.Fecha + " - S/." + venta.Monto());
                i++;
            }
            Console.WriteLine(".................................................");
        }

        private static void GestionarVenta()
        {
            int opcion;

            do
            {
                opcion = Funciones.LeerMenu("GESTIONAR VENTA", OpcionesVenta, "Ingrese opcion: ", "* Opcion incorrecta");

                switch (opcion)
                {
                    case 1: RegistrarVenta();
                        break;
                    case 2: ModificarVenta();
                        break;
                    case 3: ListarVenta();
                        break;
                    case 4: DarBajaVenta();
                        break;
                }
            } while (opcion != OpcionesVenta.Length);
        }

        private static void DarBajaVenta()
        {
            throw new NotImplementedException();
        }

        private static void ListarVenta()
        {
            int i = 1;
            Console.WriteLine("\nLISTADO DE VENTAS");
            foreach (var venta in DatosVentas)
            {
                Console.WriteLine(i + ".- " + venta.Numero);
                i++;
            }
            Console.WriteLine("..............................");
        }

        private static void ModificarVenta()
        {
            throw new NotImplementedException();
        }

        private static void RegistrarVenta()
        {
            Venta venta;
            ICliente cliente;
            Producto producto;
            //ICliente trabajador;

            cliente = BuscarCliente();
            producto = BuscarProducto();
            //trabajador = BuscarTrabajador();

            if (cliente != null && producto != null)// && trabajador != null)
            {
                venta = new Venta();
                venta.Leer();
                venta.Cliente = cliente;
                venta.Producto = producto;
                //venta.Trabajador = trabajador;
                DatosVentas.Add(venta);
            }
            else
            {
                if (cliente == null)
                {
                    Console.WriteLine("* Cliente no encontrado");
                }
                else if (producto == null)
                {
                    Console.WriteLine("* Producto no encontrado");
                }
                else {
                    Console.WriteLine("* Trabajador no encontrado");
                }
            }
            
        }

        private static ICliente BuscarTrabajador()
        {
            string documento;
            
            Console.Write("DNI trabajador : ");
            documento = Console.ReadLine();

            foreach (var cliente in DatosClientes)
            {
                if (cliente is Trabajador && ((Trabajador)cliente).DNI.Equals(documento))
                {
                    return cliente;
                }
            }

            return null;
        }

        private static Producto BuscarProducto()
        {
            string nombre;
            
            Console.Write("Nombre del producto : ");
            nombre = Console.ReadLine();

            foreach (var producto in DatosProductos) { 
                if (producto.Nombre.Equals(nombre)){
                    return producto;
                }
            }

            return null;
        }

        private static ICliente BuscarCliente()
        {
            int opcion;
            string[] TipoDocumento = {"DNI", "RUC", "DNI"};
            string documento;

            opcion = Funciones.LeerMenu("TIPO DE CLIENTE", TipoCliente, "Opcion : ", "* Opcion no valida");
            Console.Write(TipoDocumento[opcion-1] + " : ");
            documento = Console.ReadLine();

            foreach(var cliente in DatosClientes){
                if (opcion == 2 && cliente is Empresa && ((Empresa)cliente).RUC.Equals(documento))
                {
                    return cliente;
                }
                else {
                    if (opcion != 2 && cliente is Persona && ((Persona)cliente).DNI.Equals(documento))
                    {
                        return cliente;
                    }
                }
            }

            return null;
        }

        private static void GestionarProducto()
        {
            int opcion;

            do
            {
                opcion = Funciones.LeerMenu("GESTIONAR PRODUCTO", OpcionesProducto, "Ingrese opcion: ", "* Opcion incorrecta");

                switch (opcion)
                {
                    case 1: RegistrarProducto();
                        break;
                    case 2: ModificarProducto();
                        break;
                    case 3: ListarProducto();
                        break;
                    case 4: EliminarProducto();
                        break;
                }
            } while (opcion != OpcionesProducto.Length);
        }

        private static void EliminarProducto()
        {
            throw new NotImplementedException();
        }

        private static void ListarProducto()
        {
            int i = 1;
            Console.WriteLine("\nLISTADO DE PRODUCTOS");
            foreach (var producto in DatosProductos)
            {
                Console.WriteLine(i + ".- " + producto.Nombre + " (S/." + producto.Precio + ")");
                i++;
            }
            Console.WriteLine("..............................");
        }

        private static void ModificarProducto()
        {
            throw new NotImplementedException();
        }

        private static void RegistrarProducto()
        {
            Producto producto;

            producto = new Producto();
            producto.Leer();
            DatosProductos.Add(producto);
        }

        private static void GestionarCliente()
        {
            int opcion;

            do
            {
                opcion = Funciones.LeerMenu("GESTIONAR CLIENTE", OpcionesCliente, "Ingrese opcion: ", "* Opcion incorrecta");

                switch (opcion)
                {
                    case 1: RegistrarCliente();
                        break;
                    case 2: ModificarCliente();
                        break;
                    case 3: ListarCliente();
                        break;
                    case 4: EliminarCliente();
                        break;
                }
            } while (opcion != OpcionesCliente.Length);
        }

        private static void EliminarCliente()
        {
            throw new NotImplementedException();
        }

        private static void ListarCliente()
        {
            int i = 1;
            Console.WriteLine("\nLISTADO DE CLIENTES");
            foreach(var cliente in DatosClientes){
                Console.WriteLine(i + ".- " + cliente.Identidad);
                i++;
            }
            Console.WriteLine("..............................");
        }

        private static void ModificarCliente()
        {
            throw new NotImplementedException();
        }

        private static void RegistrarCliente()
        {
            ICliente cliente;
            int opcion;

            opcion = Funciones.LeerMenu("TIPO CLIENTE", TipoCliente, "Ingrese opcion: ", "* Opcion incorrecta");
            cliente = CrearCliente(opcion);
            cliente.Leer();
            DatosClientes.Add(cliente);
        }

        private static ICliente CrearCliente(int opcion)
        {
            ICliente cliente = null;

            switch (opcion)
            {
                case 1: cliente = new Persona();
                    break;
                case 2: cliente = new Empresa();
                    break;
                case 3: cliente = new Trabajador();
                    break;
            }

            return cliente;
        }
    }
}