using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CodeFist_1.Migrations
{
    /// <inheritdoc />
    public partial class _13m : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Rel_Autores_Libros",
                table: "Rel_Autores_Libros");

            migrationBuilder.DropIndex(
                name: "IX_Rel_Autores_Libros_id_libro",
                table: "Rel_Autores_Libros");

            migrationBuilder.DropColumn(
                name: "id_rel_autores_libros",
                table: "Rel_Autores_Libros");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rel_Autores_Libros",
                table: "Rel_Autores_Libros",
                columns: new[] { "id_libro", "id_autor" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Rel_Autores_Libros",
                table: "Rel_Autores_Libros");

            migrationBuilder.AddColumn<int>(
                name: "id_rel_autores_libros",
                table: "Rel_Autores_Libros",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rel_Autores_Libros",
                table: "Rel_Autores_Libros",
                column: "id_rel_autores_libros");

            migrationBuilder.CreateIndex(
                name: "IX_Rel_Autores_Libros_id_libro",
                table: "Rel_Autores_Libros",
                column: "id_libro");
        }
    }
}
