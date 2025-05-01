using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Taskname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Assigned_Userid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_Assigned_Userid",
                        column: x => x.Assigned_Userid,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskComments",
                columns: table => new
                {
                    TaskCommentid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    task_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskComments", x => x.TaskCommentid);
                    table.ForeignKey(
                        name: "FK_TaskComments_Tasks_task_id",
                        column: x => x.task_id,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskComments_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Alice" },
                    { 2, "Bob" },
                    { 3, "Charlie" },
                    { 4, "Diana" },
                    { 5, "Ethan" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "Assigned_Userid", "Taskname" },
                values: new object[,]
                {
                    { 1, 1, "Build API" },
                    { 2, 2, "Write Tests" },
                    { 3, 3, "Fix Bugs" },
                    { 4, 4, "Deploy to Server" },
                    { 5, 5, "Code Review" }
                });

            migrationBuilder.InsertData(
                table: "TaskComments",
                columns: new[] { "TaskCommentid", "Comments", "task_id", "user_id" },
                values: new object[,]
                {
                    { 1, "Initial setup done", 1, 1 },
                    { 2, "Test cases added", 2, 2 },
                    { 3, "Fixed issue #123", 3, 2 },
                    { 4, "Deployed successfully", 4, 4 },
                    { 5, "Reviewed and approved", 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskComments_task_id",
                table: "TaskComments",
                column: "task_id");

            migrationBuilder.CreateIndex(
                name: "IX_TaskComments_user_id",
                table: "TaskComments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_Assigned_Userid",
                table: "Tasks",
                column: "Assigned_Userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskComments");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
