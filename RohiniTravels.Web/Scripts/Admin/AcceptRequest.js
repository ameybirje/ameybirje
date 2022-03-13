
$(document).ready(function() {

    var students ;

    var requiredFields = { 'url': getGridData_URL, 'data': null, 'successFunction': fnGridDataSec, 'errorFunction': Error };
    WebxCommonFN.AjaxPostRequestError(requiredFields);

    function fnGridDataSec(data) {

        debugger;

        if (data.Success) {
            alert('calling');
            students = JSON.stringify(data.StudendData);

        }

    }

    $("#grid").igGrid({
        columns: [
            { headerText: "First Name", key: "FirstName", dataType: "string" },
            //{ headerText: "Middle Name", key: "MiddleName", dataType: "string" },
            //{ headerText: "Last Name", key: "LastName", dataType: "string" },
            //{ headerText: "Gender", key: "Gender", dataType: "string" },
            //{ headerText: "Parent Name", key: "ParentName", dataType: "string" },
            //{ headerText: "Parent Mobile", key: "ParentMobile", dataType: "string" },
            //{ headerText: "Address", key: "Address", dataType: "string" },
            //{ headerText: "Pincode", key: "Pincode", dataType: "number" },
            {
                headerText: "",
                key: "View",
                dataType: "string",
                width: "20%",
                unbound: true,
                template: "<input type='button'  value='View' />"
            }
        ],
        features: [
            {
                name: "Paging",
                type: "local",
                pageSize: 5
            },
            {
                name: "Sorting",
                type: "local",
                columnSettings: [
                    { columnKey: "Delete", allowFiltering: false }

                ]
            },
            {
                name: "Filtering",
                columnSettings: [
                    { columnKey: "Delete", allowFiltering: false }

                ]
            }
            ,
            {
                name: "RowSelectors"
            },
            {
                name: "Selection"
            }
        ],
        width: "auto",
        dataSource: students
    });


})