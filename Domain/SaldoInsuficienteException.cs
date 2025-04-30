using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException() : base($" La cuenta no posee saldo suficiente para la operación solicitada.")
        {
        }
    }
}