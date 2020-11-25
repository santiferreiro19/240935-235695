﻿using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
using Persistencia;
using System;
using System.Collections.Generic;

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
            DateTime Maximo = new DateTime(2031, 01, 01);
            if (unaFecha.CompareTo(Minimo) == -1 || unaFecha.CompareTo(Maximo) >= 0)
                throw new ExceptionFechaGasto("La fecha debe ser entre 01/01/2018 y 31/12/2030");
        }

        public decimal TransformarMonto(decimal unMonto)
        {
            return Math.Round(unMonto, 2);
        }

        public void ValidarMonto(decimal unMonto)
        {
            if (unMonto <= 0)
                throw new ExceptionMonto("El monto  debe ser mayor a 0");
        }

        public void ValidacionAgregarGasto(Gasto unGasto)
        {
            this.ValidacionDescripcionGasto(unGasto.Descripcion);
            this.ValidacionFechaGasto(unGasto.Fecha);
            this.ValidarMonto(unGasto.Monto);
            Repo.AgregarGasto(unGasto);
        }
        public void ValidacionEliminarGasto(Gasto unGasto)
        {
            Repo.EliminarGasto(unGasto);
        }

        public void ValidacionModificacionGasto(Gasto unGasto, Gasto Modificado)
        {
            this.ValidacionEliminarGasto(unGasto);
            this.ValidacionAgregarGasto(Modificado);
            
        }
        public List<Categoria> ValidacionBusquedaCategorias(String Descripcion)
        {
            String[] PalabrasParaBuscar = Descripcion.Split(' ');
            Categoria CategoriaEncontrada = Repo.BusquedaCategorias(PalabrasParaBuscar);
            List<Categoria> categoriasEncontradas = new List<Categoria>();
            if (CategoriaEncontrada.Nombre == "")
            {
                categoriasEncontradas = Repo.GetCategorias().GetAll();
            }
            else
            {
                categoriasEncontradas.Add(CategoriaEncontrada);
            }

            return categoriasEncontradas;
        }

        public List<String> CargarFechasDondeHuboGastos()
        {
            List<String> ListaDeFechasGastos = new List<String>();
            foreach (Gasto unGasto in Repo.GetGastos().GetAll())
            {
                String FechaFormateada = unGasto.Fecha.ToString("MMMM yyyy");
                if (!ListaDeFechasGastos.Contains(FechaFormateada))
                {
                    ListaDeFechasGastos.Add(FechaFormateada);
                }
            }
            return ListaDeFechasGastos;
        }

        public List<Gasto> FiltrarGastosPorFecha(String unPeriodo)
        {
            List<Gasto> ListaDeGastosParaFecha = new List<Gasto>();
            foreach (Gasto unGasto in Repo.GetGastos().GetAll())
            {
                String FechaFormateada = unGasto.Fecha.ToString("MMMM yyyy");
                if (FechaFormateada == unPeriodo)
                {
                    ListaDeGastosParaFecha.Add(unGasto);
                }
            }
            return ListaDeGastosParaFecha;
        }

        public string SumaDeGastosParaFecha(List<Gasto> ListaGastosParaFecha)
        {
            decimal Total = 0.00M;
            foreach (Gasto unGasto in ListaGastosParaFecha)
            {
                Total += Math.Round((unGasto.Monto * unGasto.CotizacionActual),2);
            }
            return Total.ToString();
        }

        public List<Gasto> ObtenerGastosPorFechaCategoria(Categoria unaCategoriaP, string unaFecha)
        {
            List<Gasto> ListaDeGastosParaFechaCategoria = new List<Gasto>();
            foreach (Gasto unGasto in Repo.GetGastos().GetAll())
            {
                string FechaFormateada = unGasto.Fecha.ToString("MMMM yyyy");
                if (FechaFormateada == unaFecha && unGasto.Categoria.Id == unaCategoriaP.Id)
                {
                    ListaDeGastosParaFechaCategoria.Add(unGasto);
                }
            }
            return ListaDeGastosParaFechaCategoria;
        }
    }
}
