

var controlsSignIn = [
    { control: '#txtUserName', errorMessage: 'Enter username', lblControl: '#spnUserName' },
    { control: '#txtPassword', errorMessage: 'Enter password', lblControl: '#spnPassword' },
];

var controls = [
    { control: '#txtFirstName', errorMessage: 'Enter first name', lblControl: '#spnFirstName' },
    { control: '#txtLastName', errorMessage: 'Enter last Name', lblControl: '#spnLastName' },
    { control: '#txtEmail', errorMessage: 'Enter email address', lblControl: '#spnEmail' },
    { control: '#txtMobileNumber', errorMessage: 'Enter mobile number', lblControl: '#spnMobileNumber' },
    { control: '#txtSignUpPassword', errorMessage: 'Enter password', lblControl: '#spnSignUpPassword' },

];


function Failed(response) {
    //$('.loader-bg').hide();
    swal('Something went wrong ', '', 'error');
}

function SignUpSuccess(response) {
    //$('.loader-bg').hide();
    if (response.success) {
        alert('Congratulations, your account has been created.');
        ClearSignupField();
    }
    else {
        alert('Registration Failed');
        var validationErrors = response.ValidationError

        $.each(validationErrors, function (index,item) {
           
            $('#signUpModel [name="' + item.Id + '"]').closest("div").find(".errorMsgSpanSignUp").show()
            $('#signUpModel [name="' + item.Id +'"]').closest("div").find(".errorMsgSpanSignUp").text(item.Value)
        });
            
        //console.log(response.ValidationError)
    }
}

function SignUpValidator() {

    var isValid = true

    //FirstName
    if (!WebxCommonFN.ValidateAlphabet('#txtFirstName')) {
        WebxCommonFN.DisplayError('#spnFirstName', 'Only letters are allowd')
        isValid = false;
    }
    else
        WebxCommonFN.HideError('#spnFirstName')

    //LastName
    if (!WebxCommonFN.ValidateAlphabet('#txtLastName')) {
        WebxCommonFN.DisplayError('#spnLastName', 'Only letters are allowd')
        isValid = false;
    }
    else
        WebxCommonFN.HideError('#spnLastName')

    //Email
    if (!WebxCommonFN.ValidateEmail('#txtEmail')) {
        WebxCommonFN.DisplayError('#spnEmail', 'Invalid email address');
        isValid = false;
    }
    else
        WebxCommonFN.HideError('#spnEmail')


    //Mobile Number
    if (!WebxCommonFN.ValidateMobileNumber('#txtMobileNumber')) {
        WebxCommonFN.DisplayError('#spnMobileNumber', 'Only numbers are allowd')
        isValid = false;
    }
    else
        WebxCommonFN.HideError('#spnMobileNumber')

    //Password
    if (!WebxCommonFN.ValidatePassword('#txtSignUpPassword')) {
        $('.PwdValidationMsg').show()
        WebxCommonFN.HideError('#spnSignUpPassword')
        isValid = false;
    }
    else {
        WebxCommonFN.HideError('#spnSignUpPassword')
        $('.PwdValidationMsg').hide()
    }
      
    return isValid

}

$(document).ready(function () {

    WebxCommonFN.AttachChangeListener(controls);
    ClickEvents();
    PasswordEyeChanges();
});

function PasswordEyeChanges() {
    const togglePassword = document.querySelector('#togglePassword');
    const password = document.querySelector('#txtSignUpPassword');

    togglePassword.addEventListener('click', function (e) {

        // toggle the type attribute
        const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
        password.setAttribute('type', type);
        // toggle the eye slash icon
        this.classList.toggle('fa-eye-slash');
    });

    const loginTogglePassword = document.querySelector('#loginTogglePassword');
    const loginPassword = document.querySelector('#txtPassword');

    loginTogglePassword.addEventListener('click', function (e) {

        // toggle the type attribute
        const type = loginPassword.getAttribute('type') === 'password' ? 'text' : 'password';
        loginPassword.setAttribute('type', type);
        // toggle the eye slash icon
        this.classList.toggle('fa-eye-slash');
    });
}

function ClickEvents()
{

    $('#spnHaveAccont').click(function () {
        $('#signUpModel').modal('toggle');
    })

    $('#spnCreateAccount').click(function () {
        $('#exampleModalCenter').modal('toggle');
    })

    $('#txtUserName').focusout(function () {
        if ($(this).val() != '' && !WebxCommonFN.ValidateMobileNumber('#txtUserName')) {
            WebxCommonFN.DisplayError('#spnUserName', 'Enter valid mobile number');
            $("#txtUserName").val("");
        }
        else if ($(this).val() != '') {
            WebxCommonFN.HideError('#spnUserName');
        }
        else if ($(this).val() == '') { 
        WebxCommonFN.DisplayError('#spnUserName', 'Enter username');
        }
    })

    $('#txtPassword').focusout(function () {
        if ($(this).val() != '')
            WebxCommonFN.HideError('#spnPassword')
        else if ($(this).val() == '')
            WebxCommonFN.DisplayError('#spnPassword', 'Enter password')
    })

    $('#txtFirstName').focusout(function () {
        if ($(this).val() != '' && !WebxCommonFN.ValidateAlphabet('#txtFirstName'))
            WebxCommonFN.DisplayError('#spnFirstName', 'Only letters are allowd')
        else if ($(this).val() != '')
            WebxCommonFN.HideError('#spnFirstName')
        else if ($(this).val() == '')
            WebxCommonFN.DisplayError('#spnFirstName', 'Enter first name')
    })

    $('#txtLastName').focusout(function () {
        if ($(this).val() != '' && !WebxCommonFN.ValidateAlphabet('#txtLastName'))
            WebxCommonFN.DisplayError('#spnLastName', 'Only letters are allowd')
        else if ($(this).val() != '')
            WebxCommonFN.HideError('#spnLastName')
        else if ($(this).val() == '')
            WebxCommonFN.DisplayError('#spnLastName', 'Enter last name')
    })

    $('#txtEmail').focusout(function () {
        if ($(this).val() != '' && !WebxCommonFN.ValidateEmail('#txtEmail'))
            WebxCommonFN.DisplayError('#spnEmail', 'Invalid email address')
        else if ($(this).val() != '')
            WebxCommonFN.HideError('#spnEmail')
        else if ($(this).val() == '')
            WebxCommonFN.DisplayError('#spnEmail', 'Enter email address')
    })

    $('#txtMobileNumber').focusout(function () {
        if ($(this).val() != '' && !WebxCommonFN.ValidateMobileNumber('#txtMobileNumber'))
            WebxCommonFN.DisplayError('#spnMobileNumber', 'Only numbers are allowd')
        else if ($(this).val() != '')
            WebxCommonFN.HideError('#spnMobileNumber')
        else if ($(this).val() == '')
            WebxCommonFN.DisplayError('#spnMobileNumber', 'Enter mobile number')
    })

    $('#txtSignUpPassword').focusout(function () {
        if ($(this).val() == '') {
            WebxCommonFN.DisplayError('#spnSignUpPassword', 'Enter password')
            $('.PwdValidationMsg').hide()
        }
        else {
            if (!WebxCommonFN.ValidatePassword('#txtSignUpPassword')) {
                $('.PwdValidationMsg').show()
                WebxCommonFN.HideError('#spnSignUpPassword')
            }
            else {
                WebxCommonFN.HideError('#spnSignUpPassword')
                $('.PwdValidationMsg').hide()
            }
        }
    })
    $('#btnSubmitSignUp').click(function () {

        if (!WebxCommonFN.ValidateEmptyFields(controls))
            return false;

        if (!SignUpValidator())
            return false;

        var requiredFields = {
            url: '/Home/SignUp',
            header: { 'VerificationToken': $("#forgeryToken").val() },
            data: {
                'FirstName': $("#txtFirstName").val(),
                'LastName': $("#txtLastName").val(),
                'MobileNumber': $("#txtMobileNumber").val(),
                'EmailAddress': $("#txtEmail").val(),
                'Password': $("#txtSignUpPassword").val(),
            },
            successFunction: SignUpSuccess,
            errorFunction: Failed
        }
        WebxCommonFN.AjaxPostRequest(requiredFields);
    })
    $('#achForgotPwd').click(function () {
    //    var requiredFields = {
    //        url: '/Home/GenerateOTP',
    //        header: { 'VerificationToken': $("#forgeryToken").val() },
    //        data: {
    //            'Type': 'F'
    //        },
    //        successFunction: function () {
    //            window.location.href = "/Home/ForgotPassword";
    //        },
    //        errorFunction: Failed
    //    }
    //    WebxCommonFN.AjaxPostRequest(requiredFields);
    //});
        
    window.location.href = "/Home/ForgotPassword";
        //if ($('#txtUserName').val() == '') {
        //    $('$spnUserName').text('')
        //    WebxCommonFN.DisplayError('#spnUserName', 'Enter valid mobile number')
        //    $("#txtUserName").val("");
        //}
        //else if ($('#txtUserName').val() != '') {

        //    if (!WebxCommonFN.ValidateMobileNumber('#txtUserName')) {
        //        $('$spnUserName').text('')
        //        WebxCommonFN.DisplayError('#spnUserName', 'Enter valid mobile number')
        //        $("#txtUserName").val("");
        //    }
        //    else {
        //        alert('Success');
        //    }

        //}
});
    $('#btnLogin').click(function () {
        debugger;
        var controlsFilled = WebxCommonFN.ValidateEmptyFields(controlsSignIn);

        if (controlsFilled) {
            var requiredFields = {
                url: '/Home/CheckLoginDetails',
                header: { 'VerificationToken': $("#forgeryToken").val() },
                data: {
                    'Username': $("#txtUserName").val(),
                    'Password': $("#txtPassword").val(),
                },
                successFunction: LoginSuccess,
                errorFunction: Failed
            }
            WebxCommonFN.AjaxPostRequest(requiredFields);
        }

    })

}
function LoginSuccess(response) {
    if (response.success) {
        ClearLoginField();
        if (response.LoginStatus != "Invalid Credentials") {
            alert("Ok");
        }
        else {
            alert(response.LoginStatus);
        }
    }

}
function ClearLoginField()
{
    $("#txtUserName").val("");
    $("#txtPassword").val("");
}
function ClearSignupField()
{
    $("#txtFirstName").val("");
    $("#txtLastName").val("");
    $("#txtMobileNumber").val("");
    $("#txtEmail").val("");
    $("#txtSignUpPassword").val("");
}