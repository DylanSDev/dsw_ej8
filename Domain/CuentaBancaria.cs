using Dsw2025Ej8.Exceptions;

namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public string Numero { get; }
    public decimal Saldo { get; protected set; }
    public EstadoCuenta Estado { get; protected set; }
    public string[] Titulares { get; }

    public CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        Estado = EstadoCuenta.Activa;
        Titulares = titulares;
    }

    public void MontoValido(decimal monto)
    {
        if (monto <= 0) { throw new MontoNoValidoException(); }
    }

    public void CuentaActiva()
    {
        if (Estado != EstadoCuenta.Activa) { throw new CuentaNoActivaException(Estado); }
    }

    public virtual void Depositar(decimal monto)
    {
        MontoValido(monto);
        CuentaActiva();
        Saldo += monto;
    }

    public virtual void Retirar(decimal monto)
    {
        MontoValido(monto);
        CuentaActiva();
        if (monto > Saldo)
        {
            Estado = EstadoCuenta.Suspendida;
            throw new SaldoInsuficienteException();
        }
        else
            Saldo -= monto;
    }
}