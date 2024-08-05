function success_msg(str) {
    Swal.fire({
        title: "Good job!",
        text: str + " Successfully",
        icon: "success",
    })
}
function fail_msg(str) {
    Swal.fire({
        title: "Oops...",
        text: str + " Failed",
        icon: "error",
    })
}
function user_alert(str){
    Swal.fire({
        title: "Oops...",
        text: str,
        icon: "warning",
    })
}