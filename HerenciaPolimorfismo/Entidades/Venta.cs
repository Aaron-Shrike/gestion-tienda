using Basicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Venta
    {

        public string TipoDocumento { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public bool Vigente { get; set; }

        public ICliente Cliente { get; set; }
        //public ICliente Trabajador { get; set; }

        public Producto Producto { get; set; }
        public int Cantidad { get; set; }

        public void Leer()
        {
            Console.Write("Tipo de Documento : ");
            this.TipoDocumento = Console.ReadLine();
            Console.Write("Serie : ");
            this.Serie = Console.ReadLine();
            Console.Write("Numero : ");
            this.Numero = Console.ReadLine();
            Console.Write("Fecha : ");
            this.Fecha = DateTime.Parse(Console.ReadLine());
            this.Vigente = true;
            this.Cantidad = Funciones.LeerEntero("Ingrese cantidad[1-100] : ", 1, 1000, " *Cantidad incorrecta");
        }

        public double Monto() {
            return (Producto.Precio * Cantidad);
        }
    }
}

/*
 * Clases concretas
 * Clases abstractas
 * Clases selladas
 * Clases estáticas
 * Clases anónimas
 * Interfaces
 */
