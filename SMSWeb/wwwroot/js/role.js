//Create Modal//
async function openCreateModal() {
    try {
        const response = await fetch(`/Roles/Index?handler=CreateModal`);
        const html = await response.text();

        console.log(html);

        document.getElementById("createContent").innerHTML = html;
        var modal =  new bootstrap.Modal(document.getElementById("createModal"));
        modal.show();


    } catch (err) { console.error(err); }
}

//Edit Modal//
async function openEditModal(id) {
    try {
        const response = await fetch(`/Roles/Index?handler=EditModal&id=${id}`);

        const html = await response.text();
        console.log(html);

        document.getElementById("editContent").innerHTML = html;
        var modal = new bootstrap.Modal(document.getElementById("editModal"));
        modal.show();

    } catch (err) { console.error(err); }
}


//Delete Modal//
//async function openDeleteModal(id) {
//    var modal = await new bootstrap.modal()
//}

async function saveRole() {
    const role = {
        name: document.getElementById("Name"),
        summary: document.getElementById("Summary")
    };
    try {
        const response = await fetch(`https://localhost:7275/api/roles`{
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(role)
        });
        const result = await response.json();
        console.log(result);

        if (response.ok) {
            sessionStorage.setItem("showToastr", "Role added successfully");
            window.location.href = "/Roles/Index";
        }
    }
}

