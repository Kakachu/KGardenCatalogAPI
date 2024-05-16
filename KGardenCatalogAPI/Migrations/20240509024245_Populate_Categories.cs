using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KGardenCatalogAPI.Migrations
{
    /// <inheritdoc />
    public partial class Populate_Categories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"Insert Into Categories(Id, Name, ImageUrl) Values (Newid(), 'Drinks','drinks.jpg')");
            migrationBuilder.Sql($"Insert Into Categories(Id, Name, ImageUrl) Values (Newid(),'Breakfast','breakfast.jpg')");
            migrationBuilder.Sql($"Insert Into Categories(Id, Name, ImageUrl) Values (Newid(),'FastFood','fastfood.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categories");
        }
    }
}
