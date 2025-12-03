let button = document.getElementById('btnContactDetails');
let contactDetailsStatus = document.querySelector('.contactDetailsStatus');

let statusMsg = "You've taken the contact details !";

button.addEventListener('click', function(){
    alert("Email Address : test@test.com");

    contactDetailsStatus.textContent = statusMsg;
});