// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function addCustomer() {

    var actionUrl = "/api/customer";
    var input = document.getElementById('Picture');
    var files = input.files;
    var formData = new FormData();

    for (var i = 0; i != files.length; i++) {
        formData.append("Picture", files[i]);
    }

    formData.append("firstName", $('#FirstName').val());
    formData.append("lastName", $('#LastName').val());
    formData.append("address", $('#Address').val());
    formData.append("email", $('#Email').val());
    formData.append("vatNumber", $('#VatNumber').val());
 
    $.ajax(
        {
            url: actionUrl,
            data: formData,
            processData: false,
            contentType: false,
            type: "POST",
            success: function (data) {
                window.open("/home/customers", "_self")
            },
            error: function (jqXhr, textStatus, errorThrown) {
                alert("Error from server: " + errorThrown);
            }
        }
    );
}




 

function updateCustomer() {
    id = $("#Id").val()

    actionUrl = "/api/customer/"+id
    actiontype = "PUT"
    actionDataType = "json"

    sendData = {
        "firstName": $("#FirstName").val(),
        "lastName": $("#LastName").val(),
        "address": $("#Address").val(),
        "email": $("#Email").val(),
        "vatNumber": $("#VatNumber").val()
    }


    $.ajax({
        url: actionUrl,
        dataType: actionDataType,
        type: actiontype,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,

        success: function (data, textStatus, jQxhr) {

            alert(JSON.stringify(data))

            window.open("/home/customers","_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });

}


function deleteCustomer() {

    id = $("#Id").val()

    actionUrl = "/api/customer/" + id
    actiontype = "DELETE"
    actionDataType = "json"

     $.ajax({
        url: actionUrl,
        dataType: actionDataType,
        type: actiontype,
 
        contentType: 'application/json',
        processData: false,

        success: function (data, textStatus, jQxhr) {

            alert(JSON.stringify(data))
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });
}



function findToUpdateCustomer() {

    id = $("#Id").val()
    actionUrl = "/Home/UpdateCustomerWithDetails/" + id

    window.open(actionUrl, "_self");

}


function searchCustomer() {
    searchText = $("#searchText").val()
    actionUrl = "/Home/SearchCustomersDisplay?text=" + searchText

    window.open(actionUrl, "_self");
}


function buyProduct(ordedId,productId) {

    actionUrl = "/api/Order/" + ordedId + "/product/" + productId
    actiontype = "POST"
    actionDataType = "json"


    $.ajax({
        url: actionUrl,
        dataType: actionDataType,
        type: actiontype,

        contentType: 'application/json',
        processData: false,

        success: function (data, textStatus, jQxhr) {

         //   alert(JSON.stringify(data))

          

            $('#myCart').append('<tr><td>' + JSON.stringify(data)+'</td>/tr>');
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });


}