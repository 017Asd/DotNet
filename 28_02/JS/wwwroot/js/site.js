function loadData() {

    fetch("/api/PostApi")
        .then(response => response.json())
        .then(data => {

            let html = "";

            data.forEach(post => {
                html += `<h3>${post.title}</h3>
                         <p>${post.body}</p>`;
            });

            document.getElementById("result").innerHTML = html;
        })
        .catch(error => {
            console.error(error);
            document.getElementById("result").innerHTML = "Error loading API";
        });
    document.addEventListener("DOMContentLoaded", function () {

    fetch("/api/PostApi")
        .then(response => response.json())
        .then(data => {

            const dropdown = document.getElementById("todoDropdown");

            data.forEach(todo => {
                let option = document.createElement("option");
                option.value = todo.id;
                option.text = todo.title;
                option.dataset.completed = todo.completed;
                dropdown.appendChild(option);
            });
        });

    document.getElementById("todoDropdown")
        .addEventListener("change", function () {

            const selected = this.options[this.selectedIndex];

            if (selected.value === "") return;

            document.getElementById("todoDetails").innerHTML =
                `<p><strong>ID:</strong> ${selected.value}</p>
                 <p><strong>Title:</strong> ${selected.text}</p>
                 <p><strong>Completed:</strong> ${selected.dataset.completed}</p>`;
        });
});
}