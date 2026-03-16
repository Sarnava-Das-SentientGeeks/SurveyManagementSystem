

function openEditModal(id) { 
    fetch(`/Users/Index?handler=GetById&id=${id}`)
        .then(response => response.text()) 
        .then(html => {
            document.getElementById("editContent").innerHTML = html;
            var modal = new bootstrap.Modal(document.getElementById("editModal"));
            modal.show();
        })
        .catch(err => console.error("Error loading modal:", err));
}