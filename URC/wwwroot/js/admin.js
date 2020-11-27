$(".custom-switch").on("change", (element) => {
    const id = element.target.id
    const temp = id.split("-")
    const username = temp[0]
    const role = temp[1]
    const checked = element.target.checked

    if (checked) {
        $.ajax(`/Role/Add/${username}`, {
            type: "POST",
            data: { newRole: role },
            success: (data, status, xhr) => {
                //Do nothing
            },
            error: (jqXhr, textStattus, errorMessage) => {
                alert("Fail to update\n" + errorMessage)
            }
        })
    }
    else {
        $.ajax(`/Role/Delete/${username}`, {
            type: "DELETE",
            data: { deleteRole: role },
            success: (data, status, xhr) => {
                //Do nothing
            },
            error: (jqXhr, textStattus, errorMessage) => {
                alert("Fail to update\n" + errorMessage)
            }
        })
    }
})