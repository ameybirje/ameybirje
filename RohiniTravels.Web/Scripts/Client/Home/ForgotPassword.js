
var validateControls = [
    { control: "#txtRegMobNo", errorMessage: "Please enter mobile no", lblControl: "#lblRegMobNoError" },
]

$(document).ready(function () {
    WebxCommonFN.AttachChangeListener(validateControls);
    $("#Step1").show();
    $("#Step2").hide();
    $("#Step3").hide();
    ClickEvents();
    PasswordEyeChanges();
});

function Failed(response) {
    //$('.loader-bg').hide();
    swal('Something went wrong ', '', 'error');
}
function PasswordEyeChanges() {
    const togglePassword = document.querySelector('#TogglePassword');
    const password = document.querySelector('#txtPassword');

    togglePassword.addEventListener('click', function (e) {

        // toggle the type attribute
        const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
        password.setAttribute('type', type);
        // toggle the eye slash icon
        this.classList.toggle('fa-eye-slash');
    });

    const confirmTogglePassword = document.querySelector('#ConfirmPwdTogglePassword');
    const confirmPassword = document.querySelector('#txtConfirmPassword');

    confirmTogglePassword.addEventListener('click', function (e) {

        // toggle the type attribute
        const type = confirmPassword.getAttribute('type') === 'password' ? 'text' : 'password';
        confirmPassword.setAttribute('type', type);
        // toggle the eye slash icon
        this.classList.toggle('fa-eye-slash');
    });
}
function ClickEvents()
{
    //--------------------------Step 1 Popup------------------------------//
    $("#btnSubmit").click(function () {
        debugger;
        validField = WebxCommonFN.ValidateEmptyFields(validateControls);
        if (validField) {
            var validatedMobileNo = {
                url: '/Home/CheckMobileNo',
                header: { 'VerificationToken': $("#forgeryToken").val() },
                data: {
                    'MobileNo': $("#txtRegMobNo").val(),
                    'Type': 'F'
                },
                successFunction: function (response) {
                    if (response.success) {
                        if (response.OTPStatus == "Success") {
                            $("#Step1").hide();
                            $("#Step2").show();
                            $("#Step3").hide();
                        }
                    }

                },
                errorFunction: Failed
            }
            WebxCommonFN.AjaxPostRequest(validatedMobileNo);
        }
    });
    $("#btnClear").click(function () {
        $("#txtRegMobNo").val("");
    });
    //--------------------------Step 2 Popup------------------------------//
    $("#btnSubmitOTP").click(function () {
        var validatedOTP = {
            url: '/Home/CheckOTP',
            header: { 'VerificationToken': $("#forgeryToken").val() },
            data: {
                'OTP': $("#txtOTP").val(),
                'Type' : 'F'
            },
            successFunction: function (response) {
                if (response.success) {
                    if (response.OTPStatus == true) {
                        $("#Step1").hide();
                        $("#Step2").hide();
                        $("#Step3").show();
                    }
                    else
                    {
                        $("#Step1").hide();
                        $("#Step2").show();
                        $("#Step3").hide();
                    }
                }

            },
            errorFunction: Failed
        }
        WebxCommonFN.AjaxPostRequest(validatedOTP);
    });
    $("#btnClearOTP").click(function () {
        $("#txtOTP").val("");
    });
    $("#btnResend").click(function () {
        var validatedOTP = {
            url: '/Home/ResendOTP',
            header: { 'VerificationToken': $("#forgeryToken").val() },
            data: {
                'OTP': $("#txtOTP").val(),
                'Type': 'F'
            },
            successFunction: function (response) {
                if (response.success) {
                    if (response.objResentOTPStatus == "SUCCESS") {
                        $("#txtOTP").val("");   
                    }
                }

            },
            errorFunction: Failed
        }
        WebxCommonFN.AjaxPostRequest(validatedOTP);
    });
    //--------------------------Step 3 Popup------------------------------//
    $("#btnResetPwd").click(function () {
        var resendPwd = {
            url: '/Home/UpdateNewPassword',
            header: { 'VerificationToken': $("#forgeryToken").val() },
            data: {
                'Password': $("#txtPassword").val()
            },
            successFunction: function (response) {
                if (response.success) {
     /*               alert("Password save successfully.");*/
                    window.location.href = "/Home/Index";
                }

            },
            errorFunction: Failed
        }
        WebxCommonFN.AjaxPostRequest(resendPwd);


    });
    $("#btnClearPwd").click(function () {
        $("#txtPassword").val("");
        $("#txtConfirmPassword").val("");
    });
}