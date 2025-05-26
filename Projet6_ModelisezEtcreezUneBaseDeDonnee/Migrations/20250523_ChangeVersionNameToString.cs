using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet6_ModelisezEtcreezUneBaseDeDonnee.Migrations
{
    /// <inheritdoc />
    public partial class ChangeVersionNameToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Supprimer l'index unique temporairement
            migrationBuilder.DropIndex(
                name: "IX_Version_ProductId_VersionName",
                table: "Versions");

            // Changer le type de la colonne VersionName de float à nvarchar(max)
            migrationBuilder.AlterColumn<string>(
                name: "VersionName",
                table: "Versions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            // Recréer l'index unique
            migrationBuilder.CreateIndex(
                name: "IX_Version_ProductId_VersionName",
                table: "Versions",
                columns: new[] { "ProductId", "VersionName" },
                unique: true);

            // Mettre à jour les données existantes pour corriger les valeurs
            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 1,
                column: "VersionName",
                value: "1.0");

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 2,
                column: "VersionName",
                value: "1.1");

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 3,
                column: "VersionName",
                value: "1.2");

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 4,
                column: "VersionName",
                value: "1.3");

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 5,
                column: "VersionName",
                value: "1.0");

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 6,
                column: "VersionName",
                value: "2.0");

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 7,
                column: "VersionName",
                value: "2.1");

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 8,
                column: "VersionName",
                value: "1.0");

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 9,
                column: "VersionName",
                value: "1.1");

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 10,
                column: "VersionName",
                value: "2.0");

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 11,
                column: "VersionName",
                value: "1.0");

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 12,
                column: "VersionName",
                value: "1.1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Supprimer l'index unique temporairement
            migrationBuilder.DropIndex(
                name: "IX_Version_ProductId_VersionName",
                table: "Versions");

            // Revenir au type double
            migrationBuilder.AlterColumn<double>(
                name: "VersionName",
                table: "Versions",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            // Recréer l'index unique
            migrationBuilder.CreateIndex(
                name: "IX_Version_ProductId_VersionName",
                table: "Versions",
                columns: new[] { "ProductId", "VersionName" },
                unique: true);

            // Remettre les anciennes valeurs double
            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 1,
                column: "VersionName",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 2,
                column: "VersionName",
                value: 1.1000000000000001);

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 3,
                column: "VersionName",
                value: 1.2);

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 4,
                column: "VersionName",
                value: 1.3);

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 5,
                column: "VersionName",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 6,
                column: "VersionName",
                value: 2.0);

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 7,
                column: "VersionName",
                value: 2.1000000000000001);

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 8,
                column: "VersionName",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 9,
                column: "VersionName",
                value: 1.1000000000000001);

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 10,
                column: "VersionName",
                value: 2.0);

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 11,
                column: "VersionName",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "Versions",
                keyColumn: "VersionId",
                keyValue: 12,
                column: "VersionName",
                value: 1.1000000000000001);
        }
    }
}
