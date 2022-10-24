using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoDeRestaurante.Migrations
{
    public partial class PopularPedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("INSERT INTO Pedido (CategoriaId, DescricaoCurta, DescricaoDetalhada, EmEstoque, ImagemThumbnailUrl, ImagemUrl, IsPedidoPreferido, Nome, Preco)" +
                ("VALUES (1,'Arroz, Feijão Preto, Carne de Sol', 'Famoso prato brasileiro bem suculento e saboroso', 1, 'https://duisktnou8b89.cloudfront.net/img/items/5f073d0d717ce.png', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR6lLHWRhnqDOWZijFMOlv7R4kxPxucDyHQ2w&usqp=CAU', 1, 'Carne de Sol', 25.50)"));
            migrationBuilder.Sql("INSERT INTO Pedido (CategoriaId, DescricaoCurta, DescricaoDetalhada, EmEstoque, ImagemThumbnailUrl, ImagemUrl, IsPedidoPreferido, Nome, Preco)" +
                ("VALUES (2,'Maniva, Arroz, Carne de Soja', 'Famoso prato paraense feito de plantas venenosas e ingredientes integrais', 1, 'https://www.comidaereceitas.com.br/img/sizeswp/1200x675/2008/10/manicoba.jpg', 'https://s2.glbimg.com/KdU6mRFXAQ9OmQMGimfm6382VjQ=/0x0:620x385/984x0/smart/filters:strip_icc()/g.glbimg.com/og/gs/gsat5/f/thumbs/materia/2014/05/15/que-marravilha-08-receita-385.jpg', 1, 'Maniçoba', 50.00)"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Pedido");
        }
    }
}
