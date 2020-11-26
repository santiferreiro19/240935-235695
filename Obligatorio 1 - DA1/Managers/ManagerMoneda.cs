using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
using Persistencia;
using System.Linq;

namespace Managers
{
    public class ManagerMoneda
    {
        private Repositorio Repo;
        private const int MAX_CARACTERES_NOMBRE = 20;
        private const int MIN_CARACTERES_NOMBRE = 3;
        private const int MAX_CARACTERES_SIMBOLO = 3;
        private const int MIN_CARACTERES_SIMBOLO = 1;
        private const int CARACTERES_PERMITIDOS_COTIZACION = 3;
        public ManagerMoneda(Repositorio unRepositorio)
        {
            this.Repo = unRepositorio;
        }
        public void ValidacionNombreMoneda(string unNombre)
        {
            if (unNombre.Length > MAX_CARACTERES_NOMBRE || unNombre.Length < MIN_CARACTERES_NOMBRE)
            {
                throw new ExceptionNombreMoneda("El largo del nombre de la moneda no puede ser mayor a 20 o menor a 3");
            }
        }
        public void ValidacionSimboloMoneda(string unSimbolo)
        {
            if (unSimbolo.Length > MAX_CARACTERES_SIMBOLO || unSimbolo.Length < MIN_CARACTERES_SIMBOLO)
            {
                throw new ExceptionSimboloMoneda("El largo del simbolo de la moneda no puede ser mayor a 3 o menor a 1");
            }
        }

        public void ValidacionCotizacionMoneda(decimal unaCotizacion)
        {
            if (unaCotizacion < 0.00M)
            {
                throw new ExceptionCotizacion("El monto debe ser mayor a 0");
            }
            else
            {
                string MontoEnString = unaCotizacion.ToString();
                if (!MontoEnString.Contains('.'))
                {
                    throw new ExceptionCotizacion("El monto debe tener .");
                }
                else
                {
                    int CantidadDeciamales = 0;
                    for (int caracter = MontoEnString.IndexOf('.'); caracter < MontoEnString.Length; caracter++)
                    {
                        CantidadDeciamales++;
                    }
                    if (CantidadDeciamales < CARACTERES_PERMITIDOS_COTIZACION || CantidadDeciamales > CARACTERES_PERMITIDOS_COTIZACION)
                        throw new ExceptionCotizacion("El monto debe tener . y dos decimales");
                }
            }
        }
        public void ValidacionAgregarMoneda(Moneda unaMoneda)
        {
            this.ValidacionNombreMoneda(unaMoneda.Nombre);
            this.ValidacionSimboloMoneda(unaMoneda.Simbolo);
            this.ValidacionCotizacionMoneda(unaMoneda.Cotizacion);
            Repo.AgregarMoneda(unaMoneda);
        }

        public void ValidacionEliminarMoneda(Moneda unaMoneda)
        {
            Repo.EliminarMoneda(unaMoneda);
        }
        public void ValidacionModificacionMoneda(Moneda unaMoneda, Moneda modificada)
        {
            this.ValidacionNombreMoneda(modificada.Nombre);
            this.ValidacionSimboloMoneda(modificada.Simbolo);
            this.ValidacionCotizacionMoneda(modificada.Cotizacion);
            Repo.ModificarMoneda(unaMoneda, modificada);
        }
    }
}
