var dataTable;

$(document).ready(function () {
    var url = window.location.search;

    var split = url.split("=");
    var result = split[1];
    switch (result) {
        
        case "inprocess":
            return loadDataTable("GetOrderList?status=inprocess");
        case "pending":
            return loadDataTable("GetOrderList?status=pending");
        case "completed":
            return loadDataTable("GetOrderList?status=completed");
        case "rejected":
            return loadDataTable("GetOrderList?status=rejected");
        default:
            return loadDataTable("GetOrderList?status=all");
    }

    
    
});


function loadDataTable(url) {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/order/" + url
        },
        "columns": [
            { "data": "id", "width": "10%" },
            { "data": "name", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "applicationUser.email", "width": "15%" },
            { "data": "orderStatus", "width": "15%" },
            { "data": "orderTotal", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/Order/Details/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "5%"
            }
        ]
    });
}