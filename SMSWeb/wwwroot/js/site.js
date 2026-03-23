//Toastr Notification//
$(document).ready(function () {
    if (sessionStorage.getItem('showToastr')) {
        toastr.success(sessionStorage.getItem('showToastr'));       
        sessionStorage.removeItem('showToastr');
    }
});



 
