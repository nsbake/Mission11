using Microsoft.EntityFrameworkCore.Migrations;

namespace Amazon.Migrations
{
    public partial class Checkout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    CheckoutID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    AdressLine1 = table.Column<string>(nullable: false),
                    AdressLine2 = table.Column<string>(nullable: true),
                    AdressLine3 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Zip = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.CheckoutID);
                });

            migrationBuilder.CreateTable(
                name: "LineItem",
                columns: table => new
                {
                    LineID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    CheckoutID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItem", x => x.LineID);
                    table.ForeignKey(
                        name: "FK_LineItem_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LineItem_Checkouts_CheckoutID",
                        column: x => x.CheckoutID,
                        principalTable: "Checkouts",
                        principalColumn: "CheckoutID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_BookId",
                table: "LineItem",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_CheckoutID",
                table: "LineItem",
                column: "CheckoutID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineItem");

            migrationBuilder.DropTable(
                name: "Checkouts");
        }
    }
}
