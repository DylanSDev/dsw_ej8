namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{
    private TipoCuenta _tipo;
    private string _numero;
    private decimal _saldo;
    private Estado _estado;
    private decimal _tasaDeInteres;
    private decimal _limiteDeDescubierto;
    private decimal _comision;
    private string[] _titulares;

    public CuentaBancaria(string numero, decimal saldo, TipoCuenta tipo, string[] titulares)
    {
        _numero = numero;
        _saldo = saldo;
        _tipo = tipo;
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
    }

    public Estado Estado
    {
        get { return _estado; }
        set { _estado = value; }
    }

    public decimal TasaDeInteres
    {
        get { return _tasaDeInteres; }
        set { _tasaDeInteres = value;}
    }

    public decimal LimiteDeDescubierto
    {
        get { return _limiteDeDescubierto;}
        set { _tasaDeInteres= value; }
    }

    public decimal Comision
    {
        get { return _comision; }
        set { _comision = value; }
    }

    public string[] Titulares
    {
        get { return _titulares; }
    }
    #endregion

    public void Depositar(decimal monto)
    {
        if (_tipo == TipoCuenta.CajaDeAhorro)
        {
            _saldo += monto;
        }
        else if (_tipo == TipoCuenta.CuentaCorriente)
        {
            monto -= monto * _comision;
            _saldo += monto;
        }
    }

    public void Retirar(decimal monto)
    {
        if (_tipo == TipoCuenta.CajaDeAhorro)
        {
            _saldo -= monto;
        }
        else if (_tipo == TipoCuenta.CuentaCorriente)
        {
            if (_saldo - monto >= -_limiteDeDescubierto)
            {
                _saldo -= monto;
            }
            if (_saldo < 0)
            {
                _estado = Estado.Suspendida;
            }
        }
    }

    public void AplicarInteres()
    {
        if (_tipo == TipoCuenta.CajaDeAhorro)
        {
            _saldo += _saldo * _tasaDeInteres;
        }
    }
}
