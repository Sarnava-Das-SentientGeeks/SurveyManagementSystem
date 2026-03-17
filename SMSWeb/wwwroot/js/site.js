

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

async function updateUser(id) {

    const user = {
        id: id,
        name: document.getElementById("Name").value,
        address: document.getElementById("Address").value,
        phone: document.getElementById("Phone").value,
        role: document.getElementById("Role").value
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
