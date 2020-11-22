using System;
using System.Collections.Generic;
using System.Linq;
using Obligatorio_1___DA1;

namespace Persistencia
{
    public class Repositorio
    {
        private ILista<Categoria> ListaCategorias { get; set; }
        private ILista<Gasto> ListaGastos { get; set; }
        private ILista<Presupuesto> ListaPresupuestos { get; set; }
        private ILista<Moneda> ListaMonedas { get; set; }
        private ILista<PalabraClave> ListaPalabrasClave { get; set; }
        private ILista<MontoCategoria> ListaMontos { get; set; }

        public Repositorio()
        {
            this.ListaCategorias = new IListaCategorias();
            this.ListaGastos = new IListaGastos();
            this.ListaPresupuestos = new IListaPresupuestos();
            this.ListaMonedas = new IListaMonedas();
            this.ListaPalabrasClave = new IListaPalabraClave();
        }

        public ILista<Categoria> GetCategorias()
        {
            return this.ListaCategorias;
        }
        public ILista<PalabraClave> GetPalabrasClave()
        {
            return this.ListaPalabrasClave;
        }

        public ILista<Gasto> GetGastos()
        {
            return this.ListaGastos;
        }
        public ILista<Presupuesto> GetPresupuestos()
        {
            return this.ListaPresupuestos;
        }
        public ILista<Moneda> GetMonedas()
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
            foreach (Categoria buscada in this.ListaCategorias.GetAll())
            {
                if (buscada.Id == unacategoria.Id)
                {
                    buscada.Nombre = NuevoNombre;
                    this.GetCategorias().Update(buscada);
                }
            }
        }

        public void AgregarPalabraClave(Categoria unacategoria, String NuevaPalabra)
        {
            foreach (Categoria buscada in this.ListaCategorias.GetAll())
            {
                if (buscada.Id == unacategoria.Id)
                {
                    PalabraClave palabra = new PalabraClave(NuevaPalabra);
                    buscada.ListaPalabras.Add(palabra);
                    this.GetCategorias().Update(buscada);
                }
            }
        }

        public void ModificarPalabraClave(Categoria unacategoria, String NuevaPalabra, String PalabraAnterior)
        {
            foreach (Categoria buscada in this.ListaCategorias.GetAll())
            {
                if (buscada.Id==unacategoria.Id)
                {
                    for (int i = 0; i < buscada.ListaPalabras.Count(); i++)
                    {
                        if (PalabraAnterior == buscada.ListaPalabras[i].Palabra)
                        {
                            buscada.ListaPalabras[i].Palabra = NuevaPalabra;
                            this.GetCategorias().Update(buscada);
                            
                        }
                    }
                }
            }
        }

        public void EliminarPalabraClave(String PalabraABorrar)
        {
            foreach (Categoria buscada in this.ListaCategorias.GetAll())
            {
                foreach (PalabraClave palabraBusqueda in buscada.ListaPalabras)
                {
                    if (palabraBusqueda.Palabra == PalabraABorrar)
                    {
                        this.GetPalabrasClave().Remove(palabraBusqueda);

                    }
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
            foreach (Gasto buscado in this.ListaGastos.GetAll())
            {
                if (buscado.Id == unGasto.Id)
                {
                    buscado.Fecha = GastoModificado.Fecha;
                    buscado.Monto = GastoModificado.Monto;
                    buscado.Moneda = GastoModificado.Moneda;
                    buscado.Categoria = GastoModificado.Categoria;
                    buscado.Descripcion = GastoModificado.Descripcion;
                    GastoModificado.Id = unGasto.Id;
                    this.ListaGastos.Update(GastoModificado);
                }
            }
        }

        public Categoria BusquedaCategorias(String[] palabrasBuscadas)
        {
            Categoria Retorno = new Categoria();
            var Contador = 0;
            foreach (String buscada in palabrasBuscadas)
            {
                foreach (Categoria cadaCategoria in this.ListaCategorias.GetAll())
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

            if (Contador == 0)
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
            foreach (Gasto buscado in this.ListaGastos.GetAll())
            {
                if (buscado.Id == unGasto.Id)
                {
                    buscado.Categoria = categoria;
                    this.ListaGastos.Update(buscado);
                }
            }
        }

        public void AgregarPresupuesto(Presupuesto unPresupuesto)
        {
            this.ListaPresupuestos.Add(unPresupuesto);
        }

        public void ModificarMontoPresupuesto(Presupuesto unPresupuesto, Categoria unaCategoria, decimal unNuevoMonto)
        {
            foreach (Presupuesto Buscado in this.ListaPresupuestos.GetAll())
            {
                if (Buscado.Id == unPresupuesto.Id)
                {
                    unPresupuesto.getPresupuestosCategorias()[unaCategoria] = unNuevoMonto;
                }
            }
        }

        public void ActualizarCategoriaEnPresupuestos(Categoria nuevaCategoria)
        {
            foreach (Presupuesto actualizar in this.ListaPresupuestos.GetAll())
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
                    MonedaModificada.Id = unaMoneda.Id;
            this.ListaMonedas.Update(MonedaModificada);
        }
    }
}
