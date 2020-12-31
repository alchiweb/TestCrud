using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestCrud.Data.Migrations
{
    public partial class DeuxiemeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresse_New",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    AdresseTexte = table.Column<string>(maxLength: 50, nullable: true),
                    Complement = table.Column<string>(maxLength: 50, nullable: true),
                    CodePostal = table.Column<string>(maxLength: 6, nullable: true),
                    Ville = table.Column<string>(maxLength: 10, nullable: true),
                    NomVille = table.Column<string>(maxLength: 50, nullable: true),
                    Departement = table.Column<string>(maxLength: 10, nullable: true),
                    NomDepartement = table.Column<string>(maxLength: 50, nullable: true),
                    Region = table.Column<string>(maxLength: 10, nullable: true),
                    NomRegion = table.Column<string>(maxLength: 50, nullable: true),
                    Pays = table.Column<string>(maxLength: 10, nullable: true),
                    NomPays = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresse_New", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategorieVehicule_New",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    Categorie = table.Column<string>(unicode: false, maxLength: 3, nullable: true),
                    Libelle = table.Column<string>(unicode: false, maxLength: 40, nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Saisie = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieVehicule_New", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypePlanning_New",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    TypePlanning = table.Column<string>(unicode: false, maxLength: 3, nullable: true),
                    Libelle = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    ActiviteAnalytique = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    GenereDemandePrix = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePlanning_New", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeVehicule_New",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    TypeVehicule = table.Column<string>(unicode: false, maxLength: 3, nullable: true),
                    Libelle = table.Column<string>(unicode: false, maxLength: 40, nullable: true),
                    Remorque = table.Column<bool>(nullable: false),
                    Camion = table.Column<bool>(nullable: false),
                    Tracteur = table.Column<bool>(nullable: false),
                    SousTraitant = table.Column<bool>(nullable: false),
                    Autoroute = table.Column<double>(nullable: true),
                    Route = table.Column<double>(nullable: true),
                    RouteSec = table.Column<double>(nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateSaisie = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeVehicule_New", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicule_New",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    Immatriculation = table.Column<string>(maxLength: 11, nullable: true),
                    VehiculeTexte = table.Column<string>(maxLength: 9, nullable: false),
                    Libelle = table.Column<string>(maxLength: 50, nullable: true),
                    Autoroute = table.Column<double>(nullable: true),
                    Route = table.Column<double>(nullable: true),
                    RouteSec = table.Column<double>(nullable: true),
                    Tiers = table.Column<int>(nullable: true),
                    Marque = table.Column<string>(maxLength: 20, nullable: true),
                    MiseEnService = table.Column<DateTime>(type: "datetime", nullable: true),
                    Acquisition = table.Column<DateTime>(type: "datetime", nullable: true),
                    NoCG = table.Column<string>(maxLength: 11, nullable: true),
                    Genre = table.Column<string>(maxLength: 10, nullable: true),
                    TypeCG = table.Column<string>(maxLength: 15, nullable: true),
                    NoSerie = table.Column<string>(maxLength: 50, nullable: true),
                    Carrosserie = table.Column<string>(maxLength: 25, nullable: true),
                    Notes = table.Column<string>(maxLength: 255, nullable: true),
                    PoidsVide = table.Column<double>(nullable: true),
                    Palette = table.Column<short>(nullable: true),
                    Poids = table.Column<float>(nullable: true),
                    MetrageLineaire = table.Column<float>(nullable: true),
                    Volume = table.Column<float>(nullable: true),
                    Longueur = table.Column<float>(nullable: true),
                    Largeur = table.Column<float>(nullable: true),
                    Hauteur = table.Column<float>(nullable: true),
                    PTAC = table.Column<float>(nullable: true),
                    DateSortie = table.Column<DateTime>(type: "datetime", nullable: true),
                    PaysOrigine = table.Column<string>(maxLength: 3, nullable: false),
                    Cabotage = table.Column<bool>(nullable: false),
                    DebutCabotage = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateSaisie = table.Column<DateTime>(type: "datetime", nullable: true),
                    AdresseId = table.Column<Guid>(nullable: true),
                    TypePlanningId = table.Column<Guid>(nullable: true),
                    TypeVehiculeId = table.Column<Guid>(nullable: true),
                    CategorieVehiculeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicule_New", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicule_New_Adresse_New_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adresse_New",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicule_New_CategorieVehicule_New_CategorieVehiculeId",
                        column: x => x.CategorieVehiculeId,
                        principalTable: "CategorieVehicule_New",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicule_New_TypePlanning_New_TypePlanningId",
                        column: x => x.TypePlanningId,
                        principalTable: "TypePlanning_New",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicule_New_TypeVehicule_New_TypeVehiculeId",
                        column: x => x.TypeVehiculeId,
                        principalTable: "TypeVehicule_New",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chauffeur_New",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    Operateur = table.Column<string>(maxLength: 10, nullable: true),
                    Abrege = table.Column<string>(maxLength: 12, nullable: true),
                    Nom = table.Column<string>(maxLength: 50, nullable: true),
                    Prenom = table.Column<string>(maxLength: 20, nullable: true),
                    Telephone = table.Column<string>(maxLength: 25, nullable: true),
                    Telephone2 = table.Column<string>(maxLength: 25, nullable: true),
                    Portable = table.Column<string>(maxLength: 25, nullable: true),
                    EMail = table.Column<string>(maxLength: 50, nullable: true),
                    Permis = table.Column<DateTime>(type: "datetime", nullable: true),
                    nbHeures = table.Column<short>(nullable: true),
                    Notes = table.Column<string>(maxLength: 255, nullable: true),
                    Tiers = table.Column<int>(nullable: true),
                    DateSortie = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateSaisie = table.Column<DateTime>(type: "datetime", nullable: true),
                    AdresseId = table.Column<Guid>(nullable: true),
                    AdresseChuteId = table.Column<Guid>(nullable: true),
                    VehiculeId = table.Column<Guid>(nullable: true),
                    RemorqueId = table.Column<Guid>(nullable: true),
                    TypePlanningId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chauffeur_New", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chauffeur_New_Adresse_New_AdresseChuteId",
                        column: x => x.AdresseChuteId,
                        principalTable: "Adresse_New",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chauffeur_New_Adresse_New_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adresse_New",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chauffeur_New_Vehicule_New_RemorqueId",
                        column: x => x.RemorqueId,
                        principalTable: "Vehicule_New",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chauffeur_New_TypePlanning_New_TypePlanningId",
                        column: x => x.TypePlanningId,
                        principalTable: "TypePlanning_New",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chauffeur_New_Vehicule_New_VehiculeId",
                        column: x => x.VehiculeId,
                        principalTable: "Vehicule_New",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chauffeur_New_AdresseChuteId",
                table: "Chauffeur_New",
                column: "AdresseChuteId");

            migrationBuilder.CreateIndex(
                name: "IX_Chauffeur_New_AdresseId",
                table: "Chauffeur_New",
                column: "AdresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Chauffeur_New_RemorqueId",
                table: "Chauffeur_New",
                column: "RemorqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Chauffeur_New_TypePlanningId",
                table: "Chauffeur_New",
                column: "TypePlanningId");

            migrationBuilder.CreateIndex(
                name: "IX_Chauffeur_New_VehiculeId",
                table: "Chauffeur_New",
                column: "VehiculeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicule_New_AdresseId",
                table: "Vehicule_New",
                column: "AdresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicule_New_CategorieVehiculeId",
                table: "Vehicule_New",
                column: "CategorieVehiculeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicule_New_TypePlanningId",
                table: "Vehicule_New",
                column: "TypePlanningId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicule_New_TypeVehiculeId",
                table: "Vehicule_New",
                column: "TypeVehiculeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chauffeur_New");

            migrationBuilder.DropTable(
                name: "Vehicule_New");

            migrationBuilder.DropTable(
                name: "Adresse_New");

            migrationBuilder.DropTable(
                name: "CategorieVehicule_New");

            migrationBuilder.DropTable(
                name: "TypePlanning_New");

            migrationBuilder.DropTable(
                name: "TypeVehicule_New");
        }
    }
}
