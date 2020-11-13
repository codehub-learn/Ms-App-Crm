// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function addCustomer() {
    actionUrl = "/api/customer"
    actiontype ="POST"
    actionDataType   ="json"

    sendData = {
        "firstName":$("#FirstName").val(),
        "lastName": $("#LastName").val(),
        "address": $("#Address").val(),
        "email": $("#Email").val(),
        "vatNumber": $("#VatNumber").val()
    }


    $.ajax({
        url:actionUrl,
        dataType:actionDataType,
        type: actiontype,
        data: JSON.stringify(sendData),
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