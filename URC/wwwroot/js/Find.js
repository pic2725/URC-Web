$("#keyword").on("keyup", (e) => {
    if (e.key === 'Enter' || e.keyCode === 13) {
        $("#btnPost").trigger("click")
    }
})

$("#btnPost").click(function () {
    var word = $("#keyword").val();

    $.ajax("/Students/Find", {
        type: "POST",
        data: {
            __RequestVerificationToken: gettoken(),
            words: word,
        },
        dataType: "json",
        contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        success: (data, status, xhr) => {
            console.log(data)
            $("#search-result-table > tbody").empty()

            data.forEach(it => {
                $("#search-result-table > tbody")
                    .append(`
                            <tr>
                                <td>
                                    ${it.uid}
                                </td>
                                <td>
                                    ${it.emailAddress}
                                </td>
                                <td>
                                    ${it.gpa}
                                </td>
                                <td>
                                    ${it.studentSkills}
                                </td>
                                <td>
                                    ${it.active}
                                </td>
                                <td>
                                    <a href="/Students/Edit/${it.uid}">Edit</a> |
                                    <a href="/Students/Details/${it.uid}">Details</a> |
                                    <a href="/Students/Delete/${it.uid}">Delete</a>
                                </td>
                            </tr>
                        `)
            })
        },
        error: (jqXhr, textStattus, errorMessage) => {
            console.log(jqXhr, textStattus, errorMessage)
            alert("Fail to update\n" + errorMessage)
        }
    })
})