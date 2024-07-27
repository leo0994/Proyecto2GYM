import createModal from "./components/modal.js";
import User from "./entities/User.js";
import { validateForm } from "./helpers.js";

(function () {
    const formMain = document.querySelector("[data-form]");
    const submitter = formMain?.querySelector('[type="submit"]');

    const btnResendCode = formMain?.querySelector("[data-validate-code] [data-resent-code]");

    btnResendCode?.addEventListener("click", resendValidationCode);
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

    async function handleSignUpRequest(inputsList) {
        try {
            const userData = composeUserEntity(inputsList);
            userData.dateOfBirth = new Date(userData.dateOfBirth);
            const response = await fetchRegistryUser(userData);

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

            if (response?.data?.verificationResource.status == "pending") {
                formMain.dataset.stateForm = "validate-code";
                sessionStorage.setItem("validating-code-new-user", JSON.stringify(response.data.user));
                return
            }

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
                case "signup":
                    handleSignUpRequest(inputsList);
                    break;
                case "validate-code":
                    validateCodeValidation(inputsList);
                    break;
                default:
                    break;
            }
            resetForm();

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

    async function fetchRegistryUser(user) {
        const response = await fetch("http://localhost:5049/api/auth/signup", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(user),
        }).then(res => res.json());

        return response;
    }

    function composeUserEntity(inputs) {
        const user = { ...User };
        inputs.forEach((input) => {
            console.log(input, user)
            if (input?.name in user) {
                user[input?.name] = input?.value;
            }
        });
        return user;
    }

    async function validateCodeValidation(inputs) {
        try {
            const userData = sessionStorage.getItem("validating-code-new-user");
            const response = await await fetch(`http://localhost:5049/api/auth/sign-up-verification?code=${inputs[0].value}`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: userData,
            }).then(res => res.json());

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

            if (response?.data?.status == "approved") {
                formMain.dataset.stateForm = "signup";
                createModal(`
                    <div style="text-align: center;">
                        <div style="display: flex; justify-content: center; color: #1e5603">
                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-circle-alert h-4 w-4"><circle cx="12" cy="12" r="10"></circle><line x1="12" x2="12" y1="8" y2="12"></line><line x1="12" x2="12.01" y1="16" y2="16"></line></svg>
                            <h2 style="padding-left: 12px" class="">Registered user</h2>
                        </div>
                        <br>
                        <p style="font-size: 14px">User registered, please login using your new credentials</p>
                    </div>
                `);
                sessionStorage.removeItem("validating-code-new-user");
                return
            }

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

    async function resendValidationCode(e) {
        try {
            e.preventDefault();
            submitter.setAttribute("disabled", "");
            const user = sessionStorage.getItem("validating-code-new-user");
            if (!user) {
                formMain.dataset.stateForm = "signup";
                return;
            }

            const response = await fetchRegistryUser(JSON.parse(user));

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

            if (response?.data?.verificationResource.status == "pending") {
                createModal(`
                    <div style="text-align: center;">
                        <div style="display: flex; justify-content: center; color: #1e5603">
                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-circle-alert h-4 w-4"><circle cx="12" cy="12" r="10"></circle><line x1="12" x2="12" y1="8" y2="12"></line><line x1="12" x2="12.01" y1="16" y2="16"></line></svg>
                            <h2 style="padding-left: 12px" class="">Code resent.</h2>
                        </div>
                        <br>
                        <p style="font-size: 14px">Code verification resent, please verify the new code in you phone.</p>
                    </div>
                `);
                return
            }
        } catch (error) {
            console.log(error, "compadre")
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