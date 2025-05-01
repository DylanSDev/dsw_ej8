namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public string Numero { get; }
    public decimal Saldo { get; protected set; }
    public EstadoCuenta Estado {get;  protected set;}
    public string[] Titulares {get; }

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
        try
        {
            MontoValido(monto);
            CuentaActiva();
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

    public virtual void Retirar(decimal monto)
    {
        try
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