using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendForDiploma.Api.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Point_Buildings_BuildingId",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_PointRecord_Point_PointId",
                table: "PointRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PointRecord",
                table: "PointRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Point",
                table: "Point");

            migrationBuilder.RenameTable(
                name: "PointRecord",
                newName: "PointRecords");

            migrationBuilder.RenameTable(
                name: "Point",
                newName: "Points");

            migrationBuilder.RenameIndex(
                name: "IX_PointRecord_PointId",
                table: "PointRecords",
                newName: "IX_PointRecords_PointId");

            migrationBuilder.RenameIndex(
                name: "IX_Point_BuildingId",
                table: "Points",
                newName: "IX_Points_BuildingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PointRecords",
                table: "PointRecords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Points",
                table: "Points",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PointRecords_Points_PointId",
                table: "PointRecords",
                column: "PointId",
                principalTable: "Points",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Buildings_BuildingId",
                table: "Points",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointRecords_Points_PointId",
                table: "PointRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Buildings_BuildingId",
                table: "Points");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Points",
                table: "Points");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PointRecords",
                table: "PointRecords");

            migrationBuilder.RenameTable(
                name: "Points",
                newName: "Point");

            migrationBuilder.RenameTable(
                name: "PointRecords",
                newName: "PointRecord");

            migrationBuilder.RenameIndex(
                name: "IX_Points_BuildingId",
                table: "Point",
                newName: "IX_Point_BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_PointRecords_PointId",
                table: "PointRecord",
                newName: "IX_PointRecord_PointId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Point",
                table: "Point",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PointRecord",
                table: "PointRecord",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Buildings_BuildingId",
                table: "Point",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PointRecord_Point_PointId",
                table: "PointRecord",
                column: "PointId",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
