using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreServices.Api.ShoppingCart.Migrations
{
    /// <inheritdoc />
    public partial class DeletedAditionalFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "CartDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "CartDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
