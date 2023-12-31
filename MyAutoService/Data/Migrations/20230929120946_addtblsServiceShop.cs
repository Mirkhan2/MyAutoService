﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAutoService.Data.Migrations
{
    public partial class addtblsServiceShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miles = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dateadded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceHeaders_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicesShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicesShoppingCarts_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicesShoppingCarts_ServiceTypes_CarId",
                        column: x => x.CarId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceHeaderId = table.Column<int>(type: "int", nullable: false),
                    ServiceHeader = table.Column<int>(type: "int", nullable: true),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false),
                    ServicePrice = table.Column<double>(type: "float", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceDetails_ServiceHeaders_ServiceHeader",
                        column: x => x.ServiceHeader,
                        principalTable: "ServiceHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceDetails_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetails_ServiceHeader",
                table: "ServiceDetails",
                column: "ServiceHeader");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetails_ServiceTypeId",
                table: "ServiceDetails",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHeaders_CarId",
                table: "ServiceHeaders",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesShoppingCarts_CarId",
                table: "ServicesShoppingCarts",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceDetails");

            migrationBuilder.DropTable(
                name: "ServicesShoppingCarts");

            migrationBuilder.DropTable(
                name: "ServiceHeaders");
        }
    }
}
