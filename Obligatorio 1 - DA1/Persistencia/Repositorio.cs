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
        public Repositorio()
        {
            this.ListaCategorias = new List<Categoria>();
            this.ListaGastos = new List<Gasto>();
        }

        public List<Categoria> GetCategorias()
        {
            return this.ListaCategorias;
        }

        public List<Gasto> GetGastos()
        {
            return this.ListaGastos;
        }
        public void AgregarCategoria(Categoria unacategoria)
        {
            this.ListaCategorias.Add(unacategoria);
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

        public void ModificarDescripcion(String nuevaD, Gasto g) {
            foreach (Gasto buscado in this.ListaGastos) {
                if (buscado.Equals(g)) {
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
    }
}
