 "use strict";

const baseURL = 'https://localhost:7228/';

const registerURL = baseURL + 'Subscriber/register';

const emailInp = document.getElementById("emailInp");
const feedback = document.getElementById("feedback");
const sendBtn = document.getElementById("sendBtn");
const registerForm = document.getElementById("register-form");
const emailForm = document.getElementById("email-form");
const confirmation = document.getElementById("confirmation");
const confirmBtn = document.getElementById("confirmBtn");
const confirmMsg = document.getElementById("confirmMsg");

const validateEmail = (email) => {
    return String(email)
        .toLowerCase()
        .match(
            /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
        );
};


function disableBtn(btn) {
    btn.disabled = true;
    btn.classList.add("disabled");
    btn.classList.remove("active");
}

function enableBtn(btn) {
    btn.disabled = false;
    btn.classList.remove("disabled");
    btn.classList.add("active");
}


function register(email) {
    
    disableBtn(sendBtn);
    fetch(registerURL, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({email: email})
    })
    .then(res => { 
        if (res.ok) {
           
            confirmation.classList.toggle("hidden");
            emailForm.classList.toggle("hidden");
            emailInp.value = "";
            feedback.innerHTML = "";
            res.text().then(data => {confirmMsg.innerHTML = data});
            enableBtn(sendBtn);
        }
        else{
            res.text().then(data => {feedback.innerHTML = data});
            enableBtn(sendBtn);
        }
    })


}

sendBtn.onclick = async function () {


    if (emailInp.value == "") {
        feedback.innerText = "Het email formulier mag niet leeg zijn"
        return
    }
    if (!validateEmail(emailInp.value)) {
        feedback.innerText = "Het formaat van het e-mailadres is niet geldig"
        return
    }
    else {
        register(emailInp.value);
    }



}

confirmBtn.onclick = function () {
    confirmation.classList.toggle("hidden");
    emailForm.classList.toggle("hidden");
}
