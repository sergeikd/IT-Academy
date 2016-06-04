$(document).ready(function () {
 
    GetAllUsers();
 
    $("#saveUser").click(function (event) {
        event.preventDefault();
        SaveUser();
    });
 
    $("#addUser").click(function (event) {
        event.preventDefault();
        AddUser();
    });
});

function GetAllUsers() {
    $("#createBlock").css('display', 'none');
    $.ajax({
        url: '/api/users',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            WriteResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function AddUser() {
    $("#createBlock").css('display', 'block');
    $("#detailes").css('display', 'none');
}

function SaveUser() {
    var newUser = {
        Name: $('#addName').val(),
        Surname: $('#addSurname').val(),
        Age: $('#addAge').val(),
        Address: $('#addAddress').val()
    };
    $.ajax({
        url: '/api/users',
        type: 'POST',
        data: JSON.stringify(newUser),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllUsers();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function DeleteUser(id) {
    if (confirm("Are you sure?")) {
        $.ajax({
            url: '/api/users/' + id,
            type: 'DELETE',
            contentType: "application/json;charset=utf-8",
            success: function (data) {
                $("#createBlock").css('display', 'none');
                $("#detailes").css('display', 'none');
                GetAllUsers();
            },
            error: function (x, y, z) {
                alert(x + '\n' + y + '\n' + z);
            }
        });
    }
}

function WriteResponse(users) {
    var strResult = "</br><table class='color_table'><th>Имя</th><th>Фамилия</th><th>Детали</th><th>Удалить</th>";
    $.each(users, function (index, user) {
        strResult += "<tr class='colors'><td> " + user.Name + "</td><td>" +
            user.Surname + "</td><td><a id='detailesItem' data-item='" + user.Id + "' onclick='DetailesItem(this);' >Детали</a></td>" +
            "<td><a id='delItem' data-item='" + user.Id + "' onclick='DeleteItem(this);' >Удалить</a></td></tr>";
    });
    strResult += "</table>";
    $("#tableBlock").html(strResult);         
}

function DeleteItem(el) {
    var id = $(el).attr('data-item');
    DeleteUser(id);
}

function DetailesItem(el) {
    $("#createBlock").css('display', 'none');
    $("#detailes").css('display', 'block');
    var id = $(el).attr('data-item');
    $.ajax({
        url: '/api/users/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            ShowDetails(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}
function ShowDetails(details) {
    var strResult = "<h4>Информация о пользователе</h4><div id='detailesContent'>Возраст: " + details.Data.Age + "</br>Адрес: " + details.Data.Address + "</div>";
    $("#detailes").html(strResult);
}