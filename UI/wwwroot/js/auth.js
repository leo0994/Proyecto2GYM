(function () {
    const formMain = document.querySelector("[data-form]");
    const submitter = formMain.querySelector('[type="submit"]');

    const btnForgotPass = formMain.querySelector("[data-login] [data-forgot-password]");
    const btnBackSigIn = formMain.querySelector("[data-forgotpass] [data-back-signin]");

    var stateFormObject = {
        backSignin: "login",
        forgotPassword: "forgotpass"
    }

    btnBackSigIn.addEventListener("click", switchGroupForm);
    btnForgotPass.addEventListener("click", switchGroupForm);
    formMain.addEventListener("submit", handleSubmit);
    formMain.addEventListener("change", handleChange);


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
        const activeGroupForm = e.target.querySelector(`[data-${e.target.dataset.stateForm}]`);
        const inputs = Array.from(activeGroupForm.querySelectorAll("input"));
        const inputsErrors = validateForm(inputs)
        if (Object.keys(inputsErrors).length > 0) {
            showErrorUI(inputs, inputsErrors)
            return
        }
        // send form data. and verify which group form is active
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

    function validateForm(inputs) {
        const errors = {};

        inputs.forEach((input) => {
            const { name, value, type, files, dataset } = input;

            // Validate if the field is not empty
            if (!value.trim() && type !== 'file') {
                errors[name] = 'This field cannot be empty';
                return;
            }

            if("softRules" in dataset){
                return
            }

            // Specific validations based on type
            switch (type) {
                case 'text':
                    if (value == "") {
                        errors[name] = 'This field cannot be empty';
                    }
                    break;
                case 'email':
                    console.log(value, type)
                    if (!/^\S+@\S+\.\S+$/.test(value)) {
                        errors[name] = 'Invalid email format';
                    }
                    break;
                case 'password':
                    // Password must meet specific requirements
                    const passwordRules = [
                        { regex: /.{8,}/, message: 'Password must be at least 8 characters long' },
                        { regex: /[A-Z]/, message: 'Password must contain at least one uppercase letter' },
                        { regex: /[a-z]/, message: 'Password must contain at least one lowercase letter' },
                        { regex: /[0-9]/, message: 'Password must contain at least one digit' },
                        { regex: /[!@#\$%\^\&*\)\(+=._-]/, message: 'Password must contain at least one special character' }
                    ];

                    for (const rule of passwordRules) {
                        if (!rule.regex.test(value)) {
                            errors[name] = rule.message;
                            break;
                        }
                    }

                    // Password confirmation
                    if (name === 'password_confirmation') {
                        const passwordElement = inputs.find(el => el.name === 'password');
                        if (passwordElement && passwordElement.value !== value) {
                            errors[name] = 'Passwords do not match';
                        }
                    }
                    break;
                case 'tel':
                    if (!/^\+?[0-9]{10,15}$/.test(value)) {
                        errors[name] = 'Invalid phone number format';
                    }
                    break;
                case 'credit_card':
                    if (!/^\d{13,19}$/.test(value)) {
                        errors[name] = 'Invalid credit card number';
                    }
                    break;
                case 'file':
                    if (name === 'photo') {
                        if (!files || !files[0]) {
                            errors[name] = 'Photo file is required';
                        } else if (!/\.(jpg|jpeg|png|gif)$/i.test(files[0].name)) {
                            errors[name] = 'Invalid photo file format. Only jpg, jpeg, png, and gif are allowed';
                        }
                    }
                    break;
                default:
                    // Add more validations as needed
                    break;
            }
        });

        return errors;
    }
})()