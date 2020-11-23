namespace Obligatorio_1___DA1
{
    public class MontoCategoria
    {
        public int Id { get; set; }
        public decimal Monto { set; get; }
<<<<<<< HEAD
         public Categoria Cat { set; get; }

        public MontoCategoria()
        {
            
=======
        public Categoria Cat { set; get; }

        public MontoCategoria()
        {
            Monto = 0.00M;
        }
        public MontoCategoria(Categoria unaCategoria, decimal unMonto)
        {
            this.Monto = unMonto;
            this.Cat = unaCategoria;

>>>>>>> feature/RefactorParaTrabajarConEF
        }


        override
         public string ToString()
        {
            return Cat.Nombre;
        }
    }
}
