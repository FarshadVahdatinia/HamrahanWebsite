using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HamrahanTemplate.persistence.Migrations
{
    public partial class initcommentcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_CourseGroupCode",
                schema: "Education",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseKeyword_Course_CoursesID",
                table: "CourseKeyword");

            migrationBuilder.DropTable(
                name: "CourseGroup",
                schema: "Education");

            migrationBuilder.DropTable(
                name: "PostKeyword",
                schema: "Weblog");

            migrationBuilder.DropIndex(
                name: "IX_Course_CourseGroupCode",
                schema: "Education",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CourseGroupCode",
                schema: "Education",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CoursePrice",
                schema: "Education",
                table: "Course");

            migrationBuilder.EnsureSchema(
                name: "Course");

            migrationBuilder.RenameColumn(
                name: "CoursesID",
                table: "CourseKeyword",
                newName: "CoursesId");

            migrationBuilder.AlterColumn<string>(
                name: "Topic",
                schema: "Weblog",
                table: "Post",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValueSql: "(N'')",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Weblog",
                table: "Post",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Education",
                table: "Course",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValueSql: "(N'')",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "TimeInWeek",
                schema: "Education",
                table: "Course",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValueSql: "(N'')",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Education",
                table: "Course",
                type: "bit",
                nullable: true,
                defaultValueSql: "(CONVERT([bit],(0)))",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Education",
                table: "Course",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CourseImageName",
                schema: "Education",
                table: "Course",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourseDescription",
                schema: "Education",
                table: "Course",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "ClassCode",
                schema: "Education",
                table: "Course",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                schema: "Education",
                table: "Course",
                type: "int",
                nullable: true,
                defaultValueSql: "((0))");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SubCategory = table.Column<int>(type: "int", nullable: true),
                    EducationGradeCode = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_SubCategory",
                        column: x => x.SubCategory,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_EducationGrade_EducationGradeCode",
                        column: x => x.EducationGradeCode,
                        principalSchema: "Education",
                        principalTable: "EducationGrade",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                schema: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Like = table.Column<int>(type: "int", nullable: false),
                    DisLike = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CourseId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Comment",
                        column: x => x.CourseId,
                        principalSchema: "Education",
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Comment",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoursePrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    specialPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPercentage = table.Column<int>(type: "int", nullable: false),
                    SoldOutCount = table.Column<int>(type: "int", nullable: false),
                    DiscountStartingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountEndingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursePrice_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Education",
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KeywordPost",
                schema: "Weblog",
                columns: table => new
                {
                    KeywordsID = table.Column<int>(type: "int", nullable: false),
                    PostsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeywordPost", x => new { x.KeywordsID, x.PostsId });
                    table.ForeignKey(
                        name: "FK_KeywordPost_Keyword_KeywordsID",
                        column: x => x.KeywordsID,
                        principalSchema: "Weblog",
                        principalTable: "Keyword",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeywordPost_Post_PostsId",
                        column: x => x.PostsId,
                        principalSchema: "Weblog",
                        principalTable: "Post",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_CategoryId",
                schema: "Education",
                table: "Course",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_EducationGradeCode",
                table: "Category",
                column: "EducationGradeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Category_SubCategory",
                table: "Category",
                column: "SubCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CourseId",
                schema: "Course",
                table: "Comment",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                schema: "Course",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePrice_CourseId",
                table: "CoursePrice",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_KeywordPost_PostsId",
                schema: "Weblog",
                table: "KeywordPost",
                column: "PostsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_CategoryId",
                schema: "Education",
                table: "Course",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseKeyword_Course_CoursesId",
                table: "CourseKeyword",
                column: "CoursesId",
                principalSchema: "Education",
                principalTable: "Course",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_CategoryId",
                schema: "Education",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseKeyword_Course_CoursesId",
                table: "CourseKeyword");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Comment",
                schema: "Course");

            migrationBuilder.DropTable(
                name: "CoursePrice");

            migrationBuilder.DropTable(
                name: "KeywordPost",
                schema: "Weblog");

            migrationBuilder.DropIndex(
                name: "IX_Course_CategoryId",
                schema: "Education",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "Education",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "CoursesId",
                table: "CourseKeyword",
                newName: "CoursesID");

            migrationBuilder.AlterColumn<string>(
                name: "Topic",
                schema: "Weblog",
                table: "Post",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldDefaultValueSql: "(N'')");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Weblog",
                table: "Post",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Education",
                table: "Course",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldDefaultValueSql: "(N'')");

            migrationBuilder.AlterColumn<string>(
                name: "TimeInWeek",
                schema: "Education",
                table: "Course",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldDefaultValueSql: "(N'')");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Education",
                table: "Course",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "(CONVERT([bit],(0)))");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Education",
                table: "Course",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<string>(
                name: "CourseImageName",
                schema: "Education",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourseDescription",
                schema: "Education",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "ClassCode",
                schema: "Education",
                table: "Course",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseGroupCode",
                schema: "Education",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "CoursePrice",
                schema: "Education",
                table: "Course",
                type: "decimal(15,2)",
                nullable: false,
                defaultValue: 0m);

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
                name: "PostKeyword",
                schema: "Weblog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeywordID = table.Column<int>(type: "int", nullable: false),
                    PostID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostKeyword", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Post_Keyword_KeywordID",
                        column: x => x.KeywordID,
                        principalSchema: "Weblog",
                        principalTable: "Keyword",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Keyword_PostID",
                        column: x => x.PostID,
                        principalSchema: "Weblog",
                        principalTable: "Post",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseGroupCode",
                schema: "Education",
                table: "Course",
                column: "CourseGroupCode");

            migrationBuilder.CreateIndex(
                name: "IX_CourseGroup_EducationGradeCode",
                schema: "Education",
                table: "CourseGroup",
                column: "EducationGradeCode");

            migrationBuilder.CreateIndex(
                name: "IX_PostKeyword_KeywordID",
                schema: "Weblog",
                table: "PostKeyword",
                column: "KeywordID");

            migrationBuilder.CreateIndex(
                name: "IX_PostKeyword_PostID",
                schema: "Weblog",
                table: "PostKeyword",
                column: "PostID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_CourseGroupCode",
                schema: "Education",
                table: "Course",
                column: "CourseGroupCode",
                principalSchema: "Education",
                principalTable: "CourseGroup",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseKeyword_Course_CoursesID",
                table: "CourseKeyword",
                column: "CoursesID",
                principalSchema: "Education",
                principalTable: "Course",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
