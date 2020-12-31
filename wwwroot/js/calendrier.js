
var calendarEl = document.getElementById('calendar');
var calendar;
//CALENDAR-SCHEDULER
document.addEventListener('DOMContentLoaded', function () {
    var containerEl = document.getElementById('external-events');
    var checkbox = document.getElementById('drop-remove');

    new FullCalendarInteraction.Draggable(containerEl, {
        itemSelector: '.fc-event',
        eventData: function (eventEl) {
            return {
                title: eventEl.innerText
            };
        }
    });

    calendar = new FullCalendar.Calendar(calendarEl, {
        plugins: ['interaction', 'dayGrid', 'timeGrid', 'resourceTimeline'],
        timeZone: 'UTC',
        editable: true,
        aspectRatio: 1.8,
        locale: 'fr',
        scrollTime: '00:00',
        header: {
            left: 'today prev,next',
            center: 'title',
            right: 'resourceTimelineDay,resourceTimelineThreeDays,timeGridWeek,dayGridMonth'
        },
        defaultView: 'resourceTimelineDay',
        views: {
            resourceTimelineThreeDays: {
                type: 'resourceTimeline',
                duration: { days: 2, },
                buttonText: '2 jours'
            }
        },
        minTime: '08:00:00',
        maxTime: '19:00:00',
        weekends: false,

        resourceGroupField: 'type',
        resources: [
            { id: 'a', type: '460 Bryant', title: 'Auditorium A' },
            { id: 'b', type: '460 Bryant', title: 'Auditorium B', eventColor: 'green' },
            { id: 'c', type: '460 Bryant', title: 'Auditorium C', eventColor: 'orange' },
            {
                id: 'd', type: '460 Bryant', title: 'Auditorium D', children: [
                    { id: 'd1', title: 'Room D1', occupancy: 10 },
                    { id: 'd2', title: 'Room D2', occupancy: 10 }
                ]
            },
            { id: 'e', type: '460 Bryant', title: 'Auditorium E' },
            { id: 'f', type: '460 Bryant', title: 'Auditorium F', eventColor: 'red' },
            { id: 'g', type: '564 Pacific', title: 'Auditorium G' },
            { id: 'h', type: '564 Pacific', title: 'Auditorium H' },
            { id: 'i', type: '564 Pacific', title: 'Auditorium I' },
            { id: 'j', type: '564 Pacific', title: 'Auditorium J' },
            { id: 'k', type: '564 Pacific', title: 'Auditorium K' },
            { id: 'l', type: '564 Pacific', title: 'Auditorium L' },
            { id: 'm', type: '564 Pacific', title: 'Auditorium M' },
            { id: 'n', type: '564 Pacific', title: 'Auditorium N' },
            { id: 'o', type: '564 Pacific', title: 'Auditorium O' },
            { id: 'p', type: '564 Pacific', title: 'Auditorium P' },
            { id: 'q', type: '564 Pacific', title: 'Auditorium Q' },
            { id: 'r', type: '564 Pacific', title: 'Auditorium R' },
            { id: 's', type: '564 Pacific', title: 'Auditorium S' },
            { id: 't', type: '564 Pacific', title: 'Auditorium T' },
            { id: 'u', type: '564 Pacific', title: 'Auditorium U' },
            { id: 'v', type: '564 Pacific', title: 'Auditorium V' },
            { id: 'w', type: '564 Pacific', title: 'Auditorium W' },
            { id: 'x', type: '564 Pacific', title: 'Auditorium X' },
            { id: 'y', type: '564 Pacific', title: 'Auditorium Y' },
            { id: 'z', type: '564 Pacific', title: 'Auditorium Z' }
        ],
        events: '/api/Plannings/GetPlanningsForTwoDays',
        //events: [
        //    {
        //        id: '1', resourceId: 'b', start: '2019-04-07T02:00:00', end: '2019-04-07T07:00:00', title: 'event 1',
        //        constraint: {
        //            resourceIds: ['a', 'b']
        //        }
        //    },
        //    { id: '2', resourceId: 'c', start: '2019-04-07T05:00:00', end: '2019-04-07T22:00:00', title: 'event 2' },
        //    { id: '3', resourceId: 'd', start: '2019-04-06', end: '2019-04-08', title: 'event 3' },
        //    { id: '4', resourceId: 'e', start: '2019-04-07T03:00:00', end: '2019-04-07T08:00:00', title: 'event 4' },
        //    { id: '5', resourceId: 'f', start: '2019-04-07T00:30:00', end: '2019-04-07T02:30:00', title: 'event 5' }
        //],

        resourceLabelText: 'Rooms',
        editable: true,
        droppable: true, // this allows things to be dropped onto the calendar
        drop: function (info) {
            if (info.resource._resource.extendedProps.type == 'Tracteurs')

            console.log(info);
            // is the "remove after drop" checkbox checked?
            if (checkbox.checked) {
                // if so, remove the element from the "Draggable Events" list
                info.draggedEl.parentNode.removeChild(info.draggedEl);
            }
        }


    });



    calendar.dispatch({
        type: 'RESET_RESOURCE_SOURCE',
        resourceSourceInput: [
            { id: 'a', type: 'Chauffeurs', title: 'Chauffeur A' },
            { id: 'b', type: 'Chauffeurs', title: 'Chauffeur B', eventColor: 'green' },
            { id: 'c', type: 'Chauffeurs', title: 'Chauffeur C', eventColor: 'orange' },
            {
                id: 'e', type: 'Chauffeurs', title: 'Chauffeur E', eventColor: 'grey',
                children:
                    [
                        { id: 'g', type: 'Tracteurs', title: 'Tracteur' },
                        { id: 'w', type: 'Remorques', title: 'Remorque' },

                    ]
            },
            { id: 'f', type: 'Chauffeurs', title: 'Chauffeur F', eventColor: 'red' },

            //{ id: 'g', type: 'Tracteurs', title: 'Tracteur 1' },
            //{ id: 'h', type: 'Tracteurs', title: 'Tracteur 2' },
            //{ id: 'i', type: 'Tracteurs', title: 'Tracteur 3' },
            //{ id: 'j', type: 'Tracteurs', title: 'Tracteur 4' },
            //{ id: 'w', type: 'Remorques', title: 'Remorque 1' },
            //{ id: 'x', type: 'Remorques', title: 'Remorque 2' },
            //{ id: 'y', type: 'Remorques', title: 'Remorque 3' },
            //{ id: 'z', type: 'Remorques', title: 'Remorque 4' },
        ]
    });

    calendar.render();

 //       calendar.setOption('resources',
 //[
 //           { id: 'a', type: '1Chauffeurs', title: 'Chauffeur A' },
 //           { id: 'b', type: '1Chauffeurs', title: 'Chauffeur B', eventColor: 'green' },
 //           { id: 'c', type: '1Chauffeurs', title: 'Chauffeur C', eventColor: 'orange' },
 //           { id: 'e', type: '1Chauffeurs', title: 'Chauffeur E' },
 //           { id: 'f', type: '1Chauffeurs', title: 'Chauffeur F', eventColor: 'red' },
 //           { id: 'g', type: 'Tracteurs', title: 'Tracteur 1' },
 //           { id: 'h', type: 'Tracteurs', title: 'Tracteur 2' },
 //           { id: 'i', type: 'Tracteurs', title: 'Tracteur 3' },
 //           { id: 'j', type: 'Tracteurs', title: 'Tracteur 4' },
 //           { id: 'w', type: 'Remorques', title: 'Remorque 1' },
 //           { id: 'x', type: 'Remorques', title: 'Remorque 2' },
 //           { id: 'y', type: 'Remorques', title: 'Remorque 3' },
 //           { id: 'z', type: 'Remorques', title: 'Remorque 4' }
 //       ]

 //   );


});
//CALENDAR-SCHEDULER

