using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    interface ICliente
    {

        string Identidad { get; }
        void Leer();
    }
}
