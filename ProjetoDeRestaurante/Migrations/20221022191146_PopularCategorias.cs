using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoDeRestaurante.Migrations
{
    public partial class PopularCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias (CategoriaNome, Descricao)"+
                ("VALUES ('Normal','Pedido Feito com ingredientes normais')"));
            
            migrationBuilder.Sql("INSERT INTO Categorias (CategoriaNome, Descricao)"+
                ("VALUES ('Naturais','Pedido Feito com ingredientes integrais e naturais')"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
