//Form element
const enrollForm = document.getElementById("enrollmentForm");

//regex for name,email and website
const namePattern = /^([a-zA-Z]+$)|^([a-zA-Z]+ [a-zA-Z]+$)|^([a-zA-Z]+ [a-zA-Z]+ [a-zA-Z]+$)/
const emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9._-]+$/
const websitePattern = /^((ftp|http|https):\/\/)?(www.)?(?!.*(ftp|http|https|www.))[a-zA-Z0-9_-]+(\.[a-zA-Z]+)+((\/)[\w#]+)*(\/\w+\?[a-zA-Z0-9_]+=\w+(&[a-zA-Z0-9_]+=\w+)*)?\/?$/



function ClearErrorMessage() {
    errorMessages = document.getElementsByClassName("errorMessage");

    // Clear error message for every input element
    for (let eachErrorMessage of errorMessages) {
        eachErrorMessage.innerHTML = ""
    }
}


function ValidateName() {

    name = enrollForm.name.value

    //Check for invalid length
    if (name.length < 6) {
        setError("username", "*Length of name is too short");
        return false
    }

    //Check for extra spaces and non-alphabetic characters
    if (!name.match(namePattern)) {
        setError("username", "*Please check for invalid characters/spaces in name. ")
        return false
    }

    return true
}


function ValidateEmail() {
    email = enrollForm.email.value

    //Check for invalid length
    if (email.length <= 8) {
        setError("useremail", "*Length of Email is too short.")
        return false
    }

    //Check for valid email format by matching user's email with regex emailPattern
    else if (!email.match(emailPattern)) {
        setError("useremail", "*Please check for correct use of @,.etc in your email.")
        return false
    }
    return true

}


function ValidateWebsite() {
    website = enrollForm.website.value

    //Check for invalid length
    if (website.length < 8) {
        setError("userwebsite", "*Length of URL is too short.")
        return false
    }

    // Check for valid website URL, matching with regex websitePattern
    else if (!website.match(websitePattern)) {
        setError("userwebsite", "*Please enter a valid URL.")
        return false
    }

    return true

}


function ValidateSkills() {

    // If none of the checkbox is marked, expression will return false
    skills = (enrollForm.java.checked || enrollForm.html.checked || enrollForm.css.checked)

    //Set error if none of the skill checkbox is marked
    if (skills == false) {
        setError("userskills", "Please select at least 1 skill to enroll.")
        return false
    }
    return true

}

//Set error message for element by 'id' for every wrong input 
function setError(id, error) {

    element = document.getElementById(id)
    element.getElementsByClassName("errorMessage")[0].innerHTML = error
}

function ValidateForm() {
    event.preventDefault();

    //Clear all Error message on every form submission 
    ClearErrorMessage();

    //if all the validation pass, return true 
    if (ValidateName() && ValidateEmail() && ValidateWebsite() && ValidateSkills()) {
        return true
    }
    return false

}