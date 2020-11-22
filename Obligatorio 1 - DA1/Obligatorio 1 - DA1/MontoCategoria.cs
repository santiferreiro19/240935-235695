namespace Obligatorio_1___DA1
{
    public class MontoCategoria
    {
        public int Id { get; set; }
        public decimal Monto { set; get; }
         public Categoria Cat { set; get; }

        public MontoCategoria()
        {
            
        }


        override
         public string ToString()
        {
            return Cat.Nombre;
        }
    }
}
