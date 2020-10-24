using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
using Persistencia;

namespace Managers
{
    public class ManagerGasto
    {
        private Repositorio Repo;
        public ManagerGasto(Repositorio unRepo)
        {
            this.Repo = unRepo;
        }

        public void ValidacionDescripcionGasto(String unaDescripcion)
        {
            int cantidad = unaDescripcion.Length;
            if (cantidad > 20 || cantidad < 3)
            {
                throw new ExceptionDescripcionGasto("La descripcion debe tener entre 3 y 15 caracteres");
            }
        }

        public void ValidacionFechaGasto(DateTime unaFecha)
        {
            DateTime Minimo = new DateTime(2018, 01, 01);
            DateTime Maximo = new DateTime(2030, 12, 31);
            if (unaFecha.CompareTo(Minimo) == -1 || unaFecha.CompareTo(Maximo) == 1)
                throw new ExceptionFechaGasto("La fecha debe ser entre 01/01/2018 y 31/12/2030");
        }

        public decimal TransformarMonto(decimal unMonto)
        {
            return Math.Round(unMonto, 2);
        }

        public void ValidarMonto(decimal unMonto) {
            if (unMonto < 0)
                throw new ExceptionMonto("El monto no debe ser menor a 0");
        }

        public void ValidacionAgregarGasto(Gasto unGasto) {
            this.ValidacionDescripcionGasto(unGasto.Descripcion);
            this.ValidacionFechaGasto(unGasto.Fecha);
            this.ValidarMonto(unGasto.Monto);
            Repo.AgregarGasto(unGasto);
        }
        public void ValidacionEliminarGasto(Gasto unGasto)
        {
            Repo.EliminarGasto(unGasto);
        }

        public void ValidacionModificacionDescripcionGasto(Gasto unGasto, String nuevaDescripcion) {
            this.ValidacionDescripcionGasto(nuevaDescripcion);
            Repo.ModificarDescripcion(nuevaDescripcion, unGasto);
        }
        public void ValidacionModificacionMontoGasto(Gasto unGasto, decimal nuevoMonto)
        {
            this.ValidarMonto(nuevoMonto);
            Repo.ModificarMontoGasto(unGasto, nuevoMonto);
        }

        public void ValidacionModificacionFechaGasto(Gasto g, DateTime nuevaFecha)
        {
            this.ValidacionFechaGasto(nuevaFecha);
            Repo.ModificarFechaGasto(g, nuevaFecha);
        }

        public String ValidacionBusquedaCategorias(String Descripcion) {
            String[] PalabrasParaBuscar = Descripcion.Split(' ');
            String CategoriasEncontradas = Repo.BusquedaCategorias(PalabrasParaBuscar);
            return CategoriasEncontradas;
        }

        public void ValidacionModificacionCategoriaGasto(Gasto g, Categoria nuevaCategoria)
        {
            Repo.ModificacionCategoriaGasto(g, nuevaCategoria);
        }
    }
}
