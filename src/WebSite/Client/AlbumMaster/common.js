
function displayErrorPage(err) {
    window.location.href = "error.html";
}

function getUserId(){
    return localStorage.userId;
}

function setUserId(id) {
    localStorage.userId = id;
}

function resetUserId() {
    localStorage.userId = -1;
}

function showUserAlbumsPage() {
    window.location.href = "userAlbums.html";
}

function showLoginSignupPage() {
    window.location.href = "loginSignup.html";
}

function showSignupPage() {
    window.location.href = "signup.html";
}

