using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Access",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Access__3213E83FAE6CDF7F", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AccessGroup",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AccessGr__3213E83FE5DCC860", x => x.id);
                    table.ForeignKey(
                        name: "FK__AccessGro__acces__267ABA7A",
                        column: x => x.accessId,
                        principalTable: "Access",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Speciality",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accessGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Speciali__3213E83FC4FF255A", x => x.id);
                    table.ForeignKey(
                        name: "FK__Specialit__acces__29572725",
                        column: x => x.accessGroupId,
                        principalTable: "AccessGroup",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroup_accessId",
                table: "AccessGroup",
                column: "accessId");

            migrationBuilder.CreateIndex(
                name: "IX_Speciality_accessGroupId",
                table: "Speciality",
                column: "accessGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speciality");

            migrationBuilder.DropTable(
                name: "AccessGroup");

            migrationBuilder.DropTable(
                name: "Access");
        }
    }
}
