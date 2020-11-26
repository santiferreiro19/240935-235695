using Obligatorio_1___DA1;
using System;
using System.Linq;

namespace Persistencia
{
    public class Repositorio
    {
        private IDataAccess<Categoria> ListaCategorias { get; set; }
        private IDataAccess<Gasto> ListaGastos { get; set; }
        private IDataAccess<Presupuesto> ListaPresupuestos { get; set; }
        private IDataAccess<Moneda> ListaMonedas { get; set; }
        private IDataAccess<PalabraClave> ListaPalabrasClave { get; set; }
        private IDataAccess<MontoCategoria> ListaMontos { get; set; }

        public Repositorio()
        {
            this.ListaCategorias = new DataAccessCategorias();
            this.ListaGastos = new DataAccessGastos();
            this.ListaPresupuestos = new DataAccessPresupuestos();
            this.ListaMonedas = new DataAccessMonedas();
            this.ListaPalabrasClave = new DataAccessClave();

            Moneda pesosPorDefecto = new Moneda("Peso Uruguayo", "UYU", 1.00M);
            bool YaEsta = false;
            foreach (Moneda pesoBuscado in this.ListaMonedas.GetAll())
            {
                if (pesosPorDefecto.Simbolo == pesoBuscado.Simbolo)
                {
                    YaEsta = true;
                }
            }
            if (!YaEsta)
            {
                this.ListaMonedas.Add(pesosPorDefecto);
            }
        }

        public IDataAccess<Categoria> GetCategorias()
        {
            return this.ListaCategorias;
        }
        public IDataAccess<PalabraClave> GetPalabrasClave()
        {
            return this.ListaPalabrasClave;
        }

        public IDataAccess<Gasto> GetGastos()
        {
            return this.ListaGastos;
        }
        public IDataAccess<Presupuesto> GetPresupuestos()
        {
            return this.ListaPresupuestos;
        }
        public IDataAccess<Moneda> GetMonedas()
        {
            return this.ListaMonedas;
        }
        public void AgregarCategoria(Categoria unacategoria)
        {
            this.ListaCategorias.Add(unacategoria);
            ActualizarCategoriaEnPresupuestos(unacategoria);
        }

        public void ModificarNombreCategoria(Categoria unacategoria, String nuevoNombre)
        {
            foreach (Categoria buscada in this.ListaCategorias.GetAll())
            {
                if (buscada.Id == unacategoria.Id)
                {
                    buscada.Nombre = nuevoNombre;
                    this.GetCategorias().Update(buscada);
                }
            }
        }

        public void AgregarPalabraClave(Categoria unacategoria, String nuevaPalabra)
        {
            foreach (Categoria buscada in this.ListaCategorias.GetAll())
            {
                if (buscada.Id == unacategoria.Id)
                {
                    PalabraClave palabra = new PalabraClave(nuevaPalabra);
                    buscada.ListaPalabras.Add(palabra);
                    this.GetCategorias().Update(buscada);
                }
            }
        }

        public void ModificarPalabraClave(Categoria unacategoria, String nuevaPalabra, String palabraAnterior)
        {
            foreach (Categoria buscada in this.ListaCategorias.GetAll())
            {
                if (buscada.Id == unacategoria.Id)
                {
                    for (int i = 0; i < buscada.ListaPalabras.Count(); i++)
                    {
                        if (palabraAnterior == buscada.ListaPalabras[i].Palabra)
                        {
                            buscada.ListaPalabras[i].Palabra = nuevaPalabra;
                            this.GetCategorias().Update(buscada);

                        }
                    }
                }
            }
        }

        public void EliminarPalabraClave(String palabraABorrar)
        {
            foreach (Categoria buscada in this.ListaCategorias.GetAll())
            {
                foreach (PalabraClave palabraBusqueda in buscada.ListaPalabras)
                {
                    if (palabraBusqueda.Palabra == palabraABorrar)
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

        public void ModificarGasto(Gasto unGasto, Gasto gastoModificado)
        {
            foreach (Gasto buscado in this.ListaGastos.GetAll())
            {
                if (buscado.Id == unGasto.Id)
                {
                    buscado.Fecha = gastoModificado.Fecha;
                    buscado.Monto = gastoModificado.Monto;
                    buscado.Moneda = gastoModificado.Moneda;
                    buscado.Categoria = gastoModificado.Categoria;
                    buscado.Descripcion = gastoModificado.Descripcion;
                    gastoModificado.Id = unGasto.Id;
                    this.ListaGastos.Update(gastoModificado);
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
                        if (Retorno.Id != cadaCategoria.Id)
                        {
                            Contador++;
                            Retorno = cadaCategoria;
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
                    foreach (MontoCategoria montoAmodificar in Buscado.getPresupuestosCategorias())
                    {
                        if (unaCategoria.Id == montoAmodificar.Cat.Id)
                        {
                            montoAmodificar.Monto = unNuevoMonto;
                            this.ListaPresupuestos.Update(Buscado);
                        }
                    }
                }
            }
        }

        public void ActualizarCategoriaEnPresupuestos(Categoria nuevaCategoria)
        {
            foreach (Presupuesto actualizar in this.ListaPresupuestos.GetAll())
            {
                MontoCategoria nuevoMonto = new MontoCategoria(nuevaCategoria, 0M);
                actualizar.getPresupuestosCategorias().Add(nuevoMonto);
                this.ListaPresupuestos.Update(actualizar);
            }
        }

        public void AgregarMoneda(Moneda nuevaMoneda)
        {
            this.ListaMonedas.Add(nuevaMoneda);
        }

        public void EliminarMoneda(Moneda monedaBorrar)
        {
            this.ListaMonedas.Remove(monedaBorrar);
        }

        public void ModificarMoneda(Moneda unaMoneda, Moneda monedaModificada)
        {
            monedaModificada.Id = unaMoneda.Id;
            this.ListaMonedas.Update(monedaModificada);
        }
    }
}
