namespace ProjetoDeRestaurante.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        public string CategoriaNome { get; set; }
        public string Descricao { get; set; }   

        public List<Pedido> Pedidos { get; set; }
    }
}
