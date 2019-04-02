using EjercicioCuentaCorriente.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace EjercicioCuentaCorriente.CuentasCorrientes
{
    /// <summary>
    /// Clase encargada de gestionar las cuentas corrientes de los clientes
    /// </summary>
    [DataContract]
    public class CuentaCorriente
    {
        #region Propiedades Publicas
        [DataMember]
        public string Nombre { get; set; }
        #endregion

        #region Propiedades Publicas de Consulta
        [DataMember]
        public int ID { get; private set; }
        #endregion

        #region Variables Privadas
        [DataMember]
        private readonly Reloj _reloj;
        [DataMember]
        private List<Movimientos<decimal>> movimientosSaldo = new List<Movimientos<decimal>>();
        [DataMember]
        private List<Movimientos<decimal>> movimientosDescubierto = new List<Movimientos<decimal>>();
        #endregion

        #region Constructor
        public CuentaCorriente(string nombre, decimal descubierto, int id)
        {
            Nombre = nombre;
            _reloj = Reloj.Instancia;
            ID = id;
            FijarDescubierto(descubierto);
        }
        #endregion

        #region Metodos Publicos
        public void Depositar(decimal monto) => ModificarSaldo(monto);
        public void Extraer(decimal monto) => ModificarSaldo(-monto);
        public void FijarDescubierto(decimal descubierto) => movimientosDescubierto.Add(new Movimientos<decimal>(_reloj.NextTick(), descubierto));
        #endregion

        #region Metodos Publicos de Consulta
        public decimal Saldo(int fecha) => movimientosSaldo.Where(movimiento => movimiento.Fecha <= fecha).Sum(movimiento => movimiento.Valor);
        public decimal Saldo() => movimientosSaldo.Sum(movimiento => movimiento.Valor);
        public decimal Descubierto(int fecha) => movimientosDescubierto.Last(movimiento => movimiento.Fecha <= fecha).Valor;
        public decimal Descubierto() => movimientosDescubierto.Last().Valor;
        #endregion

        #region Metodos Privados
        private void ModificarSaldo(decimal monto) => movimientosSaldo.Add(new Movimientos<decimal>(_reloj.NextTick(), monto));
        #endregion

        /// <summary>
        /// Clase que me permite guardar fecha y valor del movimiento
        /// </summary>
        /// <typeparam name="T">Valor a guardar en el movimiento</typeparam>
        #region Clase Movimientos
        private class Movimientos<T>
        {
            #region Variables Privadas
            private readonly int _fecha;
            private readonly T _valor;
            #endregion

            #region Propiedades Publicas de Consulta
            public int Fecha { get => _fecha; }
            public T Valor { get => _valor; }
            #endregion

            #region Constructor
            public Movimientos(int fecha, T valor)
            {
                _fecha = fecha;
                _valor = valor;
            }
            #endregion
        }
        #endregion
    }
}