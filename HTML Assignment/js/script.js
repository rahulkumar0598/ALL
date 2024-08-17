const enrollmentRecords = document.getElementById("enrollment-records")
const enrollmentForm = document.getElementById("enrollmentForm")


function createRecord(newrecord) {
    ///Concatinating protocol incase missing from website URL, otherwise
    ///anchor tag will make it as sub part of the current URL

    link = newrecord.website
    if (!(link.startsWith("http://") | link.startsWith("https://"))) {
        link = "http://" + newrecord.website
    }


    //Table row element and table data is created to dynamicaly add to the table
    var newelement =
        `
        <tr class="record"><td scope="row">${newrecord.name}<br>${newrecord.gender}<br>${newrecord.email}<br><a href="${link}" target="_blank">${newrecord.website}</a><br>${newrecord.skills}</td>
        <td class="text-center"><img class="img-responsive" width=80 height=80 src="${newrecord.imagelink}"></td></tr>
        `
    //Embedding newly created table row in table 
    enrollmentRecords.innerHTML += newelement
    clearForm()
}


//Clears all form field values on pressing clear button
function clearForm() {

    event.preventDefault();
    myform = document.getElementById("enrollmentForm")
    myform.reset();

}


function handleSubmit() {

    //To prevent default behaviour of form submission
    event.preventDefault()

    //Form values needs to be validated before creating a new reccord
    if (!ValidateForm()) return;



    url = enrollForm.imagelink.value

    /// ImageUrlValidation method returns promise after checking image 
    /// exists or not, if it does then only creates new records
    /// else sets error for invalid image input 
    const ImageUrlValidation = (url) =>

        new Promise((resolve) => {

            //Initializing new image element and adding user given URL as source
            const img = new Image();
            img.src = url;

            //If image loads resolves as true else resolves as false
            img.onload = () => resolve(true);
            img.onerror = () => resolve(false);

        }).then((message) => {

            //If image exists, create new record
            if (message == true) {

                //Extract input field data
                userName = enrollmentForm.name.value
                userEmail = enrollmentForm.email.value
                userWebsite = enrollmentForm.website.value
                userImage = enrollmentForm.imagelink.value
                userGender = enrollmentForm.gender.value

                //Push all checked values into skills array
                userSkills = []

                if (enrollmentForm.java.checked) {
                    userSkills.push("JAVA")
                }
                if (enrollmentForm.html.checked) {
                    userSkills.push("HTML")
                }
                if (enrollmentForm.css.checked) {
                    userSkills.push("CSS")
                }


                //Object to create new record
                newrecord = {
                    name: userName,
                    email: userEmail,
                    website: userWebsite,
                    imagelink: userImage,
                    gender: userGender,
                    skills: userSkills
                }

                createRecord(newrecord)
            }

            //if image does not exists,set error
            else {
                setError("userimagelink", "*Please provide valid Image URL.")
                return
            }

        });

    ImageUrlValidation(url)

}
