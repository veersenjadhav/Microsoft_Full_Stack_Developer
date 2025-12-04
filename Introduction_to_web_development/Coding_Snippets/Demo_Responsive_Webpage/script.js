let button = document.getElementById('btnContactDetails');
let contactDetailsStatus = document.querySelector('.contactDetailsStatus');

let statusMsg = "You've taken the contact details !";

button.addEventListener('click', function(){
    alert("Email Address : test@test.com");

    contactDetailsStatus.textContent = statusMsg;
});

async function fetchDataAsync() {
    try {
        const response = await fetch('https://jsonplaceholder.typicode.com/users');

        if (!response.ok)
        {
            throw new Error(`Status: ${response.status}`);
        }

        const data = await response.json();

        const container = document.getElementById('data-container');
        container.innerHTML = data
        .map(user => `<p>${user.name} - ${user.email}</p>`)
        .join('');
    } 
    catch (error) {
        // Concatenate the string and the error for display.
        alert('Error fetching data: ' + error);
    }
}

document.getElementById('fetch-data').addEventListener('click', fetchDataAsync);