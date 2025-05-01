using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Domain;


namespace Dsw2025Ej8.Views
{
    internal class MainView
    {
        public MainView() {}
        public void Iniciar()
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
            cajaAhorro2.Retirar(0);
            cajaAhorro2.AplicarInteres();

            //Operaciones con Cuenta Corriente 1
            cuentaCorriente1.Depositar(1000);
            cuentaCorriente1.Retirar(1100);

            //Operaciones con Cuenta Corriente 2
            cuentaCorriente2.Depositar(2000);
            cuentaCorriente2.Retirar(2500);

            Console.WriteLine("\n [-] Presiona Enter para continuar...");
            Console.ReadLine();
            Console.Clear();

            //Usamos clases anonimas para mostrar el resumen de cada cuenta
            var resumenCuentas = new[] {
                new { CuentaNum = cajaAhorro1.Numero, Saldo = cajaAhorro1.Saldo, Titular = string.Join(", ", cajaAhorro1.Titulares), Estado = cajaAhorro1.Estado },
                new { CuentaNum = cajaAhorro2.Numero, Saldo = cajaAhorro2.Saldo, Titular = string.Join(", ", cajaAhorro2.Titulares), Estado = cajaAhorro2.Estado },
                new { CuentaNum = cuentaCorriente1.Numero, Saldo = cuentaCorriente1.Saldo, Titular = string.Join(", ", cuentaCorriente1.Titulares), Estado = cuentaCorriente1.Estado },
                new { CuentaNum = cuentaCorriente2.Numero, Saldo = cuentaCorriente2.Saldo, Titular = string.Join(", ", cuentaCorriente2.Titulares), Estado = cuentaCorriente2.Estado }
            };

            string titulo = "RESUMEN DE CUENTAS";
            int anchoTotal = 83;
            int espacioIzquierdo = (anchoTotal - titulo.Length) / 2;
            Console.WriteLine("\n" + new string(' ', espacioIzquierdo) + titulo);
            Console.WriteLine(new string('-', 83));
            Console.WriteLine($"| {"Número",-10} | {"Tipo",-17} | {"Saldo",-10} | {"Titulares",-20} | {"Estado",-10} |");
            Console.WriteLine(new string('-', 83));

            foreach (var cuenta in resumenCuentas)
            {
                string tipo = cuenta.CuentaNum.StartsWith("CA") ? "Caja de Ahorro" : "Cuenta Corriente";
                Console.WriteLine($"| {cuenta.CuentaNum,-10} | {tipo,-17} | {cuenta.Saldo,10:C} | {cuenta.Titular,-20} | {cuenta.Estado,-10} |");
            }

            Console.WriteLine(new string('-', 83));

            Console.WriteLine("\n [-] Presiona Enter para continuar...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
