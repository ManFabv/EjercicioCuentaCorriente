using System;

namespace EjercicioCuentaCorriente.UI
{
    /// <summary>
    /// Clase que maneja la interfaz de usuario
    /// </summary>
    public class ConsoleUI
    {
        #region Variables privadas
        private char opcion = ' ';
        #endregion

        #region Metodos Publicos
        public char Correr()
        {
            Console.Clear();

            DibujarMenu();

            opcion = Console.ReadKey().KeyChar;

            return opcion;
        }
        #endregion

        #region Metodos Privados
        private void DibujarMenu()
        {
            Console.WriteLine("MENU:\n");
            Console.WriteLine("1 Listar");
            Console.WriteLine("2 Depositar");
            Console.WriteLine("3 Extraer");
            Console.WriteLine("4 Descubierto");
            Console.WriteLine("5 Salir\n");

            Console.Write("Opcion: ");
        }
        #endregion
    }
}
