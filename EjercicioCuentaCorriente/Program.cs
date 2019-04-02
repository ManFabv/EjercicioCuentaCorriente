using EjercicioCuentaCorriente.CuentasCorrientes;
using EjercicioCuentaCorriente.GestionCuentas;
using EjercicioCuentaCorriente.Persistencia;
using EjercicioCuentaCorriente.UI;
using System;

namespace EjercicioCuentaCorriente
{
    class Program
    {
        static void Main()
        {
            var cc = new CuentaCorriente("Fabricio", 1000, 1);
            cc.FijarDescubierto(2000);
            cc.FijarDescubierto(500);
            cc.Depositar(400);
            cc.Extraer(100);

            Console.WriteLine("USANDO CUENTA CORRIENTE");
            Console.WriteLine("Descubierto al 1 = " + cc.Descubierto(1));
            Console.WriteLine("Descubierto actual = " + cc.Descubierto());
            Console.WriteLine("Saldo al 1 = " + cc.Saldo(1));
            Console.WriteLine("Saldo actual = " + cc.Saldo());
            Console.WriteLine("Nombre = " + cc.Nombre + "\n");

            var persistencia = new PersistenciaEnArchivo();
            var gestor = new GestorCuentas(persistencia);
            gestor.Agregar(cc);
            gestor.Depositar(cc, 2000);
            gestor.Extraer(cc, 750);

            cc = gestor.Buscar(cc.ID);
            cc.FijarDescubierto(20000);
            cc.Nombre = "Manrique";

            Console.WriteLine("USANDO GESTOR");
            Console.WriteLine("Descubierto al 2 = " + cc.Descubierto(2));
            Console.WriteLine("Descubierto actual = " + cc.Descubierto());
            Console.WriteLine("Saldo al 2 = " + cc.Saldo(2));
            Console.WriteLine("Saldo actual = " + cc.Saldo());
            Console.WriteLine("Nombre = " + cc.Nombre + "\n");

            Console.Write("\nPresione una tecla para acceder al menu... ");
            Console.ReadKey();

            var consoleUI = new ConsoleUI();
            char opcion = ' ';

            do
            {
                opcion = consoleUI.Correr();

            } while (opcion != '5');

            Console.Write("\n\nPresione una tecla... ");
            Console.ReadKey();
        }
    }
}