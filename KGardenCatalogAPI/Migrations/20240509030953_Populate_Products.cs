using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KGardenCatalogAPI.Migrations
{
    /// <inheritdoc />
    public partial class Populate_Products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products(Id, Name, Description, ImageUrl, Price, Stock, DateCreated, CategoryId)" +
                                 "VALUES(NEWID(),'Cocacola', 'A fresh soda 250ml', 'coke.png', 2.5, 50, GETDATE(), 'C67ABF13-2026-4470-9DF4-E9D298744B26')");

            migrationBuilder.Sql("INSERT INTO Products(Id, Name, Description, ImageUrl, Price, Stock, DateCreated, CategoryId)" +
                     "VALUES(NEWID(),'Cereal', 'Healthy breakfast option 500g', 'cereal.jpg', 3.5, 30, GETDATE(), '8C884AA3-357C-4694-8408-70C9A088A2CE')");

            migrationBuilder.Sql("INSERT INTO Products(Id, Name, Description, ImageUrl, Price, Stock, DateCreated, CategoryId)" +
                     "VALUES(NEWID(),'Cheeseburger', 'Classic cheeseburger with fries', 'cheeseburger.jpg', 5.99, 20, GETDATE(), '62C354BD-A300-43C0-80BA-178E2B6D0027')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
