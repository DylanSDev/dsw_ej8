using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class CuentaCorriente : CuentaBancaria
    {
        public CuentaCorriente(string numero, decimal saldo, TipoCuenta tipo, string[] titulares) : base(numero, saldo, tipo, titulares)
        {

        }
    }
}
