

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
        alert('Suc')
    }
    else {
        alert('false')
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

    $('#spnHaveAccont').click(function () {
        $('#signUpModel').modal('toggle');
    })

    $('#spnCreateAccount').click(function () {
        $('#exampleModalCenter').modal('toggle');
    })

    $('#txtUserName').focusout(function () {       
        if ($(this).val() != '' && !WebxCommonFN.ValidateMobileNumber('#txtUserName'))
            WebxCommonFN.DisplayError('#spnUserName', 'Enter valid mobile number')
        else if ($(this).val() != '')
            WebxCommonFN.HideError('#spnUserName')
        else if ($(this).val() == '')
            WebxCommonFN.DisplayError('#spnUserName', 'Enter username')
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

    $('#btnLogin').click(function () {
        
        var controlsFilled = WebxCommonFN.ValidateEmptyFields(controlsSignIn);

        if (controlsFilled) {
            alert('Succss');
        }

    })

    WebxCommonFN.AttachChangeListener(controls);


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
                    'Email': $("#txtEmail").val(),
                    'Password': $("#txtSignUpPassword").val(),
                },
                successFunction: SignUpSuccess,
                errorFunction: Failed
            }
            WebxCommonFN.AjaxPostRequest(requiredFields);        
    })


    $('#achForgotPwd').click(function () {
      
        if ($('#txtUserName').val() == '') {
            $('$spnUserName').text('')
            WebxCommonFN.DisplayError('#spnUserName', 'Enter valid mobile number')
        }
        else if ($('#txtUserName').val() != ''){

            if (!WebxCommonFN.ValidateMobileNumber('#txtUserName')) {
                $('$spnUserName').text('')
                WebxCommonFN.DisplayError('#spnUserName', 'Enter valid mobile number')
            }
            else {
                alert('Success');
            }

        }
    })


   


})