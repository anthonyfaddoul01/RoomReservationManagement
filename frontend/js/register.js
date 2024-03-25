
function register() {
  const fullName = document.getElementById("full-name").value;
  const email = document.getElementById("email").value;
  const password = document.getElementById("password").value;

  // Split full name into first name and last name
  const [firstName, lastName] = fullName.split(" ");

  const xhr = new XMLHttpRequest();
  xhr.open("POST", "https://localhost:7037/api/auth/SignUp");
  xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
  xhr.send(
    JSON.stringify({
      "email": email,
      "firstName": firstName,
      "lastName": lastName,
      "password": password,
    })
  );

  xhr.onreadystatechange = function () {
    if (this.readyState == 4) {
      const response = JSON.parse(this.responseText);
      console.log(response);
      if (response['status'] == 'ok') {
        Swal.fire({
          text: "Registration successful!",
          icon: 'success',
          confirmButtonText: 'OK'
        }).then((result) => {
          if (result.isConfirmed) {
            window.location.href = 'login.html';
          }
        });
      } else {
        Swal.fire({
          text: response['message'],
          icon: 'error',
          confirmButtonText: 'OK'
        });
      }
    }
  };
  return false;
}

