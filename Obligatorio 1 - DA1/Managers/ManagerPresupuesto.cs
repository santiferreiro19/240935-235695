using System;
using System.Collections.Generic;
using System.Linq;
using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
using Persistencia;

namespace Managers
{
    public class ManagerPresupuesto
    {
        private Repositorio Repo;

        public ManagerPresupuesto(Repositorio unRepositorio)
        {
            this.Repo = unRepositorio;
        }

        public void ValidacionAño(int unAño)
        {
            if (unAño > 2030 || unAño < 2018)
            {
                throw new ExceptionAñoPresupuesto("El año debe ser entre 2018 y 2030");
            }
        }

        public void ValidacionMonto(decimal unMonto)
        {
            if (unMonto < 0)
            {
                throw new ExceptionMontoPresupuesto("El monto debe ser mayor a 0");
            }
            else
            {
                string MontoEnString = unMonto.ToString();
                if (!MontoEnString.Contains('.'))
                {
                    throw new ExceptionMontoPresupuesto("El monto debe tener .");
                }
                else
                {
                    int CantidadDeciamales = 0;
                    int MininimosDecimalesPosibles = 3;
                    for (int caracter = MontoEnString.IndexOf('.'); caracter < MontoEnString.Count(); caracter++)
                    {
                        CantidadDeciamales++;
                    }
                    if (CantidadDeciamales < MininimosDecimalesPosibles)
                        throw new ExceptionMontoPresupuesto("El monto debe tener . y por lo menos dos decimales");
                }
            }

        }

        public decimal TransformarMonto(decimal unMonto)
        {
            return Math.Round(unMonto, 2);
        }

        public void CargarCategoriasPresupuesto(Presupuesto unPresupuesto)
        {
            List<MontoCategoria> Retorno = new List<MontoCategoria>();
            foreach (Categoria elem in Repo.GetCategorias().GetAll()) {
                MontoCategoria temporal = new MontoCategoria();
                temporal.Cat = elem;
                unPresupuesto.PresupuestosCategorias.Add(temporal);
            }
            Repo.GetPresupuestos().Update(unPresupuesto);
        }

        public void ValidacionAgregarUnMonto(Presupuesto unPresupuestosMonto, Categoria unaCategoria, decimal unMonto)
        {
            this.ValidacionMonto(unMonto);
            decimal MontoTransformado = this.TransformarMonto(unMonto);
            foreach (MontoCategoria montoCat in unPresupuestosMonto.PresupuestosCategorias) {
                if (montoCat.Cat.Id == unaCategoria.Id) {
                    montoCat.Monto = MontoTransformado;
                    Repo.GetPresupuestos().Update(unPresupuestosMonto);
                }
            }
        }

        public void ValidacionAgregarPresupuesto(Presupuesto nuevoPresupuesto)
        {
            this.ValidacionAño(nuevoPresupuesto.Año);
            bool repetido = false;
            foreach (Presupuesto unPresupuesto in Repo.GetPresupuestos().GetAll())
            {
                if (nuevoPresupuesto.Mes == unPresupuesto.Mes && unPresupuesto.Año == nuevoPresupuesto.Año)
                {
                    repetido = true;
                }
            }
            if (!repetido)
            {
                Repo.AgregarPresupuesto(nuevoPresupuesto);
            }
            else
            {
                throw new ExceptionPresupuestoRepetido("Presupuesto ya existente");
            }
        }


        public void ValidacionModificarPresupuesto(Presupuesto unPresupuesto, Categoria unaCategoria, decimal unMonto)
        {
            this.ValidacionMonto(unMonto);
            decimal nuevoMonto = this.TransformarMonto(unMonto);
            Repo.ModificarMontoPresupuesto(unPresupuesto, unaCategoria, nuevoMonto);
        }

        public List<string> CargarListaDondeHuboPresupuestos()
        {
            List<string> ListaDePresupuestosFecha = new List<string>();
            foreach (Presupuesto unPresupuesto in Repo.GetPresupuestos().GetAll())
            {
                string BuscarMes = unPresupuesto.Mes;
                string BuscarAño = unPresupuesto.Año.ToString();
                string AñoYMes = BuscarMes + " " + BuscarAño;
                if (!ListaDePresupuestosFecha.Contains(AñoYMes))
                {
                    ListaDePresupuestosFecha.Add(AñoYMes);
                }
            }
            return ListaDePresupuestosFecha;
        }

        public Presupuesto BuscarPresupuestosPorFecha(string unPeriodo)
        {
            Presupuesto Encontrado = new Presupuesto();
            string[] PalabraDividida = unPeriodo.Split(' ');
            string unMes = PalabraDividida[0];
            string unAño = PalabraDividida[1];
            foreach (Presupuesto unPresupuesto in Repo.GetPresupuestos().GetAll())
            {
                if (unPresupuesto.Mes == unMes && unPresupuesto.Año == int.Parse(unAño))
                {
                    Encontrado = unPresupuesto;
                }
            }
            return Encontrado;
        }
    }
}
