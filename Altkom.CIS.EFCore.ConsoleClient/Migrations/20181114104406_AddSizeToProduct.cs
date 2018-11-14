using Microsoft.EntityFrameworkCore.Migrations;

namespace Altkom.CIS.EFCore.ConsoleClient.Migrations
{
    public partial class AddSizeToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Items",
                nullable: true);

            migrationBuilder.Sql("UPDATE Items SET Size = 'XL' WHERE Discriminator = 'Product' ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Items");
        }
    }
}
