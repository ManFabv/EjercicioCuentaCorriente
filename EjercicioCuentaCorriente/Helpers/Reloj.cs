namespace EjercicioCuentaCorriente.Helpers
{
    /// <summary>
    /// Clase que me permitira gestionar el tiempo
    /// </summary>
    public class Reloj
    {
        #region Variables Privadas
        private int _valorInicial;
        private int _tick;
        #endregion

        public static Reloj Instancia = new Reloj();

        #region Setup y Constructor
        private Reloj() { }
        public void IniciarReloj(int valorInicial = 0)
        {
            _valorInicial = _tick = valorInicial;
        }
        #endregion

        #region Metodos Publicos
        public int Tick() => _tick;
        public int NextTick() => ++_tick;
        public int ReiniciarTick(int valorInicial) => _valorInicial = _tick = valorInicial;
        #endregion
    }
}