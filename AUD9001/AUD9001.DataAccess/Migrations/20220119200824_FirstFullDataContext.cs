using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AUD9001.DataAccess.Migrations
{
    public partial class FirstFullDataContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcceptanceCriteria_Target_TargetId",
                table: "AcceptanceCriteria");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_ProcessRequirement_ProcessRequirementId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Processes_Company_CompanyId",
                table: "Processes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessRequirement_Processes_ProcessId",
                table: "ProcessRequirement");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_ResourceType_TypeId",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Target_Processes_ProcessId",
                table: "Target");

            migrationBuilder.DropTable(
                name: "InputProcess");

            migrationBuilder.DropTable(
                name: "OutputProcess");

            migrationBuilder.DropTable(
                name: "ProcessResource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Target",
                table: "Target");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceType",
                table: "ResourceType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessRequirement",
                table: "ProcessRequirement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Output",
                table: "Output");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Input",
                table: "Input");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachment",
                table: "Attachment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AcceptanceCriteria",
                table: "AcceptanceCriteria");

            migrationBuilder.DropColumn(
                name: "ProcessDeputyLiderId",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "ProcessLiderId",
                table: "Processes");

            migrationBuilder.RenameTable(
                name: "Target",
                newName: "Targets");

            migrationBuilder.RenameTable(
                name: "ResourceType",
                newName: "ResourceTypes");

            migrationBuilder.RenameTable(
                name: "ProcessRequirement",
                newName: "ProcessRequirements");

            migrationBuilder.RenameTable(
                name: "Output",
                newName: "Outputs");

            migrationBuilder.RenameTable(
                name: "Input",
                newName: "Inputs");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.RenameTable(
                name: "Attachment",
                newName: "Attachments");

            migrationBuilder.RenameTable(
                name: "AcceptanceCriteria",
                newName: "AcceptanceCriterias");

            migrationBuilder.RenameIndex(
                name: "IX_Target_ProcessId",
                table: "Targets",
                newName: "IX_Targets_ProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcessRequirement_ProcessId",
                table: "ProcessRequirements",
                newName: "IX_ProcessRequirements_ProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachment_ProcessRequirementId",
                table: "Attachments",
                newName: "IX_Attachments_ProcessRequirementId");

            migrationBuilder.RenameIndex(
                name: "IX_AcceptanceCriteria_TargetId",
                table: "AcceptanceCriterias",
                newName: "IX_AcceptanceCriterias_TargetId");

            migrationBuilder.AddColumn<int>(
                name: "ProcessId",
                table: "Resources",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Processes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessId",
                table: "Outputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessId",
                table: "Inputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Targets",
                table: "Targets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceTypes",
                table: "ResourceTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessRequirements",
                table: "ProcessRequirements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Outputs",
                table: "Outputs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inputs",
                table: "Inputs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attachments",
                table: "Attachments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AcceptanceCriterias",
                table: "AcceptanceCriterias",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AuditTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InterestedPeople",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestedPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterestedPeople_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManagementReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagementReviews_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StrategicPositionAnalyses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecordNumber = table.Column<int>(type: "int", nullable: false),
                    SummaryS = table.Column<int>(type: "int", nullable: false),
                    SummaryW = table.Column<int>(type: "int", nullable: false),
                    SummaryO = table.Column<int>(type: "int", nullable: false),
                    SummaryT = table.Column<int>(type: "int", nullable: false),
                    AR = table.Column<int>(type: "int", nullable: false),
                    PR = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrategicPositionAnalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrategicPositionAnalyses_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditNumber = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AuditTypeId = table.Column<int>(type: "int", nullable: false),
                    ParentAuditId = table.Column<int>(type: "int", nullable: true),
                    ProcessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Audits_Audits_ParentAuditId",
                        column: x => x.ParentAuditId,
                        principalTable: "Audits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audits_AuditTypes_AuditTypeId",
                        column: x => x.AuditTypeId,
                        principalTable: "AuditTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Audits_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expectations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterestedPersonId = table.Column<int>(type: "int", nullable: true),
                    AttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expectations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expectations_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expectations_InterestedPeople_InterestedPersonId",
                        column: x => x.InterestedPersonId,
                        principalTable: "InterestedPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterestedPersonId = table.Column<int>(type: "int", nullable: true),
                    AttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requirements_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requirements_InterestedPeople_InterestedPersonId",
                        column: x => x.InterestedPersonId,
                        principalTable: "InterestedPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermissionRole",
                columns: table => new
                {
                    PermissionsId = table.Column<int>(type: "int", nullable: false),
                    RolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRole", x => new { x.PermissionsId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_PermissionRole_Permissions_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionRole_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    ProcessId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Factors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Importance = table.Column<int>(type: "int", nullable: false),
                    Positive = table.Column<bool>(type: "bit", nullable: false),
                    Internal = table.Column<bool>(type: "bit", nullable: false),
                    StrategicPositionAnalysisId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factors_StrategicPositionAnalyses_StrategicPositionAnalysisId",
                        column: x => x.StrategicPositionAnalysisId,
                        principalTable: "StrategicPositionAnalyses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attensions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpottedPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attensions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attensions_Audits_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inconsistencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpottedPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inconsistencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inconsistencies_Audits_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Observations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpottedPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Observations_Audits_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserCreatedId = table.Column<int>(type: "int", nullable: true),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    AttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocVersions_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocVersions_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocVersions_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecommendedActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecommendingPersonId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    AttensionId = table.Column<int>(type: "int", nullable: true),
                    InconsistencyId = table.Column<int>(type: "int", nullable: true),
                    ObservationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendedActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecommendedActions_Attensions_AttensionId",
                        column: x => x.AttensionId,
                        principalTable: "Attensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecommendedActions_Inconsistencies_InconsistencyId",
                        column: x => x.InconsistencyId,
                        principalTable: "Inconsistencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecommendedActions_Observations_ObservationId",
                        column: x => x.ObservationId,
                        principalTable: "Observations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsiblePersonId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    RecommendedActionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actions_RecommendedActions_RecommendedActionId",
                        column: x => x.RecommendedActionId,
                        principalTable: "RecommendedActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ProcessId",
                table: "Resources",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Outputs_ProcessId",
                table: "Outputs",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Inputs_ProcessId",
                table: "Inputs",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_RecommendedActionId",
                table: "Actions",
                column: "RecommendedActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Attensions_AuditId",
                table: "Attensions",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_Audits_AuditTypeId",
                table: "Audits",
                column: "AuditTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Audits_ParentAuditId",
                table: "Audits",
                column: "ParentAuditId");

            migrationBuilder.CreateIndex(
                name: "IX_Audits_ProcessId",
                table: "Audits",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ProcessId",
                table: "Documents",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_DocVersions_AttachmentId",
                table: "DocVersions",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocVersions_DocumentId",
                table: "DocVersions",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocVersions_UserCreatedId",
                table: "DocVersions",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Expectations_AttachmentId",
                table: "Expectations",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Expectations_InterestedPersonId",
                table: "Expectations",
                column: "InterestedPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Factors_StrategicPositionAnalysisId",
                table: "Factors",
                column: "StrategicPositionAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_Inconsistencies_AuditId",
                table: "Inconsistencies",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestedPeople_ProcessId",
                table: "InterestedPeople",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementReviews_CompanyId",
                table: "ManagementReviews",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_AuditId",
                table: "Observations",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRole_RolesId",
                table: "PermissionRole",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendedActions_AttensionId",
                table: "RecommendedActions",
                column: "AttensionId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendedActions_InconsistencyId",
                table: "RecommendedActions",
                column: "InconsistencyId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendedActions_ObservationId",
                table: "RecommendedActions",
                column: "ObservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_AttachmentId",
                table: "Requirements",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_InterestedPersonId",
                table: "Requirements",
                column: "InterestedPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_StrategicPositionAnalyses_ProcessId",
                table: "StrategicPositionAnalyses",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProcessId",
                table: "Users",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcceptanceCriterias_Targets_TargetId",
                table: "AcceptanceCriterias",
                column: "TargetId",
                principalTable: "Targets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_ProcessRequirements_ProcessRequirementId",
                table: "Attachments",
                column: "ProcessRequirementId",
                principalTable: "ProcessRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inputs_Processes_ProcessId",
                table: "Inputs",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Outputs_Processes_ProcessId",
                table: "Outputs",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_Companies_CompanyId",
                table: "Processes",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessRequirements_Processes_ProcessId",
                table: "ProcessRequirements",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Processes_ProcessId",
                table: "Resources",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_ResourceTypes_TypeId",
                table: "Resources",
                column: "TypeId",
                principalTable: "ResourceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Targets_Processes_ProcessId",
                table: "Targets",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcceptanceCriterias_Targets_TargetId",
                table: "AcceptanceCriterias");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_ProcessRequirements_ProcessRequirementId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Inputs_Processes_ProcessId",
                table: "Inputs");

            migrationBuilder.DropForeignKey(
                name: "FK_Outputs_Processes_ProcessId",
                table: "Outputs");

            migrationBuilder.DropForeignKey(
                name: "FK_Processes_Companies_CompanyId",
                table: "Processes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessRequirements_Processes_ProcessId",
                table: "ProcessRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Processes_ProcessId",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_ResourceTypes_TypeId",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Targets_Processes_ProcessId",
                table: "Targets");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "DocVersions");

            migrationBuilder.DropTable(
                name: "Expectations");

            migrationBuilder.DropTable(
                name: "Factors");

            migrationBuilder.DropTable(
                name: "ManagementReviews");

            migrationBuilder.DropTable(
                name: "PermissionRole");

            migrationBuilder.DropTable(
                name: "Requirements");

            migrationBuilder.DropTable(
                name: "RecommendedActions");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "StrategicPositionAnalyses");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "InterestedPeople");

            migrationBuilder.DropTable(
                name: "Attensions");

            migrationBuilder.DropTable(
                name: "Inconsistencies");

            migrationBuilder.DropTable(
                name: "Observations");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "AuditTypes");

            migrationBuilder.DropIndex(
                name: "IX_Resources_ProcessId",
                table: "Resources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Targets",
                table: "Targets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceTypes",
                table: "ResourceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessRequirements",
                table: "ProcessRequirements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Outputs",
                table: "Outputs");

            migrationBuilder.DropIndex(
                name: "IX_Outputs_ProcessId",
                table: "Outputs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inputs",
                table: "Inputs");

            migrationBuilder.DropIndex(
                name: "IX_Inputs_ProcessId",
                table: "Inputs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachments",
                table: "Attachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AcceptanceCriterias",
                table: "AcceptanceCriterias");

            migrationBuilder.DropColumn(
                name: "ProcessId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "ProcessId",
                table: "Outputs");

            migrationBuilder.DropColumn(
                name: "ProcessId",
                table: "Inputs");

            migrationBuilder.RenameTable(
                name: "Targets",
                newName: "Target");

            migrationBuilder.RenameTable(
                name: "ResourceTypes",
                newName: "ResourceType");

            migrationBuilder.RenameTable(
                name: "ProcessRequirements",
                newName: "ProcessRequirement");

            migrationBuilder.RenameTable(
                name: "Outputs",
                newName: "Output");

            migrationBuilder.RenameTable(
                name: "Inputs",
                newName: "Input");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.RenameTable(
                name: "Attachments",
                newName: "Attachment");

            migrationBuilder.RenameTable(
                name: "AcceptanceCriterias",
                newName: "AcceptanceCriteria");

            migrationBuilder.RenameIndex(
                name: "IX_Targets_ProcessId",
                table: "Target",
                newName: "IX_Target_ProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcessRequirements_ProcessId",
                table: "ProcessRequirement",
                newName: "IX_ProcessRequirement_ProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_ProcessRequirementId",
                table: "Attachment",
                newName: "IX_Attachment_ProcessRequirementId");

            migrationBuilder.RenameIndex(
                name: "IX_AcceptanceCriterias_TargetId",
                table: "AcceptanceCriteria",
                newName: "IX_AcceptanceCriteria_TargetId");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Processes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ProcessDeputyLiderId",
                table: "Processes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcessLiderId",
                table: "Processes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Target",
                table: "Target",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceType",
                table: "ResourceType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessRequirement",
                table: "ProcessRequirement",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Output",
                table: "Output",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Input",
                table: "Input",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attachment",
                table: "Attachment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AcceptanceCriteria",
                table: "AcceptanceCriteria",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "InputProcess",
                columns: table => new
                {
                    InputsId = table.Column<int>(type: "int", nullable: false),
                    ProcessesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputProcess", x => new { x.InputsId, x.ProcessesId });
                    table.ForeignKey(
                        name: "FK_InputProcess_Input_InputsId",
                        column: x => x.InputsId,
                        principalTable: "Input",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputProcess_Processes_ProcessesId",
                        column: x => x.ProcessesId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutputProcess",
                columns: table => new
                {
                    OutputsId = table.Column<int>(type: "int", nullable: false),
                    ProcessesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputProcess", x => new { x.OutputsId, x.ProcessesId });
                    table.ForeignKey(
                        name: "FK_OutputProcess_Output_OutputsId",
                        column: x => x.OutputsId,
                        principalTable: "Output",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutputProcess_Processes_ProcessesId",
                        column: x => x.ProcessesId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessResource",
                columns: table => new
                {
                    ProcessesId = table.Column<int>(type: "int", nullable: false),
                    ResourcesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessResource", x => new { x.ProcessesId, x.ResourcesId });
                    table.ForeignKey(
                        name: "FK_ProcessResource_Processes_ProcessesId",
                        column: x => x.ProcessesId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessResource_Resources_ResourcesId",
                        column: x => x.ResourcesId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InputProcess_ProcessesId",
                table: "InputProcess",
                column: "ProcessesId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputProcess_ProcessesId",
                table: "OutputProcess",
                column: "ProcessesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessResource_ResourcesId",
                table: "ProcessResource",
                column: "ResourcesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcceptanceCriteria_Target_TargetId",
                table: "AcceptanceCriteria",
                column: "TargetId",
                principalTable: "Target",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_ProcessRequirement_ProcessRequirementId",
                table: "Attachment",
                column: "ProcessRequirementId",
                principalTable: "ProcessRequirement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_Company_CompanyId",
                table: "Processes",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessRequirement_Processes_ProcessId",
                table: "ProcessRequirement",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_ResourceType_TypeId",
                table: "Resources",
                column: "TypeId",
                principalTable: "ResourceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Target_Processes_ProcessId",
                table: "Target",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
