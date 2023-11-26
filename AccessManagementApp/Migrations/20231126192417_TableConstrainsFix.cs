using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class TableConstrainsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__AccessGro__acces__267ABA7A",
                table: "AccessGroup");

            migrationBuilder.DropForeignKey(
                name: "FK__Specialit__acces__29572725",
                table: "Speciality");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Speciali__3213E83FC4FF255A",
                table: "Speciality");

            migrationBuilder.DropIndex(
                name: "IX_Speciality_accessGroupId",
                table: "Speciality");

            migrationBuilder.DropPrimaryKey(
                name: "PK__AccessGr__3213E83FE5DCC860",
                table: "AccessGroup");

            migrationBuilder.DropIndex(
                name: "IX_AccessGroup_accessId",
                table: "AccessGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Access__3213E83FAE6CDF7F",
                table: "Access");

            migrationBuilder.DropColumn(
                name: "accessGroupId",
                table: "Speciality");

            migrationBuilder.DropColumn(
                name: "accessId",
                table: "AccessGroup");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Speciality",
                table: "Speciality",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccessGroup",
                table: "AccessGroup",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Access",
                table: "Access",
                column: "id");

            migrationBuilder.CreateTable(
                name: "AccessAccessGroup",
                columns: table => new
                {
                    AccessGroupsId = table.Column<int>(type: "int", nullable: false),
                    AccessesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessAccessGroup", x => new { x.AccessGroupsId, x.AccessesId });
                    table.ForeignKey(
                        name: "FK_AccessAccessGroup_AccessGroup_AccessGroupsId",
                        column: x => x.AccessGroupsId,
                        principalTable: "AccessGroup",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessAccessGroup_Access_AccessesId",
                        column: x => x.AccessesId,
                        principalTable: "Access",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessGroupSpeciality",
                columns: table => new
                {
                    AccessGroupsId = table.Column<int>(type: "int", nullable: false),
                    SpecialitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessGroupSpeciality", x => new { x.AccessGroupsId, x.SpecialitiesId });
                    table.ForeignKey(
                        name: "FK_AccessGroupSpeciality_AccessGroup_AccessGroupsId",
                        column: x => x.AccessGroupsId,
                        principalTable: "AccessGroup",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessGroupSpeciality_Speciality_SpecialitiesId",
                        column: x => x.SpecialitiesId,
                        principalTable: "Speciality",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessSpeciality",
                columns: table => new
                {
                    AccessesId = table.Column<int>(type: "int", nullable: false),
                    SpecialitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessSpeciality", x => new { x.AccessesId, x.SpecialitiesId });
                    table.ForeignKey(
                        name: "FK_AccessSpeciality_Access_AccessesId",
                        column: x => x.AccessesId,
                        principalTable: "Access",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessSpeciality_Speciality_SpecialitiesId",
                        column: x => x.SpecialitiesId,
                        principalTable: "Speciality",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessAccessGroup_AccessesId",
                table: "AccessAccessGroup",
                column: "AccessesId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroupSpeciality_SpecialitiesId",
                table: "AccessGroupSpeciality",
                column: "SpecialitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessSpeciality_SpecialitiesId",
                table: "AccessSpeciality",
                column: "SpecialitiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessAccessGroup");

            migrationBuilder.DropTable(
                name: "AccessGroupSpeciality");

            migrationBuilder.DropTable(
                name: "AccessSpeciality");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Speciality",
                table: "Speciality");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccessGroup",
                table: "AccessGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Access",
                table: "Access");

            migrationBuilder.AddColumn<int>(
                name: "accessGroupId",
                table: "Speciality",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "accessId",
                table: "AccessGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Speciali__3213E83FC4FF255A",
                table: "Speciality",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__AccessGr__3213E83FE5DCC860",
                table: "AccessGroup",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Access__3213E83FAE6CDF7F",
                table: "Access",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Speciality_accessGroupId",
                table: "Speciality",
                column: "accessGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroup_accessId",
                table: "AccessGroup",
                column: "accessId");

            migrationBuilder.AddForeignKey(
                name: "FK__AccessGro__acces__267ABA7A",
                table: "AccessGroup",
                column: "accessId",
                principalTable: "Access",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Specialit__acces__29572725",
                table: "Speciality",
                column: "accessGroupId",
                principalTable: "AccessGroup",
                principalColumn: "id");
        }
    }
}
