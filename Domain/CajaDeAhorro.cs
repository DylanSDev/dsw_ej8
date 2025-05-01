using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class CajaDeAhorro : CuentaBancaria
    {
        public decimal TasaDeInteres { get; init; }
        public CajaDeAhorro(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares) {}
   
        public void AplicarInteres()
        {
            Saldo += Saldo * TasaDeInteres;
        }
    }
}
