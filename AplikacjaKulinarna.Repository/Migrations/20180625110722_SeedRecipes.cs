using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AplikacjaKulinarna.Repository.Migrations
{
    public partial class SeedRecipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Recipes (id,Created,Components,Name,PreparationTime,UserId,Difficulty) VALUES ('3e0231b3-a0aa-47a7-a845-3283a1732a12','07.06.2018 11:15:56','25g świeżych drożdży (lub 7g instant), 150 ml ciepłej wody, 1/2 łyżeczki cukru ','Cisto na pizze','00:20:00','3e0231b3-a0aa-47a7-a845-3283a1732a63','1')");
            migrationBuilder.Sql("INSERT INTO Recipes (id,Created,Components,Name,PreparationTime,UserId,Difficulty) VALUES ('3e0231b3-a0aa-47a7-a845-3283a1732a22','06.06.2018 11:15:56','250ml wody, 250ml mleka, 2 jaja, 300g mąki ','Naleśniki','00:30:00','3e0231b3-a0aa-47a7-a845-3283a1732a63','4')");
            migrationBuilder.Sql("INSERT INTO Recipes (id,Created,Components,Name,PreparationTime,UserId,Difficulty) VALUES ('3e0231b3-a0aa-47a7-a845-3283a1732a32','05.06.2018 11:15:56','500g mieso mielone,300g makaron spaghetti, 1 duża Cebula','Spagetti z sosem bolognese','00:40:00','3e0231b3-a0aa-47a7-a845-3283a1732a63','3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "DELETE FROM Recipes WHERE id='3e0231b3-a0aa-47a7-a845-3283a1732a32' OR id='3e0231b3-a0aa-47a7-a845-3283a1732a22' OR id='3e0231b3-a0aa-47a7-a845-3283a1732a32'");
        }
    }
}
