function addTeacher() {
    var formHandle = document.forms.newTeacher;

    const TeacherFname = formHandle.TeacherFname.value;
    const TeacherLname = formHandle.TeacherLname.value;
    const EmployeeNumber = formHandle.EmployeeNumber.value;
    const Salary = formHandle.Salary.value;

    // Validation of input values
    if (!TeacherFname || !TeacherLname || !EmployeeNumber || !Salary) {
        alert('Enter all information');
        return false;
    }

    const formData = new FormData(formHandle);
    formData.append('TeacherFname', TeacherFname);
    formData.append('TeacherLname', TeacherLname);
    formData.append('EmployeeNumber', EmployeeNumber);
    formData.append('Salary', Salary);

    const xhr = new XMLHttpRequest();
    const url = '/Teacher/Create';

    // Create an XMLHttpRequest object.
    xhr.open('POST', url, true);

    // Configure the POST request
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) {
            if (xhr.status === 200) {// Handle the successful server response.
                console.log('Request successfully completed!');

                location.href = '/Teacher/List';
            } else {
                alert('Please check the Information');
                console.error('Request failed with status:', xhr.status);
      
            }
        }
    };

    xhr.send(formData);

    return false;
};

function deleteTeacher(teacherId) {
    // Create an XMLHttpRequest object.
    const url = "/Teacher/Delete/" + Number(teacherId);
    const xhr = new XMLHttpRequest();

    // Configure the POST request
    xhr.open('POST', url, true);

    // Handle the server response.
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) {
            // Handle the successful server response.
            if (xhr.status === 200) {
                console.log('Request successfully completed!');

                location.href = '/Teacher/List';
            } else {
                console.error('Request failed with status:', xhr.status);
            }
        }
    };

    xhr.send();
}
