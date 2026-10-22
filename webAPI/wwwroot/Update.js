const currentUser = JSON.parse(sessionStorage.getItem("user"));

document.querySelector("#updateEmail").value = currentUser.email;
document.querySelector("#updatePassword").value = currentUser.password;
document.querySelector("#updateFirstName").value = currentUser.firstName;
document.querySelector("#updateLastName").value = currentUser.lastName;

async function update() {
    const id = currentUser.userId;

    const updatedUser = {
        userId: id,
        email: document.querySelector("#updateEmail").value,
        password: document.querySelector("#updatePassword").value,
        firstName: document.querySelector("#updateFirstName").value,
        lastName: document.querySelector("#updateLastName").value
    };

    const response = await fetch(`/api/Users/${id}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(updatedUser)
    });

    if (response.ok) {
        const savedUser = await response.json();
        sessionStorage.setItem("user", JSON.stringify(savedUser));
        alert("The details have been updated.");
    } else {
        alert("update failed");
    }
}