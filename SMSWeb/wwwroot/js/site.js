
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

function openCreateModal() {
    fetch(`/Users/Index?handler=CreateModal`)
        .then(response => response.text())
        .then(html => {
            document.getElementById("createContent").innerHTML = html;
            var modal = new bootstrap.Modal(document.getElementById("createModal"));
            modal.show();
        })
        .catch(err => console.log(err));
}

async function openDeleteModal(id) {
   document.getElementById("deleteId").value = id;
    var modal = await new bootstrap.Modal(document.getElementById("deleteModal"));
     modal.show();
}

async function confirmDelete() {
    const data = { id: document.getElementById("deleteId").value };
    var id = document.getElementById("deleteId").value;


    const response = fetch(`https://localhost:7275/api/users/${id}`, {
        method: "DELETE",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });

    //const result = await response.json();
        console.log(response);
  

    //fetch('https://example.com/delete-item/' + id, {
    //    method: 'DELETE',
    //})
    //    .then(res => res.text()) // or res.json()
    //    .then(res => console.log(res))



}


async function saveUser() {
    const user = {
        
        name: document.getElementById("Name").value,
        address: document.getElementById("Address").value,
        phone: document.getElementById("Phone").value,

    };
    try {

        const response = await fetch(`https://localhost:7275/api/users`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(user),
          
        });

        const result = await response.json();
        console.log(result);
      

    } catch (error) {
        console.error(error);
    }
}

async function updateUser(id) {

    const user = {
        id: id,
        name: document.getElementById("Name").value,
        address: document.getElementById("Address").value,
        phone: document.getElementById("Phone").value,
       
    };

    try {

        const response = await fetch(`https://localhost:7275/api/users`, {
            method: "PUT",
            headers: {"Content-Type": "application/json"},
            body: JSON.stringify(user)
        });

        const result = await response.json();
        console.log(result);
        //if (!response.ok) {
        //    throw new Error(repsone.json);
        //}

       

    } catch (error) {
        console.error(error);
    }
}
