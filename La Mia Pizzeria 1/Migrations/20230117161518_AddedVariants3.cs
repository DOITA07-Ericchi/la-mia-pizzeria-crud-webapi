using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaMiaPizzeria1.Migrations
{
    /// <inheritdoc />
    public partial class AddedVariants3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pizzas_Variant_VariantId",
                table: "pizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Variant",
                table: "Variant");

            migrationBuilder.RenameTable(
                name: "Variant",
                newName: "variants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_variants",
                table: "variants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_pizzas_variants_VariantId",
                table: "pizzas",
                column: "VariantId",
                principalTable: "variants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pizzas_variants_VariantId",
                table: "pizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_variants",
                table: "variants");

            migrationBuilder.RenameTable(
                name: "variants",
                newName: "Variant");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Variant",
                table: "Variant",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_pizzas_Variant_VariantId",
                table: "pizzas",
                column: "VariantId",
                principalTable: "Variant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
