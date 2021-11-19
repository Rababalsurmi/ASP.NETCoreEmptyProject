function getAllPeople() {
    $.get("/Ajax/GetPeople", null, function (data) {
        $("#PersonList").html(data);
    });
}

function getPersonById() {
    var personID = document.getElementById('PersonIdInput').value;
    $.post("/Ajax/FindPersonById", { personID: personID }, function (data) {
        $("#PersonList").html(data);
    });
}