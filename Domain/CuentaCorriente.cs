using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class CuentaCorriente : CuentaBancaria
    {
        public decimal Comision { get; init; }
        public decimal LimiteDeDescubierto { get; init;}

        public CuentaCorriente(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares) {}

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
                Console.WriteLine($"\n [!] Error - Cuenta: {Numero}");
                Console.WriteLine(e.Message);
            }
            catch (CuentaNoActivaException e)
            {
                Console.WriteLine($"\n [!] Error - Cuenta: {Numero}");
                Console.WriteLine(e.Message);
            }
        }

        public override void Retirar(decimal monto)
        {
            try
            {
                MontoValido(monto);
                CuentaActiva();
                if (Saldo - monto >= - LimiteDeDescubierto)
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
            catch (MontoNoValidoException e)
            {
                Console.WriteLine($"\n [!] Error - Cuenta: {Numero}");
                Console.WriteLine(e.Message);
            }
            catch (CuentaNoActivaException e)
            {
                Console.WriteLine($"\n [!] Error - Cuenta: {Numero}");
                Console.WriteLine(e.Message);
            }
            catch (SaldoInsuficienteException e)
            {
                Console.WriteLine($"\n [!] Error - Cuenta: {Numero}");
                Console.WriteLine(e.Message);
            }
        }
    }
}