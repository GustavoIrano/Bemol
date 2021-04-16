using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bemol.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bemol");

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "bemol",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "varchar(200)", nullable: false),
                    Complement = table.Column<string>(type: "varchar(150)", nullable: true),
                    Cep = table.Column<string>(type: "varchar(9)", nullable: false),
                    City = table.Column<string>(type: "varchar(150)", nullable: false),
                    State = table.Column<string>(type: "varchar(2)", nullable: false),
                    Neighborhood = table.Column<string>(type: "varchar(150)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "bemol",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    Email = table.Column<string>(type: "varchar(250)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(12)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(14)", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "bemol",
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                schema: "bemol",
                table: "Customers",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers",
                schema: "bemol");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "bemol");
        }
    }
}
