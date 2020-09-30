using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_1___DA1
{
    public class Logica
    {
        public bool ValidacionNombre(String unNombre) // LE FALTA LAS EXCEPCIONES //
        {
            int cantidad = unNombre.Length;
            if (cantidad > 15 || cantidad < 3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ValidacionListaPalabras(List<string> unaLista) { // LE FALTA LAS EXCEPCIONES //
            int cantidad = unaLista.Count();
            bool retorno = true;
            if (cantidad > 10)
                retorno = false;
            return retorno;
        }

        public void ModificacionDePalabraClave(List<string> unaLista, String PalabraBuscada, String NuevaPalabraClave) { // LE FALTA LAS EXCEPCIONES //
            bool Terminar = true;
            for (int i= 0; i < unaLista.Count() && Terminar; i++) {
                if (unaLista[i] == PalabraBuscada)
                {
                    unaLista.RemoveAt(i);
                    unaLista.Add(NuevaPalabraClave);
                    Terminar = false;
                }
            }
        }

        public void AgregarUnaPalabraClave(List<string> Lista, String NuevaPalabra) {  // LE FALTA LAS EXCEPCIONES //
            bool hayLugar = ValidacionListaPalabras(Lista);
            if (hayLugar) {
                Lista.Add(NuevaPalabra);
            }
        }


    }
}
