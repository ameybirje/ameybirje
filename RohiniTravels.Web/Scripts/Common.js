var MobileNumberRegex = /^\d{10}$/;
var OnlyNumberRegex = /^\d+$/;
var PasswrodRegex = /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$/;
var AlphabetRegex = /^[a-zA-Z]*$/;
var EmailRegex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;

var WebxCommonFN = {

    ValidateEmptyFields: function (controlsToValidate) {
        var isValid = true, setFocus = true;
        for (var index = 0; index < controlsToValidate.length; index++) {
            var control = $(controlsToValidate[index]).prop('control');
            var errorMessage = $(controlsToValidate[index]).prop('errorMessage');
            var lblControl = $(controlsToValidate[index]).prop('lblControl');
            if (WebxCommonFN.IsControlEmpty(control)) {
                isValid = false;
                $(lblControl).text(errorMessage);
                $(lblControl).show();
                if (setFocus) {

                    setFocus = false;
                    if ($(control).is("input"))
                        $(control).focus();
                    else if ($(control).is("select"))
                        $(control).focus().select();
                    //else
                        //IgCommon.SetIgcomboFocus(control);
                }

            }
            else
                $(lblControl).text("");

        }
        return isValid;
    }, 

    IsControlEmpty: function (control) {
        //control = $(control).val().trim();
        control = $(control).val();
        return (control == "" || control == null);
    },

    ValidateMobileNumber: function (control) {
        var containsAlphabets = MobileNumberRegex.test($(control).val());
        return containsAlphabets;
    },

    AttachChangeListener: function (controlsToValidate) {

        for (var index = 0; index < controlsToValidate.length; index++) {
            var control = $(controlsToValidate[index]).prop('control');
            var errorMessage = $(controlsToValidate[index]).prop('errorMessage');
            var labelControl = $(controlsToValidate[index]).prop('lblControl');

            WebxCommonFN.OnChangeListener(control, errorMessage, labelControl);
        }
    },

    OnChangeListener: function (control, errorMessage, labelControl) {
        $(control).on('input', function () {

            if (WebxCommonFN.IsControlEmpty(control)) {
                $(labelControl).text(errorMessage);
                $(labelControl).show()
            }           
            else {
                $(labelControl).text('');
                $(labelControl).hide()
            }
                
        });
    },


    ContainsOnlyNumber: function (control) {
        if ($(control).val() != "")
            return OnlyNumberRegex.test($(control).val());
        else
            return true;
    },


    ValidateMobileNumber: function (control) {
        var containsAlphabets = MobileNumberRegex.test($(control).val());
        return containsAlphabets;
    },

    ValidatePassword: function (control) {
        return PasswrodRegex.test($(control).val());
        
    },

    DisplayError: function (control,errorMsg) {
        $(control).show()
        $(control).text(errorMsg)
    },

    HideError: function (control) {
        $(control).text('')
        $(control).hide()
    },

    ValidateAlphabet: function (control) {
        return AlphabetRegex.test($(control).val());
    },

    ValidateEmail: function (control) {

        return EmailRegex.test($(control).val());
    },

    AjaxPostRequest: function (requiredFields) {

        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: requiredFields.url,
            headers: requiredFields.header,
            data: JSON.stringify(requiredFields.data),
            dataType: "json",
            success: requiredFields.successFunction,
            error: requiredFields.errorFunction
        });
    },

}

