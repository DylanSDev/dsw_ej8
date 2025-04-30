using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class SaldoInsuficienteException : Exception
    {
        public CuentaNoActivaException() : base($"No se puede operar con la cuenta {estado}") { }
    }
}
