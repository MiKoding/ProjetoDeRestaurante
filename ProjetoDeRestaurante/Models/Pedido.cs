﻿namespace ProjetoDeRestaurante.Models
{
    public class Pedido
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoDetalhada { get; set; }
        public decimal Preco { get; set; }  
        public string ImagemUrl { get; set; }
        public string ImagemThumbnailUrl { get; set; }
        public bool IsPedidoPreferido { get; set; }
        public bool EmEstoque { get; set; } 

        public int CategoriaId { get; set; }    
        public virtual Categoria Categoria { get; set; }





    }
}
