namespace Obligatorio_1___DA1
{
    public class Moneda
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Simbolo { set; get; }
        public decimal Cotizacion { set; get; }

        public Moneda(string unNombre, string unSimbolo, decimal unaCotizacion)
        {
            this.Nombre = unNombre;
            this.Simbolo = unSimbolo;
            this.Cotizacion = unaCotizacion;
        }
        public Moneda()
        {
            this.Nombre = "";
            this.Simbolo = "";
            this.Cotizacion = 0.00M;
        }

        override
        public string ToString()
        {
            return Simbolo;
        }
    }
}
