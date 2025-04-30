using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Creamos instancias de Caja de Ahorro y Cuenta Corriente
            var cajaAhorro1 = new CajaDeAhorro("CA123", 1000, new string[] { "Juan Perez" });
            cajaAhorro1.TasaDeInteres = 0.37m;

            var cajaAhorro2 = new CajaDeAhorro("CA124", 2000, new string[] { "Maria Lopez" });
            cajaAhorro2.TasaDeInteres = 0.25m;

            var cuentaCorriente1 = new CuentaCorriente("CC123", 0, new string[] { "Carlos Garcia" });
            cuentaCorriente1.LimiteDeDescubierto = 200;
            cuentaCorriente1.Comision = 0.05m;

            var cuentaCorriente2 = new CuentaCorriente("CC124", 0, new string[] { "Ana Torres" });
            cuentaCorriente2.LimiteDeDescubierto = 300;
            cuentaCorriente2.Comision = 0.03m;

            Console.WriteLine(" \n \t ¡Bienvenido! \n\n Estamos realizando las operaciones...");

            // Operaciones con Caja de Ahorro 1
            cajaAhorro1.Depositar(0);
            cajaAhorro1.Retirar(250);
            cajaAhorro1.AplicarInteres();

            //Operaciones con Caja de Ahorro 2
            cajaAhorro2.Depositar(100);
            cajaAhorro2.Retirar(500);
            cajaAhorro2.AplicarInteres();

            //Operaciones con Cuenta Corriente 1
            cuentaCorriente1.Depositar(1000);
            cuentaCorriente1.Retirar(1100);

            //Operaciones con Cuenta Corriente 2
            cuentaCorriente2.Depositar(2000);
            cuentaCorriente2.Retirar(2500);

            //Usamos clases anonimas para mostrar el resumen de cada cuenta
            var resumenCuentas = new[] {
                new { CuentaNum = cajaAhorro1.Numero, Saldo = cajaAhorro1.Saldo, Titular = string.Join(", ", cajaAhorro1.Titulares), Estado = cajaAhorro1.Estado },
                new { CuentaNum = cajaAhorro2.Numero, Saldo = cajaAhorro2.Saldo, Titular = string.Join(", ", cajaAhorro2.Titulares), Estado = cajaAhorro2.Estado },
                new { CuentaNum = cuentaCorriente1.Numero, Saldo = cuentaCorriente1.Saldo, Titular = string.Join(", ", cuentaCorriente1.Titulares), Estado = cuentaCorriente1.Estado },
                new { CuentaNum = cuentaCorriente2.Numero, Saldo = cuentaCorriente2.Saldo, Titular = string.Join(", ", cuentaCorriente2.Titulares), Estado = cuentaCorriente2.Estado }
            };

            Console.WriteLine("\n RESUMEN DE CUENTAS \n");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("| Número | Tipo             | Saldo    | Titulares            |       Estado       |");
            Console.WriteLine("----------------------------------------------------------------------");
            foreach (var cuenta in resumenCuentas)
            {
                string tipo = cuenta.CuentaNum.StartsWith("CA") ? "Caja de Ahorro" : "Cuenta Corriente";
                Console.WriteLine($"| {cuenta.CuentaNum} | {tipo,-15} | {cuenta.Saldo,8} | {cuenta.Titular,-20} | {cuenta.Estado,-15}");
            }
            Console.WriteLine("----------------------------------------------------------------------");
        }
    }
}