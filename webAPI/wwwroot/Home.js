async function signUp() {
    const user = {
        firstName: document.querySelector("#signUpFirstName").value,
        lastName: document.querySelector("#signUpLastName").value,
        email: document.querySelector("#signUpEmail").value,
        password: document.querySelector("#signUpPassword").value
    };

    const response = await fetch('/api/Users', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(user)
    });

    if (response.ok) {
        alert("User registered successfully!");
    } else {
        alert("Registration failed");
    }
}

async function signIn() {
    const loginUser = {
        email: document.querySelector("#signInEmail").value,
        password: document.querySelector("#signInPassword").value
    };

    const response = await fetch('/api/Users/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(loginUser)
    });

    if (response.ok) {
        const user = await response.json();
        sessionStorage.setItem("user", JSON.stringify(user));
        alert("welcome " + user.firstName);
    } else {
        alert("Incorrect email or password");
    }
}