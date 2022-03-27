using Microsoft.EntityFrameworkCore.Migrations;

namespace AUD9001.DataAccess.Migrations
{
    public partial class deleteidinattachment3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocVersions_Attachments_AttachmentIddummy",
                table: "DocVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_Expectations_Attachments_AttachmentIddummy",
                table: "Expectations");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_Attachments_AttachmentIddummy",
                table: "Requirements");

            migrationBuilder.RenameColumn(
                name: "AttachmentIddummy",
                table: "Requirements",
                newName: "AttachmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Requirements_AttachmentIddummy",
                table: "Requirements",
                newName: "IX_Requirements_AttachmentId");

            migrationBuilder.RenameColumn(
                name: "AttachmentIddummy",
                table: "Expectations",
                newName: "AttachmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Expectations_AttachmentIddummy",
                table: "Expectations",
                newName: "IX_Expectations_AttachmentId");

            migrationBuilder.RenameColumn(
                name: "AttachmentIddummy",
                table: "DocVersions",
                newName: "AttachmentId");

            migrationBuilder.RenameIndex(
                name: "IX_DocVersions_AttachmentIddummy",
                table: "DocVersions",
                newName: "IX_DocVersions_AttachmentId");

            migrationBuilder.RenameColumn(
                name: "Iddummy",
                table: "Attachments",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocVersions_Attachments_AttachmentId",
                table: "DocVersions",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expectations_Attachments_AttachmentId",
                table: "Expectations",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requirements_Attachments_AttachmentId",
                table: "Requirements",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocVersions_Attachments_AttachmentId",
                table: "DocVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_Expectations_Attachments_AttachmentId",
                table: "Expectations");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_Attachments_AttachmentId",
                table: "Requirements");

            migrationBuilder.RenameColumn(
                name: "AttachmentId",
                table: "Requirements",
                newName: "AttachmentIddummy");

            migrationBuilder.RenameIndex(
                name: "IX_Requirements_AttachmentId",
                table: "Requirements",
                newName: "IX_Requirements_AttachmentIddummy");

            migrationBuilder.RenameColumn(
                name: "AttachmentId",
                table: "Expectations",
                newName: "AttachmentIddummy");

            migrationBuilder.RenameIndex(
                name: "IX_Expectations_AttachmentId",
                table: "Expectations",
                newName: "IX_Expectations_AttachmentIddummy");

            migrationBuilder.RenameColumn(
                name: "AttachmentId",
                table: "DocVersions",
                newName: "AttachmentIddummy");

            migrationBuilder.RenameIndex(
                name: "IX_DocVersions_AttachmentId",
                table: "DocVersions",
                newName: "IX_DocVersions_AttachmentIddummy");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Attachments",
                newName: "Iddummy");

            migrationBuilder.AddForeignKey(
                name: "FK_DocVersions_Attachments_AttachmentIddummy",
                table: "DocVersions",
                column: "AttachmentIddummy",
                principalTable: "Attachments",
                principalColumn: "Iddummy",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expectations_Attachments_AttachmentIddummy",
                table: "Expectations",
                column: "AttachmentIddummy",
                principalTable: "Attachments",
                principalColumn: "Iddummy",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requirements_Attachments_AttachmentIddummy",
                table: "Requirements",
                column: "AttachmentIddummy",
                principalTable: "Attachments",
                principalColumn: "Iddummy",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
