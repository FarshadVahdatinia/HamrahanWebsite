using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HamrahanTemplate.persistence.Migrations
{
    public partial class AddingpurchaseLogicorderorderdetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_LessonCode",
                schema: "Education",
                table: "Course");

            migrationBuilder.DropTable(
                name: "Lesson",
                schema: "Education");

            migrationBuilder.DropTable(
                name: "Student_course",
                schema: "Education");

            migrationBuilder.RenameColumn(
                name: "LessonCode",
                schema: "Education",
                table: "Course",
                newName: "CourseGroupCode");

            migrationBuilder.RenameColumn(
                name: "Fee",
                schema: "Education",
                table: "Course",
                newName: "CoursePrice");

            migrationBuilder.RenameIndex(
                name: "IX_Course_LessonCode",
                schema: "Education",
                table: "Course",
                newName: "IX_Course_CourseGroupCode");

            migrationBuilder.AddColumn<string>(
                name: "CourseDescription",
                schema: "Education",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseImageName",
                schema: "Education",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "Education",
                table: "Course",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Education",
                table: "Course",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Keyword",
                schema: "Education",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                schema: "Education",
                table: "Course",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseEpisode",
                schema: "Education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    EpisodeTitle = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    EpisodeTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EpisodeFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFree = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEpisode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseEpisode_Course",
                        column: x => x.CourseId,
                        principalSchema: "Education",
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseGroup",
                schema: "Education",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false),
                    EducationGradeCode = table.Column<byte>(type: "tinyint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseGroup", x => x.Code);
                    table.ForeignKey(
                        name: "FK_CourseGroup_EducationGradeCode",
                        column: x => x.EducationGradeCode,
                        principalSchema: "Education",
                        principalTable: "EducationGrade",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseKeyword",
                columns: table => new
                {
                    CoursesID = table.Column<long>(type: "bigint", nullable: false),
                    KeywordsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseKeyword", x => new { x.CoursesID, x.KeywordsID });
                    table.ForeignKey(
                        name: "FK_CourseKeyword_Course_CoursesID",
                        column: x => x.CoursesID,
                        principalSchema: "Education",
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseKeyword_Keyword_KeywordsID",
                        column: x => x.KeywordsID,
                        principalSchema: "Weblog",
                        principalTable: "Keyword",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderSum = table.Column<int>(type: "int", nullable: false),
                    IsFinaly = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_course",
                schema: "Education",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CourseID = table.Column<long>(type: "bigint", nullable: false),
                    IsRegistered = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_course", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Student_c__Stude__5070F446",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCourse_Course",
                        column: x => x.CourseID,
                        principalSchema: "Education",
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Education",
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseEpisode_CourseId",
                schema: "Education",
                table: "CourseEpisode",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseGroup_EducationGradeCode",
                schema: "Education",
                table: "CourseGroup",
                column: "EducationGradeCode");

            migrationBuilder.CreateIndex(
                name: "IX_CourseKeyword_KeywordsID",
                table: "CourseKeyword",
                column: "KeywordsID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CourseId",
                table: "OrderDetails",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_course_CourseID",
                schema: "Education",
                table: "User_course",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_User_course_UserID",
                schema: "Education",
                table: "User_course",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_CourseGroupCode",
                schema: "Education",
                table: "Course",
                column: "CourseGroupCode",
                principalSchema: "Education",
                principalTable: "CourseGroup",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_CourseGroupCode",
                schema: "Education",
                table: "Course");

            migrationBuilder.DropTable(
                name: "CourseEpisode",
                schema: "Education");

            migrationBuilder.DropTable(
                name: "CourseGroup",
                schema: "Education");

            migrationBuilder.DropTable(
                name: "CourseKeyword");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "User_course",
                schema: "Education");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropColumn(
                name: "CourseDescription",
                schema: "Education",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CourseImageName",
                schema: "Education",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "Education",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Education",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Keyword",
                schema: "Education",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                schema: "Education",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "CoursePrice",
                schema: "Education",
                table: "Course",
                newName: "Fee");

            migrationBuilder.RenameColumn(
                name: "CourseGroupCode",
                schema: "Education",
                table: "Course",
                newName: "LessonCode");

            migrationBuilder.RenameIndex(
                name: "IX_Course_CourseGroupCode",
                schema: "Education",
                table: "Course",
                newName: "IX_Course_LessonCode");

            migrationBuilder.CreateTable(
                name: "Lesson",
                schema: "Education",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false),
                    EducationGradeCode = table.Column<byte>(type: "tinyint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Lesson_EducationGradeCode",
                        column: x => x.EducationGradeCode,
                        principalSchema: "Education",
                        principalTable: "EducationGrade",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student_course",
                schema: "Education",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<long>(type: "bigint", nullable: false),
                    IsRegistered = table.Column<bool>(type: "bit", nullable: true),
                    StudentID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_course", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Student_c__Stude__5070F446",
                        column: x => x.StudentID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_course_Course",
                        column: x => x.CourseID,
                        principalSchema: "Education",
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_EducationGradeCode",
                schema: "Education",
                table: "Lesson",
                column: "EducationGradeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Student_course_CourseID",
                schema: "Education",
                table: "Student_course",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_course_StudentID",
                schema: "Education",
                table: "Student_course",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_LessonCode",
                schema: "Education",
                table: "Course",
                column: "LessonCode",
                principalSchema: "Education",
                principalTable: "Lesson",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
