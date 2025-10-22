using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonRegister.Migrations
{
    /// <inheritdoc />
    public partial class CreateJobInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobDataJobId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JobInfo",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthlySalary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobInfo", x => x.JobId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_JobDataJobId",
                table: "Person",
                column: "JobDataJobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_JobInfo_JobDataJobId",
                table: "Person",
                column: "JobDataJobId",
                principalTable: "JobInfo",
                principalColumn: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_JobInfo_JobDataJobId",
                table: "Person");

            migrationBuilder.DropTable(
                name: "JobInfo");

            migrationBuilder.DropIndex(
                name: "IX_Person_JobDataJobId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "JobDataJobId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Person");
        }
    }
}
