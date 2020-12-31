var optionsShowCrud_Client = {
    apiEntity: "Client",
    subEntities: [
    ],
    apiUrl: "/api/Client",
    viewUrl: "/Client",
    actionCreateLabel: "Créer client",
    actionEditLabel: "Modifier client",
    actionDeleteLabel: "Supprimer client",
    actionDetailsLabel: "Fiche client",
    infosEntityToEval: "' (' + item.DisplayValue + ')'",
    gridColumns: [
        {
            id: "DisplayValue",
            field: "DisplayValue",
            name: "Infos"
        },
        {
            id: "Nom",
            field: "Nom",
            name: "Nom"
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
