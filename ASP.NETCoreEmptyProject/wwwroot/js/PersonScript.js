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

function deletePersonById() {
    var personIDValue = document.getElementById('PersonIdInput').value;

    $.post("/Ajax/DeletePersonById", { personID: personIDValue }, function (data) {

    })
        .done(function () {
            document.getElementById('errorMessages').innerHTML = "Person is successfully Deleted.";
            getAllPeople();
        })
        .fail(function () {
            document.getElementById('errorMessages').innerHTML = "Failed to delete the person.";

        });
        
}