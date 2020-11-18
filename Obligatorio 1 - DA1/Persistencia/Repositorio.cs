﻿using System;
using System.Collections.Generic;
using System.Linq;
using Obligatorio_1___DA1;

namespace Persistencia
{
    public class Repositorio
    {
        private List<Categoria> ListaCategorias { get; set; }
        private List<Gasto> ListaGastos { get; set; }
        private List<Presupuesto> ListaPresupuestos { get; set; }
        private List<Moneda> ListaMonedas { get; set; }
        public Repositorio()
        {
            this.ListaCategorias = new List<Categoria>();
            this.ListaGastos = new List<Gasto>();
            this.ListaPresupuestos = new List<Presupuesto>();
            this.ListaMonedas = new List<Moneda>();
        }

        public List<Categoria> GetCategorias()
        {
            return this.ListaCategorias;
        }

        public List<Gasto> GetGastos()
        {
            return this.ListaGastos;
        }
        public List<Presupuesto> GetPresupuestos()
        {
            return this.ListaPresupuestos;
        }
        public List<Moneda> GetMonedas()
        {
            return this.ListaMonedas;
        }
        public void AgregarCategoria(Categoria unacategoria)
        {
            this.ListaCategorias.Add(unacategoria);
            ActualizarCategoriaEnPresupuestos(unacategoria);
        }

        public void ModificarNombreCategoria(Categoria unacategoria, String NuevoNombre)
        {
            foreach (Categoria buscada in this.ListaCategorias)
            {
                if (buscada.Equals(unacategoria))
                {
                    buscada.Nombre = NuevoNombre;
                }
            }
        }

        public void AgregarPalabraClave(Categoria unacategoria, String NuevaPalabra)
        {
            foreach (Categoria buscada in this.ListaCategorias)
            {
                if (buscada.Equals(unacategoria))
                {
                    PalabraClave palabra = new PalabraClave(NuevaPalabra);
                    buscada.ListaPalabras.Add(palabra);
                }
            }
        }

        public void ModificarPalabraClave(Categoria unacategoria, String NuevaPalabra, String PalabraAnterior)
        {
            foreach (Categoria buscada in this.ListaCategorias)
            {
                if (buscada.Equals(unacategoria))
                {
                    for (int i = 0; i < unacategoria.ListaPalabras.Count(); i++)
                    {
                        if (PalabraAnterior == unacategoria.ListaPalabras[i].Palabra)
                        {
                            unacategoria.ListaPalabras.RemoveAt(i);
                            PalabraClave palabra = new PalabraClave(NuevaPalabra);
                            unacategoria.ListaPalabras.Add(palabra);
                        }
                    }
                }
            }
        }

        public void EliminarPalabraClave(String PalabraABorrar)
        {
            foreach (Categoria buscada in this.ListaCategorias)
            {
                PalabraClave buscar = new PalabraClave(PalabraABorrar);
                if (buscada.ListaPalabras.Any(x => x.Palabra == PalabraABorrar))
                {
                    buscada.ListaPalabras.RemoveAll(x => x.Palabra == PalabraABorrar);
                }
            }
        }

        public void AgregarGasto(Gasto unGasto)
        {
            this.ListaGastos.Add(unGasto);
        }

        public void EliminarGasto(Gasto unGastoBorrar)
        {
            if (this.ListaGastos.Contains(unGastoBorrar))
            {
                this.ListaGastos.Remove(unGastoBorrar);
            }
        }

        public void ModificarGasto(Gasto unGasto, Gasto GastoModificado)
        {
            foreach (Gasto buscado in this.ListaGastos)
            {
                if (buscado.Equals(unGasto))
                {
                    buscado.Fecha = GastoModificado.Fecha;
                    buscado.Monto = GastoModificado.Monto;
                    buscado.Moneda = GastoModificado.Moneda;
                    buscado.Categoria = GastoModificado.Categoria;
                    buscado.Descripcion = GastoModificado.Descripcion;
                }
            }
        }

        public Categoria BusquedaCategorias(String[] palabrasBuscadas)
        {
            Categoria Retorno = new Categoria();
            var Contador = 0;
            foreach (String buscada in palabrasBuscadas)
            {
                foreach (Categoria cadaCategoria in this.ListaCategorias)
                {
                    PalabraClave palabraABuscar = new PalabraClave(buscada);
                    if (cadaCategoria.ListaPalabras.Any(x => x.Palabra == buscada))
                    {
                        if (Retorno != cadaCategoria)
                        {
                            Retorno = cadaCategoria;
                            Contador++;
                        }
                    }
                }
            }

            if (Contador == 0 || Contador > 1)
            {
                Retorno = new Categoria();
                return Retorno;
            }
            else
            {
                return Retorno;
            }
        }
        public void ModificacionCategoriaGasto(Gasto unGasto, Categoria categoria)
        {
            foreach (Gasto buscado in this.ListaGastos)
            {
                if (buscado.Equals(unGasto))
                {
                    buscado.Categoria = categoria;
                }
            }
        }

        public void AgregarPresupuesto(Presupuesto unPresupuesto)
        {
            this.ListaPresupuestos.Add(unPresupuesto);
        }

        public void ModificarMontoPresupuesto(Presupuesto unPresupuesto, Categoria unaCategoria, decimal unNuevoMonto)
        {
            foreach (Presupuesto Buscado in this.ListaPresupuestos)
            {
                if (Buscado == unPresupuesto)
                {
                    unPresupuesto.getPresupuestosCategorias()[unaCategoria] = unNuevoMonto;
                }
            }
        }

        public void ActualizarCategoriaEnPresupuestos(Categoria nuevaCategoria)
        {
            foreach (Presupuesto actualizar in this.ListaPresupuestos)
            {
                actualizar.getPresupuestosCategorias().Add(nuevaCategoria, 0M);
            }
        }

        public void AgregarMoneda(Moneda NuevaMoneda) 
        {
            this.ListaMonedas.Add(NuevaMoneda);
        }

        public void EliminarMoneda(Moneda MonedaBorrar) 
        {
            this.ListaMonedas.Remove(MonedaBorrar);
        }

        public void ModificarMoneda(Moneda unaMoneda, Moneda MonedaModificada)
        {
            foreach (Moneda buscada in this.ListaMonedas)
            {
                if (buscada.Equals(unaMoneda))
                {
                    buscada.Nombre = MonedaModificada.Nombre;
                    buscada.Simbolo = MonedaModificada.Simbolo;
                    buscada.Cotizacion = MonedaModificada.Cotizacion;
                }
            }
        }
    }
}
