using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8.Exceptions
{
    internal class MontoNoValidoException : Exception
    {
        public MontoNoValidoException() : base(" El monto ingresado no es válido para la operación solicitada.")
        {
        }
    }

    internal class CuentaNoActivaException : Exception
    {
        public CuentaNoActivaException(EstadoCuenta estado) : base($" No se puede operar con la cuenta {estado}")
        {
        }
    }

    internal class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException() : base($" La cuenta no posee saldo suficiente para la operación solicitada.")
        {
        }
    }
}