using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fase_3__Banco_de_dados.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Usuarios", x => x.Id);
                });


                migrationBuilder.InsertData(
                table: "Tb_Usuarios",
                columns: new[] { "UserName", "Password" },
                values: new object[,]
                {
                    { "magalu", "m@galu123" },
                    { "guilherme", "gui@magalu" },
                    { "Lu", "lu@2023" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Usuarios");
        }
    }
}
