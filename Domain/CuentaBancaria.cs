using static Dsw2025Ej8.Exceptions.ExceptionOperations;

namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    private string _numero;
    private decimal _saldo;
    private EstadoCuenta _estado;
    private string[] _titulares;

    public CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        _numero = numero;
        _saldo = saldo;
        _estado = EstadoCuenta.Activa;
        _titulares = titulares;
    }

    #region Propiedades

    public string Numero
    {
        get { return _numero; }
    }

    public decimal Saldo
    {
        get { return _saldo; }
        protected set { _saldo = value; }
    }

    public EstadoCuenta Estado
    {
        get { return _estado; }
        set { _estado = value; }
    }

    public string[] Titulares
    {
        get { return _titulares; }
    }

    #endregion Propiedades

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
            _saldo += monto;
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