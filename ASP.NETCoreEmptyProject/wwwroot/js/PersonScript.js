function getAllPeople() {
    $.get("/Ajax/GetPeople", null, function (data) {
        $("#PersonList").html(data);
    });
}

function getPersonById() {
    var personIDValue = document.getElementById('PersonIdInput').value;
    $.post("/Ajax/FindPersonById", { personID: personIDValue }, function (data) {
        $("#PersonList").html(data);
    });
}