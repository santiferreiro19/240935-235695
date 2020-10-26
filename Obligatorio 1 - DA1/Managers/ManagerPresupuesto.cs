﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Dictionary<Categoria, decimal> CargarCategoriasPresupuesto()
        {
            Dictionary<Categoria, decimal> Retorno = Repo.GetCategorias().ToDictionary(x => x, x => 0M);
            return Retorno;
        }

        public void ValidacionAgregarUnMonto(Dictionary<Categoria, decimal> unPresupuestosMonto, Categoria unaCategoria, decimal unMonto)
        {
            this.ValidacionMonto(unMonto);
            decimal MontoTransformado = this.TransformarMonto(unMonto);
            unPresupuestosMonto[unaCategoria] = MontoTransformado;
        }

        public void ValidacionAgregarPresupuesto(int unAño, string unMes, Dictionary<Categoria, decimal> unPresupuestosMonto)
        {
            this.ValidacionAño(unAño);
            Presupuesto nuevoPresupuesto = new Presupuesto(unAño, unMes, unPresupuestosMonto);
            Repo.AgregarPresupuesto(nuevoPresupuesto);
        }

        public void ValidacionModificarPresupuesto(Presupuesto unPresupuesto, Categoria unaCategoria, decimal unMonto)
        {
            this.ValidacionMonto(unMonto);
            decimal nuevoMonto = this.TransformarMonto(unMonto);
            Repo.ModificarMontoPresupuesto(unPresupuesto, unaCategoria, nuevoMonto);
        }
    }
}
