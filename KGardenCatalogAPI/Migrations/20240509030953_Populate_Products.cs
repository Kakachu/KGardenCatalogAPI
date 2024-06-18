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
                                 "VALUES(NEWID(),'Cocacola', 'A fresh soda 250ml', 'coke.png', 2.5, 50, GETDATE(), '59654310-28C7-4B58-9230-BFE37C0B6F23')");

            migrationBuilder.Sql("INSERT INTO Products(Id, Name, Description, ImageUrl, Price, Stock, DateCreated, CategoryId)" +
                     "VALUES(NEWID(),'Cereal', 'Healthy breakfast option 500g', 'cereal.jpg', 3.5, 30, GETDATE(), '950FFC32-4FD7-472D-B1FA-C42F43430355')");

            migrationBuilder.Sql("INSERT INTO Products(Id, Name, Description, ImageUrl, Price, Stock, DateCreated, CategoryId)" +
                     "VALUES(NEWID(),'Cheeseburger', 'Classic cheeseburger with fries', 'cheeseburger.jpg', 5.99, 20, GETDATE(), '8A2DB8BC-A728-47D8-A4D6-B5154E7430B6')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
