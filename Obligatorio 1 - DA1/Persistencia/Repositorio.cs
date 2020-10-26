using System;
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
        public Repositorio()
        {
            this.ListaCategorias = new List<Categoria>();
            this.ListaGastos = new List<Gasto>();
            this.ListaPresupuestos = new List<Presupuesto>();
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
                    buscada.ListaPalabras.Add(NuevaPalabra);
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
                        if (PalabraAnterior == unacategoria.ListaPalabras[i])
                        {
                            unacategoria.ListaPalabras.RemoveAt(i);
                            unacategoria.ListaPalabras.Add(NuevaPalabra);
                        }
                    }
                }
            }
        }

        public void EliminarPalabraClave(String PalabraABorrar)
        {
            foreach (Categoria buscada in this.ListaCategorias)
            {
                if (buscada.ListaPalabras.Contains(PalabraABorrar))
                {
                    buscada.ListaPalabras.Remove(PalabraABorrar);
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

        public void ModificarDescripcion(String nuevaD, Gasto g)
        {
            foreach (Gasto buscado in this.ListaGastos)
            {
                if (buscado.Equals(g))
                {
                    buscado.Descripcion = nuevaD;
                }
            }
        }

        public void ModificarMontoGasto(Gasto g, decimal nuevoMonto)
        {
            foreach (Gasto buscado in this.ListaGastos)
            {
                if (buscado.Equals(g))
                {
                    buscado.Monto = nuevoMonto;
                }
            }
        }

        public void ModificarFechaGasto(Gasto g, DateTime nuevaFecha)
        {
            foreach (Gasto buscado in this.ListaGastos)
            {
                if (buscado.Equals(g))
                {
                    buscado.Fecha = nuevaFecha;
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
                    if (cadaCategoria.ListaPalabras.Contains(buscada))
                    {
                        Retorno = cadaCategoria;
                        Contador++;
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
        public void ModificacionCategoriaGasto(Gasto g, Categoria categoria)
        {
            foreach (Gasto buscado in this.ListaGastos)
            {
                if (buscado.Equals(g))
                {
                    buscado.unaCategoria = categoria;
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
                    unPresupuesto.PresupuestosCategorias[unaCategoria] = unNuevoMonto;
                }
            }
        }

        public void ActualizarCategoriaEnPresupuestos(Categoria nuevaCategoria)
        {
            foreach (Presupuesto actualizar in this.ListaPresupuestos)
            {
                actualizar.PresupuestosCategorias.Add(nuevaCategoria, 0M);
            }
        }
    }
}
