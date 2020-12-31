var optionsSelect2 = {
    dropdownAutoWidth: true,
    width: 'resolve',
    theme: "default",
    placeholder: " - Aucune sélection - ",
    allowClear: true,
    templateSelection: function (item) {
        var tabItemInfos = item.text.split('|');
        return tabItemInfos[0];
    },
    templateResult: function (item) {
        var tabItemInfos = item.text.split('|');
        console.log("tabItemInfos");
        console.log(tabItemInfos);
        var templatedText = "";
        for (let currentStr of tabItemInfos) {
            templatedText += currentStr;
        }
        return $("<div class='row' style='margin:0'><div class='col'>" + tabItemInfos.join("</div><div class='col'>") + "</div></div>");
    }
};

function GetForeignValue(entity, id) {
    if (typeof clientEntitySignal === "object" && clientEntitySignal instanceof EntitySignal.Client) {
        var arrayObject = clientEntitySignal.subscriptions["/" + entity + "/SubscribeToAll"];
        if (Array.isArray(arrayObject)) {
            for (let valueObject of arrayObject) {
                if (valueObject["Id"] === id)
                    return valueObject["DisplayValue"];
            }
        }
    }
    return id;
}

function CreateGridTab(entity, gridTabPrefix) {
    var gridTab;
    try {
        gridTab = eval(gridTabPrefix + entity);
    }
    catch (e) { }
    if (!Array.isArray(gridTab)) {
        gridTab = eval('window.' + gridTabPrefix + entity + '=[];');        //global variable
    }
    return gridTab;
}

function InitCrud(entityForOptions, idSource, idButtonsCrud = null) {

    var optionsShowCrud = eval('optionsShowCrud_' + entityForOptions);
    var entity = optionsShowCrud.apiEntity;

    if (idButtonsCrud !== null) {
        $("#" + idButtonsCrud).append('<a href="/' + entityForOptions + '/Create" class="tool-button add-button create-new-entity" data="Create" data-entity="' + entity + '"><div class="button-outer" data="Create"><span class="button-inner create-new-entity-label" data="Create">' + optionsShowCrud.actionCreateLabel + '</span></div></a>');
        $(".create-new-entity[data-entity='" + entity + "']").on("click", optionsShowCrud, ShowCrud);
    }
    if (idSource === null)
        return;


    var jquerySourceSelector = "#" + idSource;

    var grid = null;
    var gridDataView = null;
    var gridTab = CreateGridTab(entity, 'gridTab_');
    var gridTabDataView = CreateGridTab(entity, 'gridTabDataView_');



    //try {
    //    gridTab = eval('gridTab_' + entity);
    //}
    //catch (e) { }
    //if (!Array.isArray(gridTab)) {
    //    gridTab = eval('window.gridTab_' + entity + '=[];');        //global variable
    //}

    //try {
    //    gridTabDataView = eval('gridTabDataView_' + entity);
    //}
    //catch (e) { }
    //if (!Array.isArray(gridTabDataView)) {
    //    gridTabDataView = eval('window.gridTabDataView_' + entity + '=[];');        //global variable
    //}


    if (typeof clientEntitySignal === "object" && clientEntitySignal instanceof EntitySignal.Client) {
        //var syncedList;
        clientEntitySignal.syncWith("/" + entity + "/SubscribeToAll").then(function (x) {
            //syncedList = x;
        });
        if (optionsShowCrud.subEntities != undefined) {
            for (let subEntity of optionsShowCrud.subEntities) {

                CreateGridTab(subEntity, 'gridTab_');
                CreateGridTab(subEntity, 'gridTabDataView_');

                clientEntitySignal.syncWith("/" + subEntity + "/SubscribeToAll").then(function (x) {
                    //syncedList = x;
                });
            }
        }

    }


    $('body').append('<ul id="' + idSource + '_gridContextMenu" class="gridContextMenu" style="display:none;position:absolute" data-entity="' + entity + '"><li data="Details"><a class="gridContextMenu_LinkDetails" data="Details"></a></li><li data="Edit"><a class="gridContextMenu_LinkEdit" data="Edit"></a></li><li data="Delete"><a class="gridContextMenu_LinkDelete" data="Delete"></a></li></ul>');
    $(".gridContextMenu[data-entity='" + entity + "']").on("click", optionsShowCrud, ShowCrud);

    if (typeof Slick !== "undefined" && $(jquerySourceSelector).length) {
        $.getJSON(optionsShowCrud.apiUrl, function (slickgridData) {
            gridDataView = new Slick.Data.DataView();
            gridTabDataView.push(gridDataView);
            gridDataView.setItems(slickgridData, "Id");


            grid = new Slick.Grid(jquerySourceSelector, gridDataView, optionsShowCrud.gridColumns, optionsShowCrud.gridOptions);
            gridTab.push(grid);

            grid.indexGridTab = gridDataView.indexGridTab = gridTabDataView.length - 1;
            grid.entity = gridDataView.entity = entity;

            // Make the grid respond to DataView change events.
            gridDataView.onRowCountChanged.subscribe(function (e, args) {
                var currentGridTab = eval('gridTab_' + args.dataView.entity);
                currentGridTab[args.dataView.indexGridTab].updateRowCount();
                currentGridTab[args.dataView.indexGridTab].render();
            });

            gridDataView.onRowsChanged.subscribe(function (e, args) {
                var currentGridTab = eval('gridTab_' + args.dataView.entity);
                currentGridTab[args.dataView.indexGridTab].invalidateRows(args.rows);
                currentGridTab[args.dataView.indexGridTab].render();
            });



            grid.setSelectionModel(new Slick.CellSelectionModel());
            //grid.onAddNewRow.subscribe(function (e, args) {
            //    var item = args.item;
            //    args.grid.invalidateRow(data.length);
            //    data.push(item);
            //    args.grid.updateRowCount();
            //    args.grid.render();
            //});

            /* Menu contextuel */
            grid.onContextMenu.subscribe(function (e, args) {
                e.preventDefault();
                var cell = args.grid.getCellFromEvent(e);
                var item = args.grid.getDataItem(cell.row);
                if (typeof item !== "object")
                    return;
                var textToShow = "";
                if (typeof optionsShowCrud.infosEntityToEval === "string" && optionsShowCrud.infosEntityToEval != "") {
                    textToShow = eval(optionsShowCrud.infosEntityToEval);
                }
                var currentOptionsShowCrud = eval('optionsShowCrud_' + args.grid.entity);

                $("#" + args.grid.getContainerNode().id + "_gridContextMenu .gridContextMenu_LinkDetails").attr("href", currentOptionsShowCrud.viewUrl + "/" + "Details?id=" + item.Id)
                    .text(currentOptionsShowCrud.actionDetailsLabel + textToShow);
                $("#" + args.grid.getContainerNode().id + "_gridContextMenu  .gridContextMenu_LinkEdit").attr("href", optionsShowCrud.viewUrl + "/" + "Edit?id=" + item.Id)
                    .text(currentOptionsShowCrud.actionEditLabel + textToShow);
                $("#" + args.grid.getContainerNode().id + "_gridContextMenu  .gridContextMenu_LinkDelete").attr("href", currentOptionsShowCrud.viewUrl + "/" + "Delete?id=" + item.Id)
                    .text(currentOptionsShowCrud.actionDeleteLabel + textToShow);
                $("#" + args.grid.getContainerNode().id + "_gridContextMenu ")
                    .data("row", item.Id)
                    .css("top", e.pageY - 73)
                    .css("left", e.pageX)
                    .show();



                $("body").one("click", function (e) {
                    $(".gridContextMenu").hide();
                    //var cell = grid.getCellFromEvent(e);
                });
            });
            //grid.onClick.subscribe(function (e) {
            //    var cell = grid.getCellFromEvent(e);
            //    if (grid.getColumns()[cell.cell].id == "priority") {
            //        if (!grid.getEditorLock().commitCurrentEdit()) {
            //            return;
            //        }
            //        var states = { "Low": "Medium", "Medium": "High", "High": "Low" };
            //        data[cell.row].priority = states[data[cell.row].priority];
            //        console.log(cell);
            //        grid.updateRow(cell.row);
            //        e.stopPropagation();
            //    }
            //});


        });
    }


    $('.save-and-close-button').click(SubmitCurrentForm);
    $('.delete-button').click(SubmitCurrentForm);
    $('.select2').select2(optionsSelect2);
    $('.crud_indialog').on("click", ShowCrud);

}
//$(function () {

//$('#example1').DataTable({
//    "paging": true,
//    "lengthChange": true,
//    "searching": true,
//    "ordering": true,
//    "info": true,
//    "autoWidth": true
//});
//if ($('#dtChauffeurs').length !== 0) {
//    $('#dtChauffeurs thead tr:last th').each(function () {
//        var label = $('#dtChauffeurs thead tr:first th:eq(' + $(this).index() + ')').html();
//        $(this).addClass('p-0').html('<span class="sr-only">' + label + '</span><input type="search" class="form-control form-control-sm" aria-label="' + label + '" />');
//    });
//    var table = $('#dtChauffeurs').DataTable({
//        language: {
//            processing: "Loading Data...",
//            zeroRecords: "No matching records found"
//        },
//        processing: true,
//        serverSide: true,
//        orderCellsTop: true,
//        autoWidth: true,
//        deferRender: true,
//        dom: '<tr>',
//        ajax: {
//            type: "POST",
//            url: '/api/Chauffeurs/LoadTable',
//            contentType: "application/json; charset=utf-8",
//            async: true,
//            headers: {
//                "XSRF-TOKEN": document.querySelector('[name="__RequestVerificationToken"]').value
//            },
//            data: function (data) {
//                let additionalValues = [];
//                additionalValues[0] = "Additional Parameters 1";
//                additionalValues[1] = "Additional Parameters 2";
//                data.AdditionalValues = additionalValues;
//                return JSON.stringify(data);
//            }
//        },
//        columns: [{
//            title: "Id",
//            data: "Id",
//            name: "eq"
//        }, {
//            title: "Abrege",
//            data: "Abrege",
//            name: "co"
//        }, {
//            title: "Nom",
//            data: "Nom",
//            name: "eq"
//        }, {
//            title: "Prenom",
//            data: "Prenom",
//            name: "eq"
//        }]
//    });
//    table.columns().every(function (index) {
//        $('#dtChauffeurs thead tr:last th:eq(' + index + ') input').on('keyup', function (e) {
//            if (e.keyCode === 13) {
//                table.column($(this).parent().index() + ':visible').search(this.value).draw();
//            }
//        });
//    });
//}



///* Calendar */
///* initialize the external events
// -----------------------------------------------------------------*/
//function ini_events(ele) {
//    ele.each(function () {

//        // create an Event Object (http://arshaw.com/fullcalendar/docs/event_data/Event_Object/)
//        // it doesn't need to have a start or end
//        var eventObject = {
//            title: $.trim($(this).text()) // use the element's text as the event title
//        }

//        // store the Event Object in the DOM element so we can get to it later
//        $(this).data('eventObject', eventObject)

//        // make the event draggable using jQuery UI
//        $(this).draggable({
//            zIndex: 1070,
//            revert: true, // will cause the event to go back to its
//            revertDuration: 0  //  original position after the drag
//        })

//    })
//}

//ini_events($('#external-events div.external-event'))

///* initialize the calendar
// -----------------------------------------------------------------*/
////Date for the calendar events (dummy data)
//var date = new Date()
//var d = date.getDate(),
//    m = date.getMonth(),
//    y = date.getFullYear()
//$('#calendar').fullCalendar({
//    header: {
//        left: 'prev,next today',
//        center: 'title',
//        right: 'resourceTimelineDay,resourceTimelineWeek,month,agendaWeek,agendaDay'
//    },
//    buttonText: {
//        today: 'today',
//        month: 'month',
//        week: 'week',
//        day: 'day'
//    },

//    aspectRatio: 1.6,
//    defaultView: 'month',
//    resourceGroupField: 'type',
//    resources: [
//        { id: 'a', type: '460 Bryant', title: 'Auditorium A' },
//        { id: 'b', type: '460 Bryant', title: 'Auditorium B' },
//        { id: 'c', type: '460 Bryant', title: 'Auditorium C' },
//        { id: 'd', type: '460 Bryant', title: 'Auditorium D' },
//        { id: 'e', type: '460 Bryant', title: 'Auditorium E' },
//        { id: 'f', type: '460 Bryant', title: 'Auditorium F' },
//        { id: 'g', type: '564 Pacific', title: 'Auditorium G' },
//        { id: 'h', type: '564 Pacific', title: 'Auditorium H' },
//        { id: 'i', type: '564 Pacific', title: 'Auditorium I' },
//        { id: 'j', type: '564 Pacific', title: 'Auditorium J' },
//        { id: 'k', type: '564 Pacific', title: 'Auditorium K' },
//        { id: 'l', type: '564 Pacific', title: 'Auditorium L' },
//        { id: 'm', type: '564 Pacific', title: 'Auditorium M' },
//        { id: 'n', type: '564 Pacific', title: 'Auditorium N' },
//        { id: 'o', type: '101 Main St', title: 'Auditorium O' },
//        { id: 'p', type: '101 Main St', title: 'Auditorium P' },
//        { id: 'q', type: '101 Main St', title: 'Auditorium Q' },
//        { id: 'r', type: '101 Main St', title: 'Auditorium R' },
//        { id: 's', type: '101 Main St', title: 'Auditorium S' },
//        { id: 't', type: '101 Main St', title: 'Auditorium T' },
//        { id: 'u', type: '101 Main St', title: 'Auditorium U' },
//        { id: 'v', type: '101 Main St', title: 'Auditorium V' },
//        { id: 'w', type: '101 Main St', title: 'Auditorium W' },
//        { id: 'x', type: '101 Main St', title: 'Auditorium X' },
//        { id: 'y', type: '101 Main St', title: 'Auditorium Y' },
//        { id: 'z', type: '101 Main St', title: 'Auditorium Z' }
//    ]

//    //Random default events
//    events: [
//        {
//            title: 'All Day Event',
//            start: new Date(y, m, 1),
//            backgroundColor: '#f56954', //red
//            borderColor: '#f56954' //red
//        },
//        {
//            title: 'Long Event',
//            start: new Date(y, m, d - 5),
//            end: new Date(y, m, d - 2),
//            backgroundColor: '#f39c12', //yellow
//            borderColor: '#f39c12' //yellow
//        },
//        {
//            title: 'Meeting',
//            start: new Date(y, m, d, 10, 30),
//            allDay: false,
//            backgroundColor: '#0073b7', //Blue
//            borderColor: '#0073b7' //Blue
//        },
//        {
//            title: 'Lunch',
//            start: new Date(y, m, d, 12, 0),
//            end: new Date(y, m, d, 14, 0),
//            allDay: false,
//            backgroundColor: '#00c0ef', //Info (aqua)
//            borderColor: '#00c0ef' //Info (aqua)
//        },
//        {
//            title: 'Birthday Party',
//            start: new Date(y, m, d + 1, 19, 0),
//            end: new Date(y, m, d + 1, 22, 30),
//            allDay: false,
//            backgroundColor: '#00a65a', //Success (green)
//            borderColor: '#00a65a' //Success (green)
//        },
//        {
//            title: 'Click for Google',
//            start: new Date(y, m, 28),
//            end: new Date(y, m, 29),
//            url: 'http://google.com/',
//            backgroundColor: '#3c8dbc', //Primary (light-blue)
//            borderColor: '#3c8dbc' //Primary (light-blue)
//        }
//    ],
//    editable: true,
//    droppable: true, // this allows things to be dropped onto the calendar !!!
//    drop: function (date, allDay) { // this function is called when something is dropped

//        // retrieve the dropped element's stored Event Object
//        var originalEventObject = $(this).data('eventObject')

//        // we need to copy it, so that multiple events don't have a reference to the same object
//        var copiedEventObject = $.extend({}, originalEventObject)

//        // assign it the date that was reported
//        copiedEventObject.start = date
//        copiedEventObject.allDay = allDay
//        copiedEventObject.backgroundColor = $(this).css('background-color')
//        copiedEventObject.borderColor = $(this).css('border-color')

//        // render the event on the calendar
//        // the last `true` argument determines if the event "sticks" (http://arshaw.com/fullcalendar/docs/event_rendering/renderEvent/)
//        $('#calendar').fullCalendar('renderEvent', copiedEventObject, true)

//        // is the "remove after drop" checkbox checked?
//        if ($('#drop-remove').is(':checked')) {
//            // if so, remove the element from the "Draggable Events" list
//            $(this).remove()
//        }

//    }
//})

///* ADDING EVENTS */
//var currColor = '#3c8dbc' //Red by default
////Color chooser button
//var colorChooser = $('#color-chooser-btn')
//$('#color-chooser > li > a').click(function (e) {
//    e.preventDefault()
//    //Save color
//    currColor = $(this).css('color')
//    //Add color effect to button
//    $('#add-new-event').css({
//        'background-color': currColor,
//        'border-color': currColor
//    })
//})
//$('#add-new-event').click(function (e) {
//    e.preventDefault()
//    //Get value and make sure it is not null
//    var val = $('#new-event').val()
//    if (val.length == 0) {
//        return
//    }

//    //Create events
//    var event = $('<div />')
//    event.css({
//        'background-color': currColor,
//        'border-color': currColor,
//        'color': '#fff'
//    }).addClass('external-event')
//    event.html(val)
//    $('#external-events').prepend(event)

//    //Add draggable funtionality
//    ini_events(event)

//    //Remove event from text input
//    $('#new-event').val('')
//})


//})



//$("#contextMenu").click((e) =>ShowCrud(e, optionsShowCrud));
//$("#contextMenu").on("click", optionsShowCrud, ShowCrud);
//$("#contextMenu").click(function (e) {
//    //if (!$(e.target).is("li")) {
//    //    return;
//    //}

//    if (!grid.getEditorLock().commitCurrentEdit()) {
//        return;
//    }
//    var action = $(e.target).attr("data");

//    var parameters = "layout=false";
//    if (action === "Create") {
//        parameters += "&id=" + $(this).data("row");
//    }

//    $('#crudChauffeur').load("~/Chauffeurs/" + action + parameters, function (response,
//        status, http) {
//        if (status == "success") {
//            $(".tool-buttons").click(function (e, data) {
//                $('#myGrid').show();
//                $('#crudChauffeur').hide();
//            });
//            $('#myGrid').hide();
//            $('#crudChauffeur').show();
//        }

//        //if (status == "error")
//        //    alert("Error: " + http.status + ": "
//        //        + http.statusText);
//    });



//    //var row = $(this).data("row");
//    //data[row].ville = $(e.target).attr("data");
//    //grid.updateRow(row);
//});

function ShowCrud(e) {
    console.log($(this));
    var currentData;
    if (typeof e === "object") {
        e.preventDefault();
        currentData = e.data
    }

    var optionsCrud;
    if (currentData === undefined) {
        optionsCrud = eval('optionsShowCrud_' + (typeof e === "string" ? e : $(this).data("entity")));
    }
    else {
        optionsCrud = currentData;
    }

    //if (!$(e.target).is("li")) {
    //    return;
    //}


    if (typeof grid != "undefined" && !grid.getEditorLock().commitCurrentEdit()) {
        return;
    }
    var jqThis = $(this);
    var idDialogUI = "crud" + optionsCrud.apiEntity;
    var field = jqThis.data("field");
    var textTitleAdded = "";

    if (field != undefined) {
        idDialogUI += field;
    }
    var currentItem = jqThis.parent().closest('select option:selected');
    if (currentItem == undefined) {
        action = "Create";
    }
    else {
        var valCurrentItem = currentItem.val();
        if (valCurrentItem != undefined && valCurrentItem !== "") {
            jqThis.data("row", valCurrentItem);
            idDialogUI += valCurrentItem;
            textTitleAdded = " (" + currentItem.text() + ")";
        }
        else {
            action = "Create";
        }
    }


    var target = $(e.target);
    if (target.is("path"))  // if path tag added because: 'class="fa fa-plus-square"'
        target = target.parent();
    var action = target.attr("data");

    if (action === undefined) {
        action = "Create";
    }

    if (action != "Create") {
        var id = jqThis.data("row");
        //var id = $(this).attr("data");
        if (id === undefined || id === "")
            action = "Create";
        else {
            idDialogUI += id;
        }
    }
    var dialogUI = $('#' + idDialogUI);
    if (!dialogUI.length) {
        dialogUI = CreateCrud(idDialogUI);
    }

    LoadCrudInDialog(dialogUI, optionsCrud, action, id, textTitleAdded);


}


function LoadCrudInDialog(dialogUI, optionsCrud, action, id = "", textTitleAdded = "") {
    var parameters = "?layout=false";
    if (id !== null && id !== undefined && id !== "") {
        parameters += "&id=" + id;
    }

    var crudUrl = optionsCrud.viewUrl + "/" + action + parameters;
    dialogUI.load(crudUrl, function (response,
        status, http) {
        if (status == "success") {
            switch (action) {
                case 'Edit':
                    dialogUI.dialog('option', 'title', optionsCrud.actionEditLabel + textTitleAdded);
                    dialogUI.find('.save-and-close-button').click(SubmitCurrentForm);
                    break;
                case 'Delete':
                    dialogUI.dialog('option', 'title', optionsCrud.actionDeleteLabel + textTitleAdded);
                    dialogUI.find('.delete-button').click(SubmitCurrentForm);
                    break;
                case 'Details':
                    dialogUI.dialog('option', 'title', optionsCrud.actionDetailsLabel + textTitleAdded);
                    break;
                default:
                    //case 'Create':
                    dialogUI.dialog('option', 'title', optionsCrud.actionCreateLabel + textTitleAdded);
                    dialogUI.find('.save-and-close-button').click(SubmitCurrentForm);
                    break;
            }
            dialogUI.find('.select2').select2(optionsSelect2);
            dialogUI.find('.crud_indialog').on("click", ShowCrud);


            dialogUI.find('.panel-titlebar-close').click(function (e, data) {
                //$('#myGridToolbar').show();
                //$('#myGrid').show();
                dialogUI.dialog('close');
                //$('#crudChauffeur').hide();

            });
            //$('#myGridToolbar').hide();
            //$('#myGrid').hide();
            dialogUI.dialog('open');

        }

        //if (status == "error")
        //    alert("Error: " + http.status + ": "
        //        + http.statusText);
    });


}



function DeleteDialogFromFieldSet(i, currentElement) {
    var jqCurrentElement = $(currentElement);
    var dialogUi = jqCurrentElement.closest('.ui-dialog-content');
    if (dialogUi.is(":visible")) {
        dialogUi.dialog('close');
    }
}

var offsetDialog = 20;





function CreateCrud(idDialogUI) {
    $('body').append("<div class='flex-layout s-Panel' id='" + idDialogUI + "'></div>");

    var dialogUI = $('#' + idDialogUI);

    dialogUI.dialog({
        dialogClass: "s-Dialog",
        open: function () {
            $(this).closest(".ui-dialog")
                .find(".ui-dialog-titlebar-close").addClass("ui-button ui-corner-all ui-widget ui-button-icon-only")
                //.removeClass("ui-dialog-titlebar-close")
                .html('<i class="fa fa-times" />');
        },
        autoOpen: false,
        title: '',
        width: 500,
        height: 700,
        draggable: true,
        position: {
            my: "center",
            at: "center+" + (offsetDialog += 20),
            //of: this,
            collision: "fit"
        }
        //buttons: [{
        //    title: 'Add Note',
        //    cssClass: 'add-button',
        //    //onClick: function (e) {
        //    //    e.preventDefault();
        //    //    _this.addClick();
        //    //}
        //}]
    });
    dialogUI.show();
    return dialogUI;
}

function AjaxFormSuccess(response, textStatus, jqXHR) {
    $(this).closest('.ui-dialog-content').dialog('close');
}
function AjaxFormFailure(jqXHR, textStatus, errorMessage) {
    if (jqXHR.responseJSON !== undefined && typeof jqXHR.responseJSON.Value === "string") {
        errorMessage = jqXHR.responseJSON.Value;
    }
    $(this).find(".ajax-error-text").text(errorMessage).show();
}
function SubmitCurrentForm() {
    var jqCurrentForm = $(this).closest("form");
    jqCurrentForm.find(".ajax-error-text").hide();
    jqCurrentForm.submit();
}