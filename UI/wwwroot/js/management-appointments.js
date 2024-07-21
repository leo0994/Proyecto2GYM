import createModal from "./components/modal.js";
import { Appointment } from "./entities/Appointments.js";
import { validateForm } from "./helpers.js";

// Make a refactor because this code is trash

(function () {
    let appointmentsData = [];
    let selectedRowId = null;

    // Fetch appointments data from API
    async function fetchAppointments() {
        try {
            const response = await fetch("http://localhost:5049/api/Appointment/RetrieveAll");
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
        const tableBody = document.getElementById('appointmentTable').querySelector('tbody');
        tableBody.innerHTML = '';
        data.forEach(appointment => {
            const row = document.createElement('tr');
            row.dataset.appointmentid = appointment.id;
            row.innerHTML = `
                <td>${appointment.id}</td>
                <td>${new Date(appointment.date).toLocaleString()}</td>
                <td>${appointment.userAName}</td>
                <td>${appointment.userBName}</td>
                <td>${appointment.userAId}</td>
                <td>${appointment.userBId}</td>
            `;
            // row.addEventListener('click', () => onRowClick(appointment.id));
            tableBody.appendChild(row);
        });
        document.getElementById('appointmentTable').addEventListener('click', onRowClick);
    }

    // Display message
    function displayMessage(message, type) {
        const messageDiv = document.getElementById('message');
        messageDiv.textContent = message;
        messageDiv.className = 'message ' + type;
    }

    // Refresh table data

    async function refreshTable() {
        displayMessage('Loading...', 'loading');
        try {
            const response = await fetchAppointments();
            if (!response?.success) {
                throw Error(response.message);
            }
            appointmentsData = response.data;
            renderTable(response.data);
            displayMessage('Data loaded successfully', 'success');
        } catch {
            displayMessage('Error loading data', 'error');
        }
    }

    function applyFilters() {
        const filterDate = document.getElementById('filterDate').value;
        const searchId = document.getElementById('searchId').value;

        const filteredData = appointmentsData.filter(appointment => {
            const matchDate = filterDate ? appointment.date.startsWith(filterDate) : true;
            const matchId = searchId ? appointment.id.toString().includes(searchId) : true;
            return matchDate && matchId;
        });

        renderTable(filteredData);
    }

    // Handle row click
    function onRowClick(e) {
        if (document.querySelector("tr[data-selected]")) {
            document.querySelector("tr[data-selected]").style.opacity = 1;
            delete document.querySelector("tr[data-selected]").dataset.selected;
        }

        const row = e.target?.closest("tr[data-appointmentid]");
        if (row) {
            selectedRowId = row.dataset.appointmentid;
            row.dataset.selected = "";
            row.style.opacity = 0.2;
            return
        }
        selectedRowId = null;
    }

    // Event listeners for filters
    document.getElementById('filterDate').addEventListener('input', applyFilters);
    document.getElementById('searchId').addEventListener('input', applyFilters);

    document.querySelector("#deleteBtn").addEventListener("click", deleteAppointment);

    document.querySelector(".appointments-inventory #refresh").addEventListener("click", refreshTable);


    async function deleteAppointment(e) {
        try {
            e.target.setAttribute("disabled", "");
            const appointment = { ...Appointment };
            appointment.id = selectedRowId;
            const response = await fetch(`http://localhost:5049/api/Appointment/Delete`, {
                method: "DELETE",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(appointment),
            }).then(res => res.json());

            e.target.removeAttribute("disabled", "");

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
                            <h2 style="padding-left: 12px" class="">Success!</h2>
                        </div>
                        <br>
                        <p style="font-size: 14px">${response.message}</p>
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

    const btnUpdateAppoinment = formMain?.querySelector("[data-create] [data-update-appoinment]");
    const btnCreateAppoinment = formMain?.querySelector("[data-update] [data-create-appoinment]");

    btnUpdateAppoinment?.addEventListener("click", (e) => {
        e.preventDefault()
        formMain.dataset.stateForm = "update";
    });
    btnCreateAppoinment.addEventListener("click", (e) => {
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
            const inputsList = Array.from(currentGroupForm.querySelectorAll("input,select"));
            const inputsListErrors = validateForm(inputsList);

            if (Object.keys(inputsListErrors).length > 0) {
                showErrorUI(inputsList, inputsListErrors);
                return
            }

            submitter.setAttribute("disabled", "");

            switch (currentForm) {
                case "create":
                    handleCreateAppoinmentRequest(inputsList);
                    break;
                case "update":
                    handleUpdateAppoinmentRequest(inputsList);
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

    async function handleCreateAppoinmentRequest(inputsList) {
        try {
            const appoinmentData = composeUserEntity(inputsList);
            const response = await fetchCreateAppoinment(appoinmentData);
            submitter.removeAttribute("disabled", "");
            resetForm();
            
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
                        <h2 style="padding-left: 12px" class="">Appoinment created</h2>
                    </div>
                    <br>
                    <p style="font-size: 14px">Appointment created my friend. have a good day!!</p>
                </div>
            `);
            refreshTable();
            return;
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


    async function handleUpdateAppoinmentRequest(inputsList) {
        try {
            const appoinmentData = composeUserEntity(inputsList);
            const response = await fetchUpdateAppoinment(appoinmentData);
            submitter.removeAttribute("disabled", "");
            resetForm();
            
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
                        <h2 style="padding-left: 12px" class="">Appoinment updated</h2>
                    </div>
                    <br>
                    <p style="font-size: 14px">Appointment updated my friend. have a good day!!</p>
                </div>
            `);
            refreshTable();
            return;
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

    async function fetchUpdateAppoinment(appoinment) {
        const response = await fetch("http://localhost:5049/api/Appointment/Update", {
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(appoinment),
        }).then(res => res.json());
        return response;
    }
    
    async function fetchCreateAppoinment(appoinment) {
        const response = await fetch("http://localhost:5049/api/Appointment/Create", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(appoinment),
        }).then(res => res.json());
        return response;
    }

    function composeUserEntity(inputs) {
        const user = { ...Appointment };
        inputs.forEach((input) => {
            console.log(input, user)
            if (input?.name in user) {
                user[input?.name] = input?.value;
            }
        });
        return user;
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
