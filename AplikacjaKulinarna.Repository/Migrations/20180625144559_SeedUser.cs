using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AplikacjaKulinarna.Repository.Migrations
{
    public partial class SeedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Users (id,Created,Email,Name,Password,Role) VALUES ('3e0231b3-a0aa-47a7-a845-3283a1732a53','07.06.2018 11:15:56','user@gmail.com','User','12345','user')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
