using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Empresa : ICliente
    {

        public string RazonSocial { get; set; }
        public string RUC { get; set; }

        public void Leer()
        {
            Console.Write("Razon ssocial : ");
            this.RazonSocial = Console.ReadLine();
            Console.Write("RUC : ");
            this.RUC = Console.ReadLine();
        }


        public string Identidad
        {
            get
            {
                return this.RUC + "-" + this.RazonSocial;
            }
        }

    }
}
