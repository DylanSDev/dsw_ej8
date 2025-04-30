namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    private string _numero;
    private decimal _saldo;
    private Estado _estado;
    private string[] _titulares;

    public CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        _numero = numero;
        _saldo = saldo;
        _estado = Estado.Activa;
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

    public Estado Estado
    {
        get { return _estado; }
        set { _estado = value; }
    }

    public string[] Titulares
    {
        get { return _titulares; }
    }
    #endregion

    public virtual void Depositar(decimal monto)
    {
        _saldo += monto;
    }

    public virtual void Retirar(decimal monto)
    {
            _saldo -= monto;
    }
        
}
