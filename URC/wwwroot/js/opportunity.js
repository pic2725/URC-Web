//   Author:    Daniel Pak & Kyungyoon Kim
//   Date:      August 28th, 2020
//   Course:    CS 4540, University of Utah, School of Computing
//   Copyright: CS 4540, Kyungyoon Kim and Daniel Pak - This work may not be copied for use in Academic Coursework.

//   We, Kyungyoon Kim and Daniel Pak, certify that I wrote this code from scratch and did not copy it in part or whole from
//   another source.  Any references used in the completion of the assignment are cited in my README file.

//   File Contents

//      Opportunity Detail Page

function onAssociatedImagSelected(element) {
    const img = element.files[0]

    if (!img) {
        alert("Cannot access the choosen image.")
        return
    }

    if (!img['type'].startsWith('image/')) {
        alert("The Choosen file is not image.")
        return
    }

    const reader = new FileReader()
    reader.onloadend = () => {
        $("#AssociatedIamgLabel").text(img.name)
        $("#AssociatedImag").val(reader.result)
        $("#AssociatedImagPreviewWarpper").removeAttr("hidden")
        $("#AssociatedImagPreview").attr("src", reader.result)
    }
    reader.readAsDataURL(img)
}

function onDeleteImage() {
    $("#AssociatedIamgLabel").text("Choose file to update")
    $("#AssociatedImag").val(null)
    $("#AssociatedImagPreviewWarpper").Attr("hidden")
    $("#AssociatedImagPreview").attr("src", "")
}