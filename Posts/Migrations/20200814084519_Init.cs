using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Posts.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Body = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Slug = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogPostsTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<int>(nullable: false),
                    BlogPostsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostsTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPostsId",
                        column: x => x.BlogPostsId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Body", "CreatedAt", "Description", "Slug", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "The app is simple to use, and will help you decide on your best furniture fit.", new DateTime(2020, 8, 14, 10, 45, 19, 5, DateTimeKind.Local).AddTicks(7318), "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.", "augmented-reality-ios-application", "Augmented Reality iOS Application", null },
                    { 2, "An opinionated commentary, of the most important presentation of the year", new DateTime(2020, 8, 14, 10, 45, 19, 18, DateTimeKind.Local).AddTicks(8085), "Ever wonder how?", "internet-trends-2018", "Internet Trends 2018", null }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { 1, "iOS" },
                    { 2, ".NET" },
                    { 3, "AngularJS" },
                    { 4, "Android" }
                });

            migrationBuilder.InsertData(
                table: "BlogPostsTags",
                columns: new[] { "Id", "BlogPostsId", "TagId" },
                values: new object[,]
                {
                    { 3, 2, 1 },
                    { 4, 1, 1 },
                    { 1, 1, 3 },
                    { 2, 2, 3 },
                    { 5, 1, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostsTags_BlogPostsId",
                table: "BlogPostsTags",
                column: "BlogPostsId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostsTags_TagId",
                table: "BlogPostsTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostsTags");

            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
