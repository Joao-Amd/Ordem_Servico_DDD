using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meraki.Estoque.Data.Migrations
{
    /// <inheritdoc />
    public partial class IniciadoEstoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "unidadade",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    sigla = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    descricao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    fator = table.Column<decimal>(type: "numeric(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidadade", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    identificacao = table.Column<int>(type: "integer", nullable: false),
                    descricao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    preco = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    id_unidade = table.Column<Guid>(type: "uuid", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_item_unidadade_id_unidade",
                        column: x => x.id_unidade,
                        principalTable: "unidadade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item_estoque",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_item = table.Column<Guid>(type: "uuid", nullable: false),
                    saldo = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_estoque", x => x.id);
                    table.ForeignKey(
                        name: "FK_item_estoque_item_id_item",
                        column: x => x.id_item,
                        principalTable: "item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_item_id_unidade",
                table: "item",
                column: "id_unidade");

            migrationBuilder.CreateIndex(
                name: "IX_item_estoque_id_item",
                table: "item_estoque",
                column: "id_item");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "item_estoque");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "unidadade");
        }
    }
}
