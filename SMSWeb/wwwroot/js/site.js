//Toastr Notification//
$(document).ready(function () {
    if (sessionStorage.getItem('showToastr')) {
        toastr.success(sessionStorage.getItem('showToastr'));       
        sessionStorage.removeItem('showToastr');
    }
});



 function addQuestion() {
     const template = document.getElementById("questionContainer");
     const clone = template.firstElementChild.cloneNode(true);


     if (clone)
         template.appendChild(clone);

     //else
     //    document.querySelector(".card").style.display = "block";

 
}



