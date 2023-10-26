using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class migger1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CODE_EXAMPLES_ST",
                columns: table => new
                {
                    CODEEXAMPLEID = table.Column<int>(name: "CODE_EXAMPLE_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CODE = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CODE_EXAMPLES_ST", x => x.CODEEXAMPLEID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OPERATORS_BT",
                columns: table => new
                {
                    OPERATORID = table.Column<int>(name: "OPERATOR_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SYNTAX = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SHORTDESCRIPTION = table.Column<string>(name: "SHORT_DESCRIPTION", type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "text", maxLength: 10000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERATORS_BT", x => x.OPERATORID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AGGREGATION_OPERATORS_ST",
                columns: table => new
                {
                    OPERATORID = table.Column<int>(name: "OPERATOR_ID", type: "int", nullable: false),
                    TYPE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGGREGATION_OPERATORS_ST", x => x.OPERATORID);
                    table.ForeignKey(
                        name: "FK_AGGREGATION_OPERATORS_ST_OPERATORS_BT_OPERATOR_ID",
                        column: x => x.OPERATORID,
                        principalTable: "OPERATORS_BT",
                        principalColumn: "OPERATOR_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AGGREGATION_STAGES_ST",
                columns: table => new
                {
                    OPERATORID = table.Column<int>(name: "OPERATOR_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGGREGATION_STAGES_ST", x => x.OPERATORID);
                    table.ForeignKey(
                        name: "FK_AGGREGATION_STAGES_ST_OPERATORS_BT_OPERATOR_ID",
                        column: x => x.OPERATORID,
                        principalTable: "OPERATORS_BT",
                        principalColumn: "OPERATOR_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OPERATOR_HAS_CODE_EXAMPLES",
                columns: table => new
                {
                    OPERATORID = table.Column<int>(name: "OPERATOR_ID", type: "int", nullable: false),
                    CODEEXAMPLEID = table.Column<int>(name: "CODE_EXAMPLE_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERATOR_HAS_CODE_EXAMPLES", x => new { x.OPERATORID, x.CODEEXAMPLEID });
                    table.ForeignKey(
                        name: "FK_OPERATOR_HAS_CODE_EXAMPLES_CODE_EXAMPLES_ST_CODE_EXAMPLE_ID",
                        column: x => x.CODEEXAMPLEID,
                        principalTable: "CODE_EXAMPLES_ST",
                        principalColumn: "CODE_EXAMPLE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OPERATOR_HAS_CODE_EXAMPLES_OPERATORS_BT_OPERATOR_ID",
                        column: x => x.OPERATORID,
                        principalTable: "OPERATORS_BT",
                        principalColumn: "OPERATOR_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATOR_HAS_CODE_EXAMPLES_CODE_EXAMPLE_ID",
                table: "OPERATOR_HAS_CODE_EXAMPLES",
                column: "CODE_EXAMPLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATORS_BT_NAME",
                table: "OPERATORS_BT",
                column: "NAME",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AGGREGATION_OPERATORS_ST");

            migrationBuilder.DropTable(
                name: "AGGREGATION_STAGES_ST");

            migrationBuilder.DropTable(
                name: "OPERATOR_HAS_CODE_EXAMPLES");

            migrationBuilder.DropTable(
                name: "CODE_EXAMPLES_ST");

            migrationBuilder.DropTable(
                name: "OPERATORS_BT");
        }
    }
}
