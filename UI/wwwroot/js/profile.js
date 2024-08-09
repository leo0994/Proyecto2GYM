
document.addEventListener("DOMContentLoaded", function () {
    const profileContent = document.getElementById('profile-content');
    const errorMessage = document.getElementById('error-message');

    let user = getCookie("user");

    fetch(`http://localhost:5049/api/User/RetrieveById?id=${user}`)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            setTimeout(() => {
                profileContent.classList.remove('loading');
                renderUserProfile(data);
                renderUserProfileNav(data);
            }, 2000)
        })
        .catch(error => {
            profileContent.style.display = 'none';
            errorMessage.style.display = 'block';
            console.error('Error fetching user profile:', error);
        });

    function renderUserProfile(user) {
        const userDetails = document.createElement('div');

        const date = new Date(user.dateOfBirth);

        // Format the date to a readable format
        const options = { year: 'numeric', month: 'long', day: 'numeric' };
        const formattedDate = date.toLocaleDateString(undefined, options);

        userDetails.classList.add('user-details', 'active');
        userDetails.innerHTML = `
            <div class="avatar" style="background-image: url('https://via.placeholder.com/80');"></div>
            <p>${user.name}</p>
            <p>${user.email}</p>
            <p>${user.number}</p>
            <p>${formattedDate}</p>
        `;
        profileContent?.querySelector('.profile-info')?.appendChild(userDetails);
    }

    function renderUserProfileNav(user) {
        console.log(user)
        const userNav = document.createElement('div');

        // {
        //     "id": 1,
        //     "name": "Administrator"
        //   },
        //   {
        //     "id": 2,
        //     "name": "Client"
        //   },
        //   {
        //     "id": 3,
        //     "name": "Trainer"
        //   },

        // ADMIN
        if (user.typeUserId === 1) {
            userNav.innerHTML = `
                <div class="item-nav">
                    <h2>Users</h2>
                    <nav style="text-align: left; display: flex; gap: 24px;">
                        <a href="/home/signUp">
                            Register user
                            <svg class="arrow-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="14" height="14" "><path d="M14 5L22 12L14 19L11.5 16.5L17.5 12L11.5 7.5L14 5Z"></path> </svg>
                        </a>
                        <a href="/SubscriptionAdmin/Subscription">
                           Subscribers
                            <svg class="arrow-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="14" height="14" "><path d="M14 5L22 12L14 19L11.5 16.5L17.5 12L11.5 7.5L14 5Z"></path> </svg>
                        </a>
                        <a href="/TypeUser/Getall">
                            Type users
                            <svg class="arrow-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="14" height="14" "><path d="M14 5L22 12L14 19L11.5 16.5L17.5 12L11.5 7.5L14 5Z"></path> </svg>
                        </a>
                    </nav>
                </div>
                 <div class="item-nav">
                    <h2>Appointments</h2>
                    <nav style="text-align: left; display: flex; gap: 24px;">
                        <a href="/administration/managementAppointments">
                            Appoinments  
                            <svg class="arrow-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="14" height="14" "><path d="M14 5L22 12L14 19L11.5 16.5L17.5 12L11.5 7.5L14 5Z"></path> </svg>
                        </a>
                    </nav>
                </div>
                <div class="item-nav">
                    <h2>Class activity</h2>
                    <nav style="text-align: left; display: flex; gap: 24px;">
                        <a href="/ClassActivities/">
                            Activities home  
                            <svg class="arrow-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="14" height="14" "><path d="M14 5L22 12L14 19L11.5 16.5L17.5 12L11.5 7.5L14 5Z"></path> </svg>
                        </a>
                         <a href="/ClassActivities/ManagementActivities">
                            Activities Management  
                            <svg class="arrow-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="14" height="14" "><path d="M14 5L22 12L14 19L11.5 16.5L17.5 12L11.5 7.5L14 5Z"></path> </svg>
                        </a>
                    </nav>
                </div>
                <div class="item-nav">
                    <h2>equipments</h2>
                    <nav style="text-align: left; display: flex; gap: 24px;">
                        <a href="/EquipmentAdmin/Equipment">
                            Equipments home  
                            <svg class="arrow-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="14" height="14" "><path d="M14 5L22 12L14 19L11.5 16.5L17.5 12L11.5 7.5L14 5Z"></path> </svg>
                        </a>
                    </nav>
                </div>
            `
        }

        // CLIENT - GOERS
        if (user.typeUserId === 2) {
            userNav.innerHTML = `
                <div class="item-nav">
                    <h2>Appointments</h2>
                    <nav style="text-align: left; display: flex; gap: 24px;">
                        <a href="/">
                            My appoiments
                            <svg class="arrow-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="14" height="14" "><path d="M14 5L22 12L14 19L11.5 16.5L17.5 12L11.5 7.5L14 5Z"></path> </svg>
                        </a>
                    </nav>
                </div>
                 <div class="item-nav">
                    <h2>Enrollments </h2>
                    <nav style="text-align: left; display: flex; gap: 24px;">
                        <a href="/">
                            History enrollments  
                            <svg class="arrow-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="14" height="14" "><path d="M14 5L22 12L14 19L11.5 16.5L17.5 12L11.5 7.5L14 5Z"></path> </svg>
                        </a>
                    </nav>
                </div>
                <div class="item-nav">
                    <h2>Routines</h2>
                    <nav style="text-align: left; display: flex; gap: 24px;">
                        <a href="/">
                            My routines  
                            <svg class="arrow-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="14" height="14" "><path d="M14 5L22 12L14 19L11.5 16.5L17.5 12L11.5 7.5L14 5Z"></path> </svg>
                        </a>
                    </nav>
                </div>
                <div class="item-nav">
                    <h2>Class Activities</h2>
                    <nav style="text-align: left; display: flex; gap: 24px;">
                        <a href="/EquipmentAdmin/Equipment">
                            My class activities
                            <svg class="arrow-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="14" height="14" "><path d="M14 5L22 12L14 19L11.5 16.5L17.5 12L11.5 7.5L14 5Z"></path> </svg>
                        </a>
                    </nav>
                </div>
            `
        }

        // TRAINER
        if (user.typeUserId === 3) {
            userNav.innerHTML = `
                <div class="item-nav">
                    <h2>Routines</h2>
                    <nav style="text-align: left; display: flex; gap: 24px;">
                        <a href="/home/RoutineCreation">
                            Routine creation
                            <svg class="arrow-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="14" height="14" "><path d="M14 5L22 12L14 19L11.5 16.5L17.5 12L11.5 7.5L14 5Z"></path> </svg>
                        </a>
                    </nav>
                </div>
                 <div class="item-nav">
                    <h2>Exercises</h2>
                    <nav style="text-align: left; display: flex; gap: 24px;">
                        <a href="/home/ExerciseRegister">
                            Register exercise
                            <svg class="arrow-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="14" height="14" "><path d="M14 5L22 12L14 19L11.5 16.5L17.5 12L11.5 7.5L14 5Z"></path> </svg>
                        </a>
                    </nav>
                </div>
                <div class="item-nav">
                    <h2>Appoinments</h2>
                    <nav style="text-align: left; display: flex; gap: 24px;">
                        <a href="/">
                            My appointments
                            <svg class="arrow-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="14" height="14" "><path d="M14 5L22 12L14 19L11.5 16.5L17.5 12L11.5 7.5L14 5Z"></path> </svg>
                        </a>
                    </nav>
                </div>
            `
        }

        // Receptionist
        if (user.typeUserId === 4) {
            userNav.innerHTML = `
                <div class="item-nav">
                    <h2>Users</h2>
                    <nav style="text-align: left; display: flex; gap: 24px;">
                        <a href="/home/signUp">
                            Register user
                            <svg class="arrow-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="14" height="14" "><path d="M14 5L22 12L14 19L11.5 16.5L17.5 12L11.5 7.5L14 5Z"></path> </svg>
                        </a>
                        <a href="/SubscriptionAdmin/Subscription">
                           Subscribers
                            <svg class="arrow-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="14" height="14" "><path d="M14 5L22 12L14 19L11.5 16.5L17.5 12L11.5 7.5L14 5Z"></path> </svg>
                        </a>
                    </nav>
                </div>
                 <div class="item-nav">
                    <h2>Appointments</h2>
                    <nav style="text-align: left; display: flex; gap: 24px;">
                        <a href="/administration/managementAppointments">
                            Appoinments  
                            <svg class="arrow-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="14" height="14" "><path d="M14 5L22 12L14 19L11.5 16.5L17.5 12L11.5 7.5L14 5Z"></path> </svg>
                        </a>
                    </nav>
                </div>
                <div class="item-nav">
                    <h2>Enrollments </h2>
                    <nav style="text-align: left; display: flex; gap: 24px;">
                        <a href="/">
                            Create enrollment
                            <svg class="arrow-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="14" height="14" "><path d="M14 5L22 12L14 19L11.5 16.5L17.5 12L11.5 7.5L14 5Z"></path> </svg>
                        </a>
                    </nav>
                </div>
            `
        }

        profileContent?.querySelector('.profile-nav')?.appendChild(userNav);
    }
});
