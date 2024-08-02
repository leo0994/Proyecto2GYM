import createModal from "./components/modal.js";
import { validateForm } from "./helpers.js";

// Make a refactor because this code is trash

(function () {
    let activitiesData = [];
    let selectedRowId = null;

    // Fetch appointments data from API
    async function fetchActivities() {
        try {
            const response = await fetch("http://localhost:5049/api/ClassActivity");
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            const data = await response.json();
            return data;
        } catch (error) {
            displayMessage('Error fetching data: ' + error.message, 'error');
            throw error;
        }
    }

    // Render the appointments table
    function renderTable(data) {
        const tableBody = document.getElementById('activitiesTable').querySelector('tbody');
        tableBody.innerHTML = '';
        data.forEach(activity => {
            const row = document.createElement('tr');
            row.dataset.activityid = activity.id;
            row.innerHTML = `
                <td>${activity.id}</td>
                <td>${activity.name}</td>
                <td>${activity.description}</td>
                <td>${activity.image_url}</td>
                <td>${activity.instructor}</td>
                <td>${activity.nameInstructor}</td>
                <td>${activity.dayOfWeek}</td>
                <td>${new Date('1970-01-01T' + activity.hour + 'Z').toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })}</td>
                <td>${activity.capacity}</td>
            `;
            // row.addEventListener('click', () => onRowClick(appointment.id));
            tableBody.appendChild(row);
        });
        document.getElementById('activitiesTable').addEventListener('click', onRowClick);
    }

    // Display message
    function displayMessage(message, type) {
        const messageDiv = document.getElementById('message');
        messageDiv.textContent = message;
        messageDiv.className = 'message ' + type;
        if(type == "error") document.querySelector("#deleteBtn").style.display = 'none';
    }

    // Refresh table data

    async function refreshTable() {
        displayMessage('Loading...', 'loading');
        try {
            const response = await fetchActivities();
            if (!response?.success) {
                throw Error(response.message);
            }
            activitiesData = response.data;
            renderTable(response.data);
            displayMessage('Data loaded successfully', 'success');
        } catch {
            displayMessage('Error loading data', 'error');
        }
    }

    function applyFilters() {
        // const filterTime = document.getElementById('filterTime').value;
        const searchId = document.getElementById('searchId').value;
    
        const filteredData = activitiesData.filter(activity => {
            // const matchTime = filterTime ? activity.hour.startsWith(filterTime) : true;
            const matchId = searchId ? activity.id.toString().includes(searchId) : true;
            return matchId;
        });
    
        renderTable(filteredData);
    }

    // Handle row click
    function onRowClick(e) {
        if (document.querySelector("tr[data-selected]")) {
            document.querySelector("tr[data-selected]").style.opacity = 1;
            delete document.querySelector("tr[data-selected]").dataset.selected;
        }

        const row = e.target?.closest("tr[data-activityid]");
        if (row) {
            selectedRowId = row.dataset.activityid;
            row.dataset.selected = "";
            row.style.opacity = 0.2;
            return
        }
        selectedRowId = null;
    }

    // Event listeners for filters
    // document.getElementById('filterTime').addEventListener('input', applyFilters);
    document.getElementById('searchId').addEventListener('input', applyFilters);

    document.querySelector("#deleteBtn").addEventListener("click", deleteActivity);

    document.querySelector(".activities-inventory #refresh").addEventListener("click", refreshTable);


    async function deleteActivity(e) {
        try {
            if(!selectedRowId){
               throw Error("Error Deleting, didn't select row");
            }
            e.target.setAttribute("disabled", "");
            await fetch(`http://localhost:5049/api/ClassActivity/${selectedRowId}`, {
                method: "DELETE",
                headers: {
                    "Content-Type": "application/json",
                }
            });

            e.target.removeAttribute("disabled", "");

            createModal(`
                    <div style="text-align: center;">
                        <div style="display: flex; justify-content: center; color: #1e5603">
                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-circle-alert h-4 w-4"><circle cx="12" cy="12" r="10"></circle><line x1="12" x2="12" y1="8" y2="12"></line><line x1="12" x2="12.01" y1="16" y2="16"></line></svg>
                            <h2 style="padding-left: 12px" class="">Success!</h2>
                        </div>
                        <br>
                        <p style="font-size: 14px">Activity deleted</p>
                    </div>
                `);
            refreshTable();
        } catch (error) {
            console.log(error)
            e.target.removeAttribute("disabled", "");
            createModal(`
                <div style="text-align: center;">
                    <div style="display: flex; justify-content: center; color: #a70000">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-circle-alert h-4 w-4"><circle cx="12" cy="12" r="10"></circle><line x1="12" x2="12" y1="8" y2="12"></line><line x1="12" x2="12.01" y1="16" y2="16"></line></svg>
                        <h2 style="padding-left: 12px" class="">Error</h2>
                    </div>
                    <br>
                    <p style="font-size: 14px">Something wrong happened, please try it again.</p>
                </div>
            `);
        }
    }

    // Initial load
    refreshTable();

    const formMain = document.querySelector("[data-form]");
    const submitter = formMain?.querySelector('[type="submit"]');

    const btnUpdateActivity = formMain?.querySelector("[data-create] [data-update-activity]");
    const btnCreateActivity = formMain?.querySelector("[data-update] [data-create-activity]");

    btnUpdateActivity?.addEventListener("click", (e) => {
        e.preventDefault()
        formMain.dataset.stateForm = "update";
    });
    btnCreateActivity.addEventListener("click", (e) => {
        e.preventDefault()
        formMain.dataset.stateForm = "create";
    });

    formMain?.addEventListener("submit", handleSubmit);
    formMain?.addEventListener("change", handleChange);


    function handleChange(e) {
        cleanHelpMessagesInputs();
    }

    function cleanHelpMessagesInputs() {
        formMain.querySelectorAll(".form-help-text.error")?.forEach((span) => {
            span.innerText = "";
        });
    }

    async function handleSubmit(e) {
        try {
            e.preventDefault();
            const currentForm = e.target.dataset.stateForm;
            const currentGroupForm = e.target.querySelector(`[data-${currentForm}]`);
            const inputsList = Array.from(currentGroupForm.querySelectorAll("input,select,textarea"));
            const inputsListErrors = validateForm(inputsList);

            if (Object.keys(inputsListErrors).length > 0) {
                showErrorUI(inputsList, inputsListErrors);
                return
            }

            submitter.setAttribute("disabled", "");

            switch (currentForm) {
                case "create":
                    handleCreateActivityRequest(inputsList);
                    break;
                case "update":
                    handleUpdateActivityRequest(inputsList);
                    break;
                default:
                    break;
            }

        } catch (error) {
            console.log(error)
            submitter.removeAttribute("disabled", "");
            createModal(`
                <div style="text-align: center;">
                    <div style="display: flex; justify-content: center; color: #a70000">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-circle-alert h-4 w-4"><circle cx="12" cy="12" r="10"></circle><line x1="12" x2="12" y1="8" y2="12"></line><line x1="12" x2="12.01" y1="16" y2="16"></line></svg>
                        <h2 style="padding-left: 12px" class="">Error</h2>
                    </div>
                    <br>
                    <p style="font-size: 14px">Something wrong happened, please try it again.</p>
                </div>
            `);
        }

    }

    async function handleCreateActivityRequest(inputsList) {
        try {
            const activityData = composeFormData(inputsList);
            const response = await fetchCreateActivity(activityData);
            submitter.removeAttribute("disabled", "");

            if (!response.success) {
                createModal(`
                    <div style="text-align: center;">
                    <div style="display: flex; justify-content: center; color: #a70000">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-circle-alert h-4 w-4"><circle cx="12" cy="12" r="10"></circle><line x1="12" x2="12" y1="8" y2="12"></line><line x1="12" x2="12.01" y1="16" y2="16"></line></svg>
                        <h2 style="padding-left: 12px" class="">Error</h2>
                    </div>
                    <br>
                    <p style="font-size: 14px">${response.message}</p>
                    </div>
                `);
                return;
            }
            createModal(`
                <div style="text-align: center;">
                    <div style="display: flex; justify-content: center; color: #1e5603">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-circle-alert h-4 w-4"><circle cx="12" cy="12" r="10"></circle><line x1="12" x2="12" y1="8" y2="12"></line><line x1="12" x2="12.01" y1="16" y2="16"></line></svg>
                        <h2 style="padding-left: 12px" class="">Activity created</h2>
                    </div>
                    <br>
                    <p style="font-size: 14px">Activity created my friend. have a good day!!</p>
                </div>
            `);
            refreshTable();
            resetForm();
        } catch (error) {
            submitter.removeAttribute("disabled", "");
            createModal(`
                <div style="text-align: center;">
                    <div style="display: flex; justify-content: center; color: #a70000">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-circle-alert h-4 w-4"><circle cx="12" cy="12" r="10"></circle><line x1="12" x2="12" y1="8" y2="12"></line><line x1="12" x2="12.01" y1="16" y2="16"></line></svg>
                        <h2 style="padding-left: 12px" class="">Error</h2>
                    </div>
                    <br>
                    <p style="font-size: 14px">Something wrong happened, please try it again.</p>
                </div>
            `);
        }
    }

    async function handleUpdateActivityRequest(inputsList) {
        try {
            const activityData = composeFormData(inputsList);
            const response = await fetchUpdateActivity(activityData);
            submitter.removeAttribute("disabled", "");

            if (!response.success) {
                createModal(`
                    <div style="text-align: center;">
                    <div style="display: flex; justify-content: center; color: #a70000">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-circle-alert h-4 w-4"><circle cx="12" cy="12" r="10"></circle><line x1="12" x2="12" y1="8" y2="12"></line><line x1="12" x2="12.01" y1="16" y2="16"></line></svg>
                        <h2 style="padding-left: 12px" class="">Error</h2>
                    </div>
                    <br>
                    <p style="font-size: 14px">${response.message}</p>
                    </div>
                `);
                return;
            }
            createModal(`
                <div style="text-align: center;">
                    <div style="display: flex; justify-content: center; color: #1e5603">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-circle-alert h-4 w-4"><circle cx="12" cy="12" r="10"></circle><line x1="12" x2="12" y1="8" y2="12"></line><line x1="12" x2="12.01" y1="16" y2="16"></line></svg>
                        <h2 style="padding-left: 12px" class="">Activity updated</h2>
                    </div>
                    <br>
                    <p style="font-size: 14px">Activity created my friend. have a good day!!</p>
                </div>
            `);
            refreshTable();
            resetForm();
        } catch (error) {
            submitter.removeAttribute("disabled", "");
            createModal(`
                <div style="text-align: center;">
                    <div style="display: flex; justify-content: center; color: #a70000">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-circle-alert h-4 w-4"><circle cx="12" cy="12" r="10"></circle><line x1="12" x2="12" y1="8" y2="12"></line><line x1="12" x2="12.01" y1="16" y2="16"></line></svg>
                        <h2 style="padding-left: 12px" class="">Error</h2>
                    </div>
                    <br>
                    <p style="font-size: 14px">Something wrong happened, please try it again.</p>
                </div>
            `);
        }
    }

    async function fetchUpdateActivity(activity) {
        const response = await fetch("http://localhost:5049/api/ClassActivity", {
            method: "PUT",
            dataType: "application/ json",
            mimeType: "multipart / form - data",
            body: activity,
        }).then(res => res.json());
        return response;
    }

    async function fetchCreateActivity(activity) {
        const response = await fetch("http://localhost:5049/api/ClassActivity", {
            method: "POST",
            dataType: "application/ json",
            mimeType: "multipart / form - data",
            body: activity,
        }).then(res => res.json());
        return response;
    }

    function composeFormData(inputs) {
        const formData = new FormData();
        inputs.forEach(input => {
            const { name, type, files, value, checked } = input;

            if (!name) return; // Skip elements without a name attribute

            if (type === 'file') {
                if (files.length > 0) {
                    formData.append(name, files[0]); // Only handle the first file if multiple are not allowed
                }
            } else if (type === 'checkbox' || type === 'radio') {
                if (checked) {
                    formData.append(name, value);
                }
            } else {
                formData.append(name, value);
            }
        });
        return formData;
    }

    function resetForm() {
        formMain.reset();
    }

    function showErrorUI(inputs, errors) {
        inputs.forEach(input => {
            if (errors[input.name]) {
                const helpText = input.closest(".form-group")?.querySelector(".form-help-text");
                helpText.innerText = errors[input.name];
            }
        });
    }
})()
