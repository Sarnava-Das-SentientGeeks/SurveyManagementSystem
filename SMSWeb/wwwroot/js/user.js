//Open Edit Modal//
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

//Open Create Modal//
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

//Open Delete Modal//
async function openDeleteModal(id) {
    document.getElementById("deleteId").value = id;
    var modal = await new bootstrap.Modal(document.getElementById("deleteModal"));
    modal.show();
}

//Delete User function//
async function confirmDelete() {
    const data = { id: document.getElementById("deleteId").value };
    var id = document.getElementById("deleteId").value;

    try {

        const response = await fetch(`https://localhost:7275/api/users/${id}`, {
            method: "DELETE",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(data)
        });


        const result = await response.json();
        console.log(result);


        if (response.ok) {
            sessionStorage.setItem("showToastr", "User added successfully");
            window.location.href = `/Users/Index/`;

        }
        else {
            sessionStorage.setItem("showToastr", result.message);
            window.location.href = `/Users/Index/`;
        }


        //fetch('https://example.com/delete-item/' + id, {
        //    method: 'DELETE',
        //})
        //    .then(res => res.text()) // or res.json()
        //    .then(res => console.log(res))
    }
    catch (error) {
        console.error(error);
    }


}

//Save User function//
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
        //This can be used instead of async-await but will await fetch() returns undefined since .then() does not return anything explicitly
        //.then(response => {
        //    if (response.ok) {
        //        window.location.href = `/Users/Index/`;
        //        toastr.success("User added successfully");
        //    }
        //    else {
        //        window.location.href = `/Users/Index/`;
        //        toastr.error(response.json);
        //    }
        //});

        const result = await response.json();
        console.log(result);

        if (response.ok) {

            sessionStorage.setItem("showToastr", "User added successfully");
            window.location.href = `/Users/Index/`;


        }
        else {
            sessionStorage.setItem("showToastr", result.message);
            window.location.href = `/Users/Index/`;
        }



        //if (!response.ok) {
        //    throw new Error(repsone.json);
        //}


    } catch (error) {
        console.error(error);
    }
}

//Update User function//
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
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(user)
        });

        const result = await response.json();
        console.log(result);


        if (response.ok) {
            sessionStorage.setItem("showToastr", "User added successfully");
            window.location.href = `/Users/Index/`;
        }
        else {
            sessionStorage.setItem("showToastr", result.message);
            window.location.href = `/Users/Index/`;
        }


    } catch (error) {
        console.error(error);
    }
}
