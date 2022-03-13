$(document).ready(function () {
    $('#btnSave').click(function () {
        debugger;
        var RegCollection = {};
        RegCollection.FirstName = $('#PropStudentDetails_FirstName').val();
        RegCollection.MiddleName = $('#PropStudentDetails_MiddleName').val();
        RegCollection.LastName = $('#PropStudentDetails_LastName').val();
        RegCollection.Gender = $("[name='PropStudentDetails.Gender']:checked").val();
        RegCollection.DOB = $('#PropStudentDetails_DOB').val();
        RegCollection.Standared = $('#PropStudentDetails_Standared').val();
        RegCollection.ParentName = $('#PropStudentDetails_ParentName').val();
        RegCollection.ParentMobile = $('#PropStudentDetails_ParentMobile').val();
        RegCollection.ParentOtherNo = $('#PropStudentDetails_ParentOtherNo').val();
        RegCollection.ParentEmail = $('#PropStudentDetails_ParentEmail').val();
        RegCollection.Address = $('#PropStudentDetails_Address').val();
        RegCollection.Pincode = $('#PropStudentDetails_Pincode').val();
        RegCollection.LoginID = $('#PropStudentDetails_LoginID').val();
        RegCollection.Password = $('#PropStudentDetails_Password').val();
        RegCollection.PropStudentDetails = RegCollection;
        var requiredFields = { 'url': SaveReg_URL, 'data': RegCollection, 'successFunction': fnRegResponse, 'errorFunction': Error };
        WebxCommonFN.AjaxPostRequestError(requiredFields);

    });


});

function fnRegResponse(Data) {
    debugger;
    if (Data.Success != null) {
       // window.location.href = viewquote_URL + "?SLG=" + WebxCommonFN.GetEncryptVal(Data.EnquiryID);
    }
    else {
        alert(Data.ErrorMessage);
    }
}