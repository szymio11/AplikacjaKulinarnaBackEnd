using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AplikacjaKulinarna.Repository.Migrations
{
    public partial class SeedRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Ratings (RecipeId,id,UserId,Value) VALUES ('3e0231b3-a0aa-47a7-a845-3283a1732a12','3e0231b3-a0aa-47a7-a845-3283a1732a12','3e0231b3-a0aa-47a7-a845-3283a1732a63','2')");
            migrationBuilder.Sql("INSERT INTO Ratings (RecipeId,id,UserId,Value) VALUES ('3e0231b3-a0aa-47a7-a845-3283a1732a12','3e0231b3-a0aa-47a7-a845-3283a1732a13','3e0231b3-a0aa-47a7-a845-3283a1732a63','3')");
            migrationBuilder.Sql("INSERT INTO Ratings (RecipeId,id,UserId,Value) VALUES ('3e0231b3-a0aa-47a7-a845-3283a1732a12','3e0231b3-a0aa-47a7-a845-3283a1732a14','3e0231b3-a0aa-47a7-a845-3283a1732a63','4')");

            migrationBuilder.Sql("INSERT INTO Ratings (RecipeId,id,UserId,Value) VALUES ('3e0231b3-a0aa-47a7-a845-3283a1732a22','3e0231b3-a0aa-47a7-a845-3283a1732a22','3e0231b3-a0aa-47a7-a845-3283a1732a63','1')");
            migrationBuilder.Sql("INSERT INTO Ratings (RecipeId,id,UserId,Value) VALUES ('3e0231b3-a0aa-47a7-a845-3283a1732a22','3e0231b3-a0aa-47a7-a845-3283a1732a33','3e0231b3-a0aa-47a7-a845-3283a1732a63','3')");
            migrationBuilder.Sql("INSERT INTO Ratings (RecipeId,id,UserId,Value) VALUES ('3e0231b3-a0aa-47a7-a845-3283a1732a22','3e0231b3-a0aa-47a7-a845-3283a1732a44','3e0231b3-a0aa-47a7-a845-3283a1732a63','4')");

            migrationBuilder.Sql("INSERT INTO Ratings (RecipeId,id,UserId,Value) VALUES ('3e0231b3-a0aa-47a7-a845-3283a1732a32','3e0231b3-a0aa-47a7-a845-3283a1732a15','3e0231b3-a0aa-47a7-a845-3283a1732a63','2')");
            migrationBuilder.Sql("INSERT INTO Ratings (RecipeId,id,UserId,Value) VALUES ('3e0231b3-a0aa-47a7-a845-3283a1732a32','3e0231b3-a0aa-47a7-a845-3283a1732a16','3e0231b3-a0aa-47a7-a845-3283a1732a63','5')");
            migrationBuilder.Sql("INSERT INTO Ratings (RecipeId,id,UserId,Value) VALUES ('3e0231b3-a0aa-47a7-a845-3283a1732a32','3e0231b3-a0aa-47a7-a845-3283a1732a17','3e0231b3-a0aa-47a7-a845-3283a1732a63','2')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
