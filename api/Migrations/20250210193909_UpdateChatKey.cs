using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChatKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_User1Id_User2Id",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_User1Id_User2Id",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chats",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "User1Id",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "User2Id",
                table: "Messages",
                newName: "ChatId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Chats",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chats",
                table: "Chats",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_User1Id",
                table: "Chats",
                column: "User1Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ChatId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chats",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_User1Id",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Chats");

            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "Messages",
                newName: "User2Id");

            migrationBuilder.AddColumn<int>(
                name: "User1Id",
                table: "Messages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chats",
                table: "Chats",
                columns: new[] { "User1Id", "User2Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_User1Id_User2Id",
                table: "Messages",
                columns: new[] { "User1Id", "User2Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_User1Id_User2Id",
                table: "Messages",
                columns: new[] { "User1Id", "User2Id" },
                principalTable: "Chats",
                principalColumns: new[] { "User1Id", "User2Id" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
