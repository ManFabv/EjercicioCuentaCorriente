using EjercicioCuentaCorriente.CuentasCorrientes;
using EjercicioCuentaCorriente.Persistencia;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace EjercicioCuentaCorriente.GestionCuentas
{
    /// <summary>
    /// Mantiene una lista de cuentas corrientes y las gestiona
    /// </summary>
    [DataContract]
    public class GestorCuentas
    {
        #region Variables Privadas
        [DataMember]
        private List<CuentaCorriente> _cuentasCorrientes = new List<CuentaCorriente>();
        private readonly PersistenciaEnArchivo _persistencia;
        #endregion

        #region Constructor y Setup
        public GestorCuentas(PersistenciaEnArchivo persistencia)
        {
            _persistencia = persistencia;
        }
        public void Agregar(CuentaCorriente cuenta) => _cuentasCorrientes.Add(cuenta);
        #endregion

        #region Metodos Publicos
        public void Depositar(CuentaCorriente cuentaCorriente, decimal monto) => Depositar(cuentaCorriente.ID, monto);
        public void Depositar(int idCuentaCorriente, decimal monto)
        {
            var cc = Buscar(idCuentaCorriente);

            cc?.Depositar(monto);
        }
        public void Extraer(CuentaCorriente cuentaCorriente, decimal monto) => Extraer(cuentaCorriente.ID, monto);
        public void Extraer(int idCuentaCorriente, decimal monto)
        {
            var cc = Buscar(idCuentaCorriente);

            cc?.Extraer(monto);
        }
        #endregion

        #region Metodos de Persistencia
        public void Guardar() => _persistencia.Guardar();
        public void Leer() => _persistencia.Leer();
        #endregion

        #region Metodos Publicos de Consulta
        public CuentaCorriente Buscar(int idCuenta) => _cuentasCorrientes.FirstOrDefault(cuenta => cuenta.ID == idCuenta);
        #endregion
    }
}