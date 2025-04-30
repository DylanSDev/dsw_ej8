using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class CuentaCorriente : CuentaBancaria
    {
        private decimal _comision;
        private decimal _limiteDeDescubierto;
        public CuentaCorriente(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
        {
        }

        public decimal Comision
        {
            get { return _comision; }
            set { _comision = value; }
        }
        public decimal LimiteDeDescubierto
        {
            get { return _limiteDeDescubierto; }
            set { _limiteDeDescubierto = value; }
        }

        public override void Depositar(decimal monto)
        {
            try
            {
                MontoValido(monto);
                CuentaActiva();
                monto -= monto * Comision;
                Saldo += monto;
            }
            catch (MontoNoValidoException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (CuentaNoActivaException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override void Retirar(decimal monto)
        {
            try
            {
                MontoValido(monto);
                CuentaActiva();
                if (Saldo - monto >= -_limiteDeDescubierto)
                {
                    Saldo -= monto;
                }
                if (Saldo < 0)
                {
                    Estado = EstadoCuenta.Suspendida;
                }
            }
            catch (MontoNoValidoException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (CuentaNoActivaException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
