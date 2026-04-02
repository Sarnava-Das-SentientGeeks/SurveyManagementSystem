//Gloabl JSON object
const survey = {
    title: "Untitled Form",
    description: "Form Description",
    questions: []
};

//rendering UI when DOM is ready
$(document).ready(function () {
    survey.questions.push({
        id: Date.now(),
        type: "text",
        label: "Question",
        options: []
    });

    renderUI();
});

function renderUI() {
    $("#metadataContainer").html(`
        <div class = "card mb-3">
            <div class = "card-header">
                <input class="form-control survey-title mb-2" value="${survey.title}" />
            </div>
            <div class = "card-body">
               <input class="form-control survey-description mb-2" value="${survey.description}" />
            </div>
        </div>
    `);

    renderQuestions();

}

function renderQuestions() {
    let html = "";

    survey.questions.forEach((q, index) => {
        html += `
        <div class="card border-secondary mb-3 question-card" data-index="${index}">
            <div class="card-body">

                <div class="row">
                    <div class="col-6">
                        <input class="form-control question-input" value="${q.label}" />
                    </div>

                    <div class="col-6">
                        <select class="form-select question-type">
                            <option value="text" ${q.type === "text" ? "selected" : ""}>Short text</option>
                            <option value="radio" ${q.type === "radio" ? "selected" : ""}>Multiple Choice</option>
                            <option value="checkbox" ${q.type === "checkbox" ? "selected" : ""}>Checkboxes</option>
                        </select>
                    </div>
                </div>

                <div class="mt-3 option-container" ${q.type === "text" ? "hidden" : ""}>
                    ${renderOptions(q)}
                </div>

                <button onclick="addQuestionAt(${index})"><i class="bi bi-plus-circle-fill"></i></button>
                <button onclick="deleteQuestion(${index})"><i class="bi bi-trash-fill"></i></button>

            </div>
        </div>`;
    });

    $("#questionContainer").html(html);
}


function renderOptions(q, qIndex) {
    if (!q.options) return "";

    return q.options.map((opt, optIndex) => `
        <div class="d-flex mb-2 align-items-center">
            <input type="${q.type === "radio" ? "radio" : "checkbox"}" disabled class="me-2"/>

            <input type="text" 
                   class="form-control option-input"
                   value="${opt}"
                   data-qindex="${qIndex}"
                   data-optindex="${optIndex}" />

            <button class="btn btn-sm btn-danger ms-2"
                    onclick="deleteOption(${qIndex}, ${optIndex})">
                ✖
            </button>
        </div>
    `).join("") +

        `<button class="btn btn-sm btn-primary mt-2" onclick="addOption(${qIndex})">
        <i class="bi bi-plus-circle-fill"></i> Add Option
     </button>`;
}

function addQuestionAt(index) {
    survey.questions.splice(index + 1, 0, {
        id: Date.now(),
        type: "text",
        label: "New Question",
        options: []
    });

    renderQuestions();
}

function deleteQuestion(index) {
    survey.questions.splice(index, 1);

    // Prevent empty form (optional but recommended)
    if (survey.questions.length === 0) {
        survey.questions.push({
            id: Date.now(),
            type: "text",
            label: "Question",
            options: []
        });
    }

    renderQuestions();
}


$(document).on("input", ".survey-title", function () {
    survey.title = this.value;
});

$(document).on("input", ".survey-description", function () {
    survey.description = this.value;
});

$(document).on("change", ".question-type", function () {
    const index = $(this).closest(".question-card").data("index");
    const type = $(this).val();

    survey.questions[index].type = type;

    // Initialize options when needed
    if (type === "radio" || type === "checkbox") {
        if (!survey.questions[index].options || survey.questions[index].options.length === 0) {
            survey.questions[index].options = ["Option 1"];
        }
    } else {
        survey.questions[index].options = [];
    }

    renderQuestions();
});