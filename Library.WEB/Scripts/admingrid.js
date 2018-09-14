function deleteRow() {
    $(this).closest("tr").hide("slow");  
}

$(document).ready(function () {
    $("#BookGrid").kendoGrid({
        dataSource: {
            transport: { read: { url: "/Book/GetBooks" } },
            pageSize: 20
        },
        dataBound: onDataBoundBook,  
        sortable: true,
        scrollable: true,
        resizable: true,
        filterable: true,
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },
        columns: [
            {
                field: "Name",
                title: "Name"
            },
            {
                field: "Author",
                title: "Author"
            },
            {
                field: "YearOfPublishing",
                title: "Year Of Publishing"
            },
            {
                field: "PublicationHouses",
                title: "Publication Houses"
            },
            {
                template: "<a href=\"/Book/EditBook/#: ID #\">Edit</a>" + " | " + "<a data-ajax=\"true\" data-ajax-confirm=\"Are sure wants to delete?\" data-ajax-success=\"deleteRow\" href=\"/Book/DeleteBook/#: ID #\">Delete</a>",
                title: "Actions"
            }]
    });
});

function onDataBoundBook() {
    var newWidth = 0;
    var grid = $("#BookGrid").data("kendoGrid");
    for (var i = 0; i < grid.columns.length; i++) {
        grid.autoFitColumn(i);
    }
    $.each(grid.columns, function (i, col) {
        newWidth += grid.table[0].rows[0].cells[i].offsetWidth;
    });
    grid.element.closest(".k-grid").width(newWidth + 17);
}  

$(document).ready(function () {
    $("#BrochureGrid").kendoGrid({
        dataSource: {
            transport: { read: { url: "/Brochure/GetBrochures" } },
            pageSize: 20
        },
        sortable: true,
        scrollable: true,
        resizable: true,
        filterable: true,
        dataBound: onDataBoundBrochure,  
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },
        columns: [
            {
                field: "Name",
                title: "Name",
            },
            {
                field: "TypeOfCover",
                title: "Type Of Cover"
            },
            {
                field: "NumberOfPages",
                title: "Number Of Pages"
            },
            {
                template: "<a href=\"/Brochure/EditBrochure/#: ID #\">Edit</a>" + " | " + "<a data-ajax=\"true\" data-ajax-confirm=\"Are sure wants to delete?\" data-ajax-success=\"Delete\" href=\"/Brochure/DeleteBrochure/#: ID #\">Delete</a>",
                title: "Actions"
            }]
    });
});

function onDataBoundBrochure() {
    var newWidth = 0;
    var grid = $("#BrochureGrid").data("kendoGrid");
    for (var i = 0; i < grid.columns.length; i++) {
        grid.autoFitColumn(i);
    }
    $.each(grid.columns, function (i, col) {
        newWidth += grid.table[0].rows[0].cells[i].offsetWidth;
    });
    grid.element.closest(".k-grid").width(newWidth + 17);
}  

$(document).ready(function () {
    $("#MagazineGrid").kendoGrid({
        dataSource: {
            transport: { read: { url: "/Magazine/GetMagazines" } },
            pageSize: 20
        },
        sortable: true,
        scrollable: true,
        resizable: true,
        filterable: true,
        dataBound: onDataBoundMagazine, 
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },
        columns: [
            {
                field: "Name",
                title: "Name",
            },
            {
                field: "Number",
                title: "Number"
            },
            {
                field: "YearOfPublishing",
                title: "Year Of Publishing"
            },
            {
                template: "<a href=\"/Magazine/EditMagazine/#: ID #\">Edit</a>" + " | " + "<a data-ajax=\"true\" data-ajax-confirm=\"Are sure wants to delete?\" data-ajax-success=\"Delete\" href=\"/Magazine/DeleteMagazine/#: ID #\">Delete</a>",
                title: "Actions"
            }]
    });
});

function onDataBoundMagazine() {
    var newWidth = 0;
    var grid = $("#MagazineGrid").data("kendoGrid");
    for (var i = 0; i < grid.columns.length; i++) {
        grid.autoFitColumn(i);
    }
    $.each(grid.columns, function (i, col) {
        newWidth += grid.table[0].rows[0].cells[i].offsetWidth;
    });
    grid.element.closest(".k-grid").width(newWidth + 17);
}

$(document).ready(function () {
    $("#HouseGrid").kendoGrid({
        dataSource: {
            transport: { read: { url: "/PublicationHouse/GetPublicationHouses" } },
            pageSize: 20
        },
        sortable: true,
        scrollable: true,
        resizable: true,
        filterable: true,
        dataBound: onDataBoundHouse, 
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },
        columns: [
            {
                field: "Name",
                title: "Name",
            },
            {
                field: "Adress",
                title: "Adress"
            },
            {
                field: "Books",
                title: "Books"
            },
            {
                template: "<a href=\"/PublicationHouse/EditPublicationHouse/#: ID #\">Edit</a>" + " | " + "<a data-ajax=\"true\" data-ajax-confirm=\"Are sure wants to delete?\" data-ajax-success=\"Delete\" href=\"/PublicationHouse/DeletePublicationHouse/#: ID #\">Delete</a>",
                title: "Actions"
            }]
    });
});

function onDataBoundHouse() {
    var newWidth = 0;
    var grid = $("#HouseGrid").data("kendoGrid");
    for (var i = 0; i < grid.columns.length; i++) {
        grid.autoFitColumn(i);
    }
    $.each(grid.columns, function (i, col) {
        newWidth += grid.table[0].rows[0].cells[i].offsetWidth;
    });
    grid.element.closest(".k-grid").width(newWidth + 17);
}

$(document).ready(function () {
    $("#grid").kendoGrid({
        dataSource: {
            transport: { read: { url: "/Publication/GetPublications" } },
            pageSize: 20
        },
        sortable: true,
        scrollable: true,
        resizable: true,
        filterable: true,
        dataBound: onDataBoundPublication, 
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },
        columns: [
            {
                field: "Name",
                title: "Name",
            },
            {
                field: "Type",
                title: "Type"
            }]
    });
});

function onDataBoundPublication() {
    var newWidth = 0;
    var grid = $("#grid").data("kendoGrid");
    for (var i = 0; i < grid.columns.length; i++) {
        grid.autoFitColumn(i);
    }
    $.each(grid.columns, function (i, col) {
        newWidth += grid.table[0].rows[0].cells[i].offsetWidth;
    });
    grid.element.closest(".k-grid").width(newWidth + 30);
}

$(document).ready(function () {
    $('#AddPublicationHousesIds').kendoMultiSelect({
        placeholder: "Select houses...",
        name: "PublicationHousesIds",
        dataSource: {
            serverFiltering: true,
            transport: {
                read: {
                    url: "/Book/GetPublicationHouses"
                }
            }
        },
        dataTextField: "Name",
        dataValueField: "Id",
        autoBind: false
    });
});
