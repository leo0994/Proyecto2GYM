import createModal from "./components/modal.js";
import User from "./entities/User.js";
import { validateForm } from "./helpers.js";

(function () {
    const formMain = document.querySelector("[data-form]");
    const submitter = formMain?.querySelector('[type="submit"]');

    const btnForgotPass = formMain?.querySelector("[data-login] [data-forgot-password]");
    const btnBackSigIn = formMain?.querySelector("[data-forgotpass] [data-back-signin]");
    const btnResendCode = formMain?.querySelector("[data-validate-code] [data-resent-code]");

    var stateFormObject = {
        backSignin: "login",
        forgotPassword: "forgotpass",
    }

    btnBackSigIn?.addEventListener("click", switchGroupForm);
    btnForgotPass?.addEventListener("click", switchGroupForm);
    formMain?.addEventListener("submit", handleSubmit);
    formMain?.addEventListener("change", handleChange);
    document?.addEventListener("DOMContentLoaded", verifyPendingSessionCode);
    btnResendCode?.addEventListener("click", resendValidationCode);

    function verifyPendingSessionCode() {
        let user = sessionStorage.getItem("validating-code-recoverypass");
        if (user) {
            formMain.dataset.stateForm = "validate-code";
        }
    }

    function handleChange(e) {
        cleanHelpMessagesInputs();
    }

    function cleanHelpMessagesInputs() {
        formMain.querySelectorAll(".form-help-text.error")?.forEach((span) => {
            span.innerText = "";
        });
    }

    function handleSubmit(e) {
        e.preventDefault();
        const currentForm = e.target.dataset.stateForm;
        const currentGroupForm = e.target.querySelector(`[data-${currentForm}]`);
        const inputsList = Array.from(currentGroupForm.querySelectorAll("input"));
        const inputsListErrors = validateForm(inputsList);

        if (Object.keys(inputsListErrors).length > 0) {
            showErrorUI(inputsList, inputsListErrors);
            return
        }

        submitter.setAttribute("disabled", "");

        switch (currentForm) {
            case "login":
                handleLoginRequest(inputsList);
                break;
            case "forgotpass":
                handleRecoveryPasswordRequest(inputsList);
                break;
            case "validate-code":
                validateCodeValidation(inputsList);
                break;
            default:
                break;
        }

        // send form data. and verify which group form is active
    }

    async function validateCodeValidation(inputs) {
        try {
            const userData = sessionStorage.getItem("validating-code-recoverypass");
            const response = await await fetch(`http://localhost:5049/api/auth/recovery-password-verification?code=${inputs[0].value}`, {
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
                formMain.dataset.stateForm = "login";
                createModal(`
                    <div style="text-align: center;">
                        <div style="display: flex; justify-content: center; color: #1e5603">
                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-circle-alert h-4 w-4"><circle cx="12" cy="12" r="10"></circle><line x1="12" x2="12" y1="8" y2="12"></line><line x1="12" x2="12.01" y1="16" y2="16"></line></svg>
                            <h2 style="padding-left: 12px" class="">Password updated</h2>
                        </div>
                        <br>
                        <p style="font-size: 14px">Password was updated successfully, please login using your new password</p>
                    </div>
                `);
                sessionStorage.removeItem("validating-code-recoverypass");
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
            const user = sessionStorage.getItem("validating-code-recoverypass");
            if (!user) {
                formMain.dataset.stateForm = stateFormObject["backSignin"];
                return;
            }

            const response = await fetchCodeRecoveryPass(JSON.parse(user));
        
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

    async function fetchCodeRecoveryPass(userData) {
        const response = await fetch("http://localhost:5049/api/auth/recovery-password", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(userData),
        }).then(res => res.json());

        return response;
    }

    async function handleRecoveryPasswordRequest(inputsList) {
        try {
            const userData = composeUserEntity(inputsList);
            const response = await fetchCodeRecoveryPass(userData);

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
                sessionStorage.setItem("validating-code-recoverypass", JSON.stringify(response.data.user));
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

    async function handleLoginRequest(inputsList) {
        try {
            const userData = composeUserEntity(inputsList);
            const response = await fetch("http://localhost:5049/api/auth/signin", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(userData),
            })
                .then(res => res.json());

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

            window.location.replace("/profile");

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

    function composeUserEntity(inputs) {
        const user = { ...User };
        inputs.forEach((input) => {
            if (input?.name in user) {
                user[input?.name] = input?.value;
            }
        });
        return user;
    }

    function resetForm() {
        formMain.reset();
    }

    function switchGroupForm(e) {
        e.preventDefault();
        resetForm();
        cleanHelpMessagesInputs();
        if ('backSignin' in e.currentTarget.dataset) {
            formMain.dataset.stateForm = stateFormObject["backSignin"];
            return;
        }
        formMain.dataset.stateForm = stateFormObject["forgotPassword"];
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