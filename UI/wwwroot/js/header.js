(function () {
    checkUserLogin();

    function checkUserLogin() {
        let user = getCookie("user");
        if (user) {
            document.getElementById("sign-in").style.display = "none";
            document.getElementById("profile").style.display = "block";
        } else {
            document.getElementById("sign-in").style.display = "block";
            document.getElementById("profile").style.display = "none";
        }
    }

})()

function getCookie(name) {
    let cookieArr = document.cookie.split(";");
    for (let i = 0; i < cookieArr.length; i++) {
        let cookiePair = cookieArr[i].split("=");
        if (name == cookiePair[0].trim()) {
            return decodeURIComponent(cookiePair[1]);
        }
    }
    return null;
}
