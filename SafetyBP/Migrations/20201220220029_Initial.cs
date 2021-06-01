using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SafetyBP.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModuleChecklists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sector = table.Column<string>(maxLength: 1000, nullable: false),
                    PendingToSynchronize = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleChecklists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OffLineRequest",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(maxLength: 100, nullable: true),
                    Request = table.Column<string>(maxLength: 5000, nullable: true),
                    Url = table.Column<string>(maxLength: 1000, nullable: true),
                    RequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OffLineRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sector = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sector = table.Column<string>(maxLength: 1000, nullable: false),
                    PendingToSynchronize = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModuleChecklistsDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 1000, nullable: false),
                    DueDateTime = table.Column<DateTime>(nullable: false),
                    CheckListId = table.Column<int>(nullable: true),
                    IsPendingToSyncronize = table.Column<bool>(nullable: false),
                    Complete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleChecklistsDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleChecklistsDetails_ModuleChecklists_CheckListId",
                        column: x => x.CheckListId,
                        principalTable: "ModuleChecklists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpontaneousDiversion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Reason = table.Column<string>(maxLength: 2000, nullable: true),
                    SectorId = table.Column<int>(nullable: false),
                    Risk = table.Column<int>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(maxLength: 2000, nullable: true),
                    Synchronized = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpontaneousDiversion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpontaneousDiversion_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SafetyTaskAdditionalData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskId = table.Column<int>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyTaskAdditionalData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SafetyTaskAdditionalData_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(maxLength: 200, nullable: true),
                    Name = table.Column<string>(maxLength: 1000, nullable: true),
                    Comments = table.Column<string>(maxLength: 2048, nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    Priority = table.Column<byte>(nullable: false),
                    IsComplete = table.Column<bool>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Files = table.Column<string>(nullable: true),
                    TaskId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskDetails_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModuleChecklistsQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<int>(nullable: false),
                    RelatedId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    IsAlert = table.Column<bool>(nullable: false),
                    PhotoRequired = table.Column<bool>(nullable: false),
                    IsCritica = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IsPendingToSyncronize = table.Column<bool>(nullable: false),
                    DoesNotApply = table.Column<bool>(nullable: false),
                    CheckListId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleChecklistsQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleChecklistsQuestions_ModuleChecklistsDetails_CheckListId",
                        column: x => x.CheckListId,
                        principalTable: "ModuleChecklistsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskDetailsCheckList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Status = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 1000, nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    IsPendingToSync = table.Column<bool>(nullable: false),
                    TaskDetailId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDetailsCheckList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskDetailsCheckList_TaskDetails_TaskDetailId",
                        column: x => x.TaskDetailId,
                        principalTable: "TaskDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModuleChecklistsQuestionsNegativeValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuestionId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    ValueType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleChecklistsQuestionsNegativeValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleChecklistsQuestionsNegativeValues_ModuleChecklistsQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "ModuleChecklistsQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModuleChecklistsDetails_CheckListId",
                table: "ModuleChecklistsDetails",
                column: "CheckListId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleChecklistsQuestions_CheckListId",
                table: "ModuleChecklistsQuestions",
                column: "CheckListId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleChecklistsQuestionsNegativeValues_QuestionId",
                table: "ModuleChecklistsQuestionsNegativeValues",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyTaskAdditionalData_TaskId",
                table: "SafetyTaskAdditionalData",
                column: "TaskId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpontaneousDiversion_SectorId",
                table: "SpontaneousDiversion",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDetails_TaskId",
                table: "TaskDetails",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDetailsCheckList_TaskDetailId",
                table: "TaskDetailsCheckList",
                column: "TaskDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleChecklistsQuestionsNegativeValues");

            migrationBuilder.DropTable(
                name: "OffLineRequest");

            migrationBuilder.DropTable(
                name: "SafetyTaskAdditionalData");

            migrationBuilder.DropTable(
                name: "SpontaneousDiversion");

            migrationBuilder.DropTable(
                name: "TaskDetailsCheckList");

            migrationBuilder.DropTable(
                name: "ModuleChecklistsQuestions");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "TaskDetails");

            migrationBuilder.DropTable(
                name: "ModuleChecklistsDetails");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "ModuleChecklists");
        }
    }
}
