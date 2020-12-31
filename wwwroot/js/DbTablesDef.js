//A couper/coller dans le fichier "/wwwroot/js/DbTablesDef.js"
//------------- AdresseNew (AdresseNew) -------------// DEBUT
var optionsShowCrud_AdresseNew = {
    apiEntity: "AdresseNew",
    subEntities: [
        ],
    apiUrl: "/api/AdresseNew",
    viewUrl: "/AdresseNew",
    actionCreateLabel: "Créer adresse new",
    actionEditLabel: "Modifier adresse new",
    actionDeleteLabel: "Supprimer adresse new",
    actionDetailsLabel: "Fiche adresse new",
    infosEntityToEval: "' (' + item.DisplayValue + ')'",
    gridColumns: [
        {
            id: "DisplayValue",
            field: "DisplayValue",
            name: "Infos"
        },
        {
            id: "AdresseTexte",
            field: "AdresseTexte",
            name: "Adresse texte"
        },
        {
            id: "Complement",
            field: "Complement",
            name: "Complement"
        },
        {
            id: "CodePostal",
            field: "CodePostal",
            name: "Code postal"
        },
        {
            id: "Ville",
            field: "Ville",
            name: "Ville"
        },
        {
            id: "NomVille",
            field: "NomVille",
            name: "Nom ville"
        },
        {
            id: "Departement",
            field: "Departement",
            name: "Departement"
        },
        {
            id: "NomDepartement",
            field: "NomDepartement",
            name: "Nom departement"
        },
        {
            id: "Region",
            field: "Region",
            name: "Region"
        },
        {
            id: "NomRegion",
            field: "NomRegion",
            name: "Nom region"
        },
        {
            id: "Pays",
            field: "Pays",
            name: "Pays"
        },
        {
            id: "NomPays",
            field: "NomPays",
            name: "Nom pays"
        },
    ],
    gridOptions:
    {
        columnPicker:
        {
            columnTitle: "Columns",
            hideForceFitButton: false,
            hideSyncResizeButton: false,
            forceFitTitle: "Force fit columns",
            syncResizeTitle: "Synchronous resize",
        },
        enableColumnReorder: true,
        multiColumnSort: true,
        editable: true,
        enableAddRow: true,
        enableCellNavigation: true,
        asyncEditorLoading: true,
        forceFitColumns: false,
        topPanelHeight: 25
    }
};
//------------- AdresseNew (AdresseNew) -------------// FIN
//A couper/coller dans le fichier "/wwwroot/js/DbTablesDef.js"
//------------- CategorieVehiculeNew (CategorieVehiculeNew) -------------// DEBUT
var optionsShowCrud_CategorieVehiculeNew = {
    apiEntity: "CategorieVehiculeNew",
    subEntities: [
    ],
    apiUrl: "/api/CategorieVehiculeNew",
    viewUrl: "/CategorieVehiculeNew",
    actionCreateLabel: "Créer categorie vehicule new",
    actionEditLabel: "Modifier categorie vehicule new",
    actionDeleteLabel: "Supprimer categorie vehicule new",
    actionDetailsLabel: "Fiche categorie vehicule new",
    infosEntityToEval: "' (' + item.DisplayValue + ')'",
    gridColumns: [
        {
            id: "DisplayValue",
            field: "DisplayValue",
            name: "Infos"
        },
        {
            id: "Categorie",
            field: "Categorie",
            name: "Categorie"
        },
        {
            id: "Libelle",
            field: "Libelle",
            name: "Libelle"
        },
        {
            id: "DateCreation",
            field: "DateCreation",
            name: "Date creation"
        },
        {
            id: "DateSaisie",
            field: "DateSaisie",
            name: "Date saisie"
        },
    ],
    gridOptions:
    {
        columnPicker:
        {
            columnTitle: "Columns",
            hideForceFitButton: false,
            hideSyncResizeButton: false,
            forceFitTitle: "Force fit columns",
            syncResizeTitle: "Synchronous resize",
        },
        enableColumnReorder: true,
        multiColumnSort: true,
        editable: true,
        enableAddRow: true,
        enableCellNavigation: true,
        asyncEditorLoading: true,
        forceFitColumns: false,
        topPanelHeight: 25
    }
};
//------------- CategorieVehiculeNew (CategorieVehiculeNew) -------------// FIN
//A couper/coller dans le fichier "/wwwroot/js/DbTablesDef.js"
//------------- ChauffeurNew (ChauffeurNew) -------------// DEBUT
var optionsShowCrud_ChauffeurNew = {
    apiEntity: "ChauffeurNew",
    subEntities: [
        "AdresseNew",
        "VehiculeNew",
        "TypePlanningNew",
    ],
    apiUrl: "/api/ChauffeurNew",
    viewUrl: "/ChauffeurNew",
    actionCreateLabel: "Créer chauffeur new",
    actionEditLabel: "Modifier chauffeur new",
    actionDeleteLabel: "Supprimer chauffeur new",
    actionDetailsLabel: "Fiche chauffeur new",
    infosEntityToEval: "' (' + item.DisplayValue + ')'",
    gridColumns: [
        {
            id: "DisplayValue",
            field: "DisplayValue",
            name: "Infos"
        },
        {
            id: "Operateur",
            field: "Operateur",
            name: "Operateur"
        },
        {
            id: "Abrege",
            field: "Abrege",
            name: "Abrege"
        },
        {
            id: "Nom",
            field: "Nom",
            name: "Nom"
        },
        {
            id: "Prenom",
            field: "Prenom",
            name: "Prenom"
        },
        {
            id: "Telephone",
            field: "Telephone",
            name: "Telephone"
        },
        {
            id: "Telephone2",
            field: "Telephone2",
            name: "Telephone 2"
        },
        {
            id: "Portable",
            field: "Portable",
            name: "Portable"
        },
        {
            id: "Email",
            field: "Email",
            name: "Email"
        },
        {
            id: "Permis",
            field: "Permis",
            name: "Permis"
        },
        {
            id: "NbHeures",
            field: "NbHeures",
            name: "Nb heures"
        },
        {
            id: "Notes",
            field: "Notes",
            name: "Notes"
        },
        {
            id: "Tiers",
            field: "Tiers",
            name: "Tiers"
        },
        {
            id: "DateSortie",
            field: "DateSortie",
            name: "Date sortie"
        },
        {
            id: "DateCreation",
            field: "DateCreation",
            name: "Date creation"
        },
        {
            id: "DateSaisie",
            field: "DateSaisie",
            name: "Date saisie"
        },
        {
            id: "TypePlanning",
            field: "TypePlanning",
            name: "Type planning"
        },
        {
            id: "Adresse",
            field: "Adresse",
            name: "Adresse"
        },
        {
            id: "AdresseChute",
            field: "AdresseChute",
            name: "Adresse chute"
        },
        {
            id: "Remorque",
            field: "Remorque",
            name: "Remorque"
        },
        {
            id: "Vehicule",
            field: "Vehicule",
            name: "Vehicule"
        },
    ],
    gridOptions:
    {
        columnPicker:
        {
            columnTitle: "Columns",
            hideForceFitButton: false,
            hideSyncResizeButton: false,
            forceFitTitle: "Force fit columns",
            syncResizeTitle: "Synchronous resize",
        },
        enableColumnReorder: true,
        multiColumnSort: true,
        editable: true,
        enableAddRow: true,
        enableCellNavigation: true,
        asyncEditorLoading: true,
        forceFitColumns: false,
        topPanelHeight: 25
    }
};
//------------- ChauffeurNew (ChauffeurNew) -------------// FIN
//A couper/coller dans le fichier "/wwwroot/js/DbTablesDef.js"
//------------- TypePlanningNew (TypePlanningNew) -------------// DEBUT
var optionsShowCrud_TypePlanningNew = {
    apiEntity: "TypePlanningNew",
    subEntities: [
    ],
    apiUrl: "/api/TypePlanningNew",
    viewUrl: "/TypePlanningNew",
    actionCreateLabel: "Créer type planning new",
    actionEditLabel: "Modifier type planning new",
    actionDeleteLabel: "Supprimer type planning new",
    actionDetailsLabel: "Fiche type planning new",
    infosEntityToEval: "' (' + item.DisplayValue + ')'",
    gridColumns: [
        {
            id: "DisplayValue",
            field: "DisplayValue",
            name: "Infos"
        },
        {
            id: "TypePlanningTexte",
            field: "TypePlanningTexte",
            name: "Type planning texte"
        },
        {
            id: "Libelle",
            field: "Libelle",
            name: "Libelle"
        },
        {
            id: "ActiviteAnalytique",
            field: "ActiviteAnalytique",
            name: "Activite analytique"
        },
        {
            id: "GenereDemandePrix",
            field: "GenereDemandePrix",
            name: "Genere demande prix"
        },
    ],
    gridOptions:
    {
        columnPicker:
        {
            columnTitle: "Columns",
            hideForceFitButton: false,
            hideSyncResizeButton: false,
            forceFitTitle: "Force fit columns",
            syncResizeTitle: "Synchronous resize",
        },
        enableColumnReorder: true,
        multiColumnSort: true,
        editable: true,
        enableAddRow: true,
        enableCellNavigation: true,
        asyncEditorLoading: true,
        forceFitColumns: false,
        topPanelHeight: 25
    }
};
//------------- TypePlanningNew (TypePlanningNew) -------------// FIN
//A couper/coller dans le fichier "/wwwroot/js/DbTablesDef.js"
//------------- TypeVehiculeNew (TypeVehiculeNew) -------------// DEBUT
var optionsShowCrud_TypeVehiculeNew = {
    apiEntity: "TypeVehiculeNew",
    subEntities: [
    ],
    apiUrl: "/api/TypeVehiculeNew",
    viewUrl: "/TypeVehiculeNew",
    actionCreateLabel: "Créer type vehicule new",
    actionEditLabel: "Modifier type vehicule new",
    actionDeleteLabel: "Supprimer type vehicule new",
    actionDetailsLabel: "Fiche type vehicule new",
    infosEntityToEval: "' (' + item.DisplayValue + ')'",
    gridColumns: [
        {
            id: "DisplayValue",
            field: "DisplayValue",
            name: "Infos"
        },
        {
            id: "TypeVehiculeTexte",
            field: "TypeVehiculeTexte",
            name: "Type vehicule texte"
        },
        {
            id: "Libelle",
            field: "Libelle",
            name: "Libelle"
        },
        {
            id: "Remorque",
            field: "Remorque",
            name: "Remorque"
        },
        {
            id: "Camion",
            field: "Camion",
            name: "Camion"
        },
        {
            id: "Tracteur",
            field: "Tracteur",
            name: "Tracteur"
        },
        {
            id: "SousTraitant",
            field: "SousTraitant",
            name: "Sous traitant"
        },
        {
            id: "Autoroute",
            field: "Autoroute",
            name: "Autoroute"
        },
        {
            id: "Route",
            field: "Route",
            name: "Route"
        },
        {
            id: "RouteSec",
            field: "RouteSec",
            name: "Route sec"
        },
        {
            id: "DateCreation",
            field: "DateCreation",
            name: "Date creation"
        },
        {
            id: "DateSaisie",
            field: "DateSaisie",
            name: "Date saisie"
        },
    ],
    gridOptions:
    {
        columnPicker:
        {
            columnTitle: "Columns",
            hideForceFitButton: false,
            hideSyncResizeButton: false,
            forceFitTitle: "Force fit columns",
            syncResizeTitle: "Synchronous resize",
        },
        enableColumnReorder: true,
        multiColumnSort: true,
        editable: true,
        enableAddRow: true,
        enableCellNavigation: true,
        asyncEditorLoading: true,
        forceFitColumns: false,
        topPanelHeight: 25
    }
};
//------------- TypeVehiculeNew (TypeVehiculeNew) -------------// FIN
//A couper/coller dans le fichier "/wwwroot/js/DbTablesDef.js"
//------------- VehiculeNew (VehiculeNew) -------------// DEBUT
var optionsShowCrud_VehiculeNew = {
    apiEntity: "VehiculeNew",
    subEntities: [
        "AdresseNew",
        "CategorieVehiculeNew",
        "TypePlanningNew",
        "TypeVehiculeNew",
    ],
    apiUrl: "/api/VehiculeNew",
    viewUrl: "/VehiculeNew",
    actionCreateLabel: "Créer vehicule new",
    actionEditLabel: "Modifier vehicule new",
    actionDeleteLabel: "Supprimer vehicule new",
    actionDetailsLabel: "Fiche vehicule new",
    infosEntityToEval: "' (' + item.DisplayValue + ')'",
    gridColumns: [
        {
            id: "DisplayValue",
            field: "DisplayValue",
            name: "Infos"
        },
        {
            id: "Immatriculation",
            field: "Immatriculation",
            name: "Immatriculation"
        },
        {
            id: "VehiculeTexte",
            field: "VehiculeTexte",
            name: "Vehicule texte"
        },
        {
            id: "Libelle",
            field: "Libelle",
            name: "Libelle"
        },
        {
            id: "Autoroute",
            field: "Autoroute",
            name: "Autoroute"
        },
        {
            id: "Route",
            field: "Route",
            name: "Route"
        },
        {
            id: "RouteSec",
            field: "RouteSec",
            name: "Route sec"
        },
        {
            id: "Tiers",
            field: "Tiers",
            name: "Tiers"
        },
        {
            id: "Marque",
            field: "Marque",
            name: "Marque"
        },
        {
            id: "MiseEnService",
            field: "MiseEnService",
            name: "Mise en service"
        },
        {
            id: "Acquisition",
            field: "Acquisition",
            name: "Acquisition"
        },
        {
            id: "NoCg",
            field: "NoCg",
            name: "No cg"
        },
        {
            id: "Genre",
            field: "Genre",
            name: "Genre"
        },
        {
            id: "TypeCg",
            field: "TypeCg",
            name: "Type cg"
        },
        {
            id: "NoSerie",
            field: "NoSerie",
            name: "No serie"
        },
        {
            id: "Carrosserie",
            field: "Carrosserie",
            name: "Carrosserie"
        },
        {
            id: "Notes",
            field: "Notes",
            name: "Notes"
        },
        {
            id: "PoidsVide",
            field: "PoidsVide",
            name: "Poids vide"
        },
        {
            id: "Palette",
            field: "Palette",
            name: "Palette"
        },
        {
            id: "Poids",
            field: "Poids",
            name: "Poids"
        },
        {
            id: "MetrageLineaire",
            field: "MetrageLineaire",
            name: "Metrage lineaire"
        },
        {
            id: "Volume",
            field: "Volume",
            name: "Volume"
        },
        {
            id: "Longueur",
            field: "Longueur",
            name: "Longueur"
        },
        {
            id: "Largeur",
            field: "Largeur",
            name: "Largeur"
        },
        {
            id: "Hauteur",
            field: "Hauteur",
            name: "Hauteur"
        },
        {
            id: "Ptac",
            field: "Ptac",
            name: "Ptac"
        },
        {
            id: "DateSortie",
            field: "DateSortie",
            name: "Date sortie"
        },
        {
            id: "PaysOrigine",
            field: "PaysOrigine",
            name: "Pays origine"
        },
        {
            id: "Cabotage",
            field: "Cabotage",
            name: "Cabotage"
        },
        {
            id: "DebutCabotage",
            field: "DebutCabotage",
            name: "Debut cabotage"
        },
        {
            id: "DateCreation",
            field: "DateCreation",
            name: "Date creation"
        },
        {
            id: "DateSaisie",
            field: "DateSaisie",
            name: "Date saisie"
        },
        {
            id: "TypePlanning",
            field: "TypePlanning",
            name: "Type planning"
        },
        {
            id: "TypeVehicule",
            field: "TypeVehicule",
            name: "Type vehicule"
        },
        {
            id: "CategorieVehicule",
            field: "CategorieVehicule",
            name: "Categorie vehicule"
        },
        {
            id: "Adresse",
            field: "Adresse",
            name: "Adresse"
        },
    ],
    gridOptions:
    {
        columnPicker:
        {
            columnTitle: "Columns",
            hideForceFitButton: false,
            hideSyncResizeButton: false,
            forceFitTitle: "Force fit columns",
            syncResizeTitle: "Synchronous resize",
        },
        enableColumnReorder: true,
        multiColumnSort: true,
        editable: true,
        enableAddRow: true,
        enableCellNavigation: true,
        asyncEditorLoading: true,
        forceFitColumns: false,
        topPanelHeight: 25
    }
};
//------------- VehiculeNew (VehiculeNew) -------------// FIN