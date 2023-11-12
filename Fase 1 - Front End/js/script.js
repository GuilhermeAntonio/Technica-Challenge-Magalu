
function prevalidation() {

    var userValue = document.getElementById("user").value;
    var passwordValue = document.getElementById("password").value;
    var alerta = document.getElementById("alert");

    if (userValue === "" || passwordValue === "") {
        alerta.style.display = "block";
    } else {
        alerta.style.display = "none";
    }
}