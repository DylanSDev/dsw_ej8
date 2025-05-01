using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Exceptions;

namespace Dsw2025Ej8.Domain
{
    internal class CuentaCorriente : CuentaBancaria
    {
        public decimal Comision { get; init; }
        public decimal LimiteDeDescubierto { get; init; }

        public CuentaCorriente(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
        {
        }

        public override void Depositar(decimal monto)
        {
            MontoValido(monto);
            CuentaActiva();
            monto -= monto * Comision;
            Saldo += monto;
        }

        public override void Retirar(decimal monto)
        {
            MontoValido(monto);
            CuentaActiva();
            if (Saldo - monto >= -LimiteDeDescubierto)
            {
                Saldo -= monto;
                if (Saldo < 0)
                    Estado = EstadoCuenta.Suspendida;
            }
            else
            {
                Estado = EstadoCuenta.Suspendida;
                throw new SaldoInsuficienteException();
            }
        }
    }
}