using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NhanVatGame.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenClass = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KyNangs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenKyNang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManaCanDung = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KyNangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDungs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenNguoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDT = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDungs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VuKhis",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenVuKhi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuocTinhVuKhi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VuKhis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanVats",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenNhanVat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HP = table.Column<int>(type: "int", nullable: true),
                    Mana = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: true),
                    NguoiDungID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClassID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VuKhiID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanVats_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NhanVats_NguoiDungs_NguoiDungID",
                        column: x => x.NguoiDungID,
                        principalTable: "NguoiDungs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NhanVats_VuKhis_VuKhiID",
                        column: x => x.VuKhiID,
                        principalTable: "VuKhis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KyNangNhanVats",
                columns: table => new
                {
                    NhanVatID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KyNangID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KyNangNhanVats", x => new { x.NhanVatID, x.KyNangID });
                    table.ForeignKey(
                        name: "FK_KyNangNhanVats_KyNangs_KyNangID",
                        column: x => x.KyNangID,
                        principalTable: "KyNangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KyNangNhanVats_NhanVats_NhanVatID",
                        column: x => x.NhanVatID,
                        principalTable: "NhanVats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KyNangNhanVats_KyNangID",
                table: "KyNangNhanVats",
                column: "KyNangID");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVats_ClassID",
                table: "NhanVats",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVats_NguoiDungID",
                table: "NhanVats",
                column: "NguoiDungID");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVats_VuKhiID",
                table: "NhanVats",
                column: "VuKhiID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KyNangNhanVats");

            migrationBuilder.DropTable(
                name: "KyNangs");

            migrationBuilder.DropTable(
                name: "NhanVats");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "NguoiDungs");

            migrationBuilder.DropTable(
                name: "VuKhis");
        }
    }
}
