﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeApuntoWeb.Migrations
{
    public partial class Ultima : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCategoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblNotificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioReceptor = table.Column<int>(type: "int", nullable: false),
                    UsuarioRemitente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblNotificaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Edad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organizacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoCuenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo_usuarioId = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblUsuario_tblTipo_Tipo_usuarioId",
                        column: x => x.Tipo_usuarioId,
                        principalTable: "tblTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblEvento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_evento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_termino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEvento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEvento_tblCategoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "tblCategoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblEvento_tblUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tblUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblAsistenciaEventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAsistenciaEventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblAsistenciaEventos_tblEvento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "tblEvento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAsistenciaEventos_EventoId",
                table: "tblAsistenciaEventos",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEvento_CategoriaId",
                table: "tblEvento",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEvento_UsuarioId",
                table: "tblEvento",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUsuario_Tipo_usuarioId",
                table: "tblUsuario",
                column: "Tipo_usuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAsistenciaEventos");

            migrationBuilder.DropTable(
                name: "tblNotificaciones");

            migrationBuilder.DropTable(
                name: "tblEvento");

            migrationBuilder.DropTable(
                name: "tblCategoria");

            migrationBuilder.DropTable(
                name: "tblUsuario");

            migrationBuilder.DropTable(
                name: "tblTipo");
        }
    }
}
