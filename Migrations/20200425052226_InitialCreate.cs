using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHomework.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    DepId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.DepId);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    EmpId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    WorkStart = table.Column<string>(nullable: true),
                    Job = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    DepId = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Passward = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_employee_department_DepId",
                        column: x => x.DepId,
                        principalTable: "department",
                        principalColumn: "DepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movedep",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EmpId = table.Column<string>(nullable: true),
                    Day = table.Column<string>(nullable: true),
                    DepForm = table.Column<string>(nullable: false),
                    DepTo = table.Column<string>(nullable: false),
                    Reason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movedep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movedep_department_DepForm",
                        column: x => x.DepForm,
                        principalTable: "department",
                        principalColumn: "DepId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movedep_department_DepTo",
                        column: x => x.DepTo,
                        principalTable: "department",
                        principalColumn: "DepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employee_DepId",
                table: "employee",
                column: "DepId");

            migrationBuilder.CreateIndex(
                name: "IX_movedep_DepForm",
                table: "movedep",
                column: "DepForm");

            migrationBuilder.CreateIndex(
                name: "IX_movedep_DepTo",
                table: "movedep",
                column: "DepTo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "movedep");

            migrationBuilder.DropTable(
                name: "department");
        }
    }
}
