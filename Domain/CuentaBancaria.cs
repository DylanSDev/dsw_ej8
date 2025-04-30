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
    #endregion

    public void MontoValido (decimal monto) 
    {
        if (monto <= 0) { throw new MontoNoValidoException(); }
    }

    public void CuentaActiva ()
    {
        if (Estado != EstadoCuenta.Activa) {  throw new CuentaNoActivaException(Estado); }
    }

    public virtual void Depositar(decimal monto)
    {
        try
        {
            MontoValido(monto);
            CuentaActiva();
            _saldo += monto;
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

    public virtual void Retirar(decimal monto)
    {
        try
        {
            MontoValido(monto);
            CuentaActiva();
            _saldo -= monto;
        }
        catch (MontoNoValidoException e)
        {
            Console.WriteLine(e.Message);
        }
        catch  (CuentaNoActivaException e)
        {
            Console.WriteLine(e.Message);
        }
    }
        
}
