$(document).on("change", ".question-type", function () {
    let container = $(this).closest(".question-card").find("#checkboxContainer");

    if ($(this).val() == "3") {
        container.removeAttr("hidden").show();
    }
    else {
        container.hide();
    }
});


let counter = 0;
//function addQuestion(btn) -receives the btn
function addQuestion(id) {

    //const card = $(btn).closest(".question-card"); -getting the question-card which is calling the function
    const newCard = $(".question-card").first().clone();

    counter++;
    newCard.attr("id", "question-card-" + counter);
    newCard.find(".question-input").attr("id", "question-input-" + counter);
    newCard.find(".question-type").attr("id", "question-type-" + counter);


    //clear values
    newCard.find("input").val("Question");
    newCard.find("select").val("");  

    //$("#questionContainer").append(newCard); -appends at the end of the last element of the container always
    $("#"+id).after(newCard);

    //const template = document.getElementById("questionContainer");
    //const clone = template.firstElementChild.cloneNode(true);
    //if (clone)
    //    template.appendChild(clone);
    //else
    //    document.querySelector(".card").style.display = "block";

}

function openPreview()
{
    //This clears only the contents of the div and does not remove the div completely using .remove()
    $("#previewBody").empty(); 

    //.end() ensures that the find() selector reverts back to the cloned #metadata object before it is appended, ensuring the whole container is added, not just the inputs.
    $("#previewBody").append($("#metadata").clone().removeAttr("id").find("input").prop("readonly", true).end()); 

    const questions = $("#questionContainer").clone().removeAttr("id");//removing id of the cloned elements to avoid conflict
    questions.find("div").removeAttr("id");

    //questions.find("select").each(function (index) {
    //    $(this).val($("#questionContainer").find("select").eq(index).val());
    //});

    questions.find("input").prop("readonly", true);
    questions.find("select").hide();
    questions.find("button").hide();

    $("#previewBody").append(questions.addClass("w-100")); //.css("width", "100%")

    const modal = new bootstrap.Modal($("#preview"));
    modal.show();
}



