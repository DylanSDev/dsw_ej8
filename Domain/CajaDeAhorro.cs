using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class CajaDeAhorro : CuentaBancaria
    {
        private decimal _tasaDeInteres;
        public CajaDeAhorro(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
        {

        }
        public decimal TasaDeInteres
        {
            get { return _tasaDeInteres; }
            set { _tasaDeInteres = value; }
        }

        public void AplicarInteres()
        {
            Saldo += Saldo * TasaDeInteres;
        }
    }
}
