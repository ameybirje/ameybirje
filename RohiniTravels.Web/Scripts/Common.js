

var WebxCommonFN = {

    BindIgCombo: function (fieldName, DataSource) {

        var $comboDistrict = $("#" + fieldName);
        $comboDistrict.igCombo("deselectAll", {}, true);
        $comboDistrict.igCombo("option", "dataSource", DataSource);
        $comboDistrict.igCombo("dataBind");

    },

    GetDateDiffInMonth: function (fn_day, fn_month, fn_year) {

        debugger;

        fn_month =  (parseInt(fn_month) - 1 )

        var date1 = new Date(fn_year, fn_month, fn_day);
        var date2 = new Date();
       // var date2 = new Date(today.getFullYear(), today.getMonth() + 1, today.getDate());
        //date2.setMonth(date2.getMonth() + 1);

        var diffYears = date2.getFullYear() - date1.getFullYear();
        var diffMonths = date2.getMonth() - date1.getMonth();
        var diffDays = date2.getDate() - date1.getDate();

        var months = (diffYears * 12 + diffMonths);
        if (diffDays > 0) {
            months += '.' + diffDays;
        } else if (diffDays < 0) {
            months--;
            months += '.' + (new Date(date2.getFullYear(), date2.getMonth(), 0).getDate() + diffDays);
        }

        // alert(months);

        var a = months;

        return a.toString().split(".")[0];

    },

    GetDateCompare:function(Date1,Date2)
    {
    
        debugger;
        var firstValue = Date1.split('-');
        var secondValue = Date2.split('-');

                                  // Year          month              day
        var firstDate = new Date(firstValue[2], (firstValue[1] - 1), firstValue[0]);
        //firstDate.setFullYear(firstValue[0], (firstValue[1] - 1), firstValue[2]);

        //var first = firstDate.getDate(firstValue[0], (firstValue[1] - 1), firstValue[2]);
        var secondDate = new Date(secondValue[2], (secondValue[1] - 1), secondValue[0]);
        //secondDate.setFullYear(secondValue[0], (secondValue[1] - 1), secondValue[2]);

        if (firstDate < secondDate) {
           
            return  -1;
        }
        else if (firstDate.getTime() == secondDate.getTime()) {
            return 0;
        } 
        else {
            return 1;
        }

    },

    IsBlank: function (ctrlId) {


        if ($("#" + ctrlId).val() == '') {

            return '';

        }

        return $("#" + ctrlId).val();

    },

    IsIgComboSelected: function (igcomboId) {


        if ($("#" + igcomboId).igCombo("selectedItems") == null) {

            return true;

        }

        return false;

    },

    NumberSeparator: function (x) {

        x = Math.round(x)

        x = x.toString();
        var afterPoint = '';
        if (x.indexOf('.') > 0)
            afterPoint = x.substring(x.indexOf('.'), x.length);
        x = Math.floor(x);
        x = x.toString();
        var lastThree = x.substring(x.length - 3);
        var otherNumbers = x.substring(0, x.length - 3);
        if (otherNumbers != '')
            lastThree = ',' + lastThree;
        var res = otherNumbers.replace(/\B(?=(\d{2})+(?!\d))/g, ",") + lastThree + afterPoint;

        return res;
    
    },

    AjaxPostRequest: function (action_URL, Data, Successfn) {

        debugger;

        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: action_URL,
            data: Data,
            dataType: "json",
            success: Successfn,
            error: function (data) {

                return data;
            }

        });


    },

    AjaxGetRequest: function (action_URL, Data, Successfn) {

        debugger;

        $.ajax({
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            url: action_URL,
            data: Data,
            dataType: "json",
            success: Successfn,
            error: function (data) {

                return Json(data);
            }

        });


    },

    GetIndex: function (array, element) {

        return array.indexOf(element);

    },

    IsNull: function (element) {

        if (element === null || element === undefined) {

                return "";
        }
        
        return element;

    },

    TwoDigitDateFormat: function (n) {
        
        var ret = n > 9 ? "" + n : "0" + n;
        //return parseInt(n);
        return ret
    },

    IsValidEmailAddress : function (emailAddress) {
    
    var pattern = /^([a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+(\.[a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+)*|"((([ \t]*\r\n)?[ \t]+)?([\x01-\x08\x0b\x0c\x0e-\x1f\x7f\x21\x23-\x5b\x5d-\x7e\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|\\[\x01-\x09\x0b\x0c\x0d-\x7f\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))*(([ \t]*\r\n)?[ \t]+)?")@(([a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.)+([a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.?$/i;

    return pattern.test(emailAddress);

    },

    ValidateFullName: function (id) {

        if (/\w+\s+\w+/.test($("#" + id + "").val())) {

            return true;

        } else {
            return false;
        }
        e.preventDefault();

    },

    CheckLength: function (ctrlid,ln) {
    
        var ctrl_ln = $('#' + ctrlid).val()

        if (ctrl_ln.length < ln) {

            return false;
        }

        return true;    
    },

    Round: function (val) {

        return Math.round(val)
    },

    DateAdd: function (fn_day, fn_month, fn_year, no, type) {

        debugger;
        var date1 = new Date(fn_year, fn_month - 1, fn_day);

        if ( type == 'd' || type == 'D') {

            date1.setDate(date1.getDate() + no);
        }
        else if (type == 'm' || type == 'M')
        {
            date1.setMonth(date1.getMonth() + no);
        }
        else 
        {
            date1.setYear(date1.getFullYear() + no);
        }
        
        return date1;

    },

    DateSubstract: function (fn_day, fn_month, fn_year, no, type) {

    debugger;
    var date1 = new Date(fn_year, fn_month - 1, fn_day);

    if ( type == 'd' || type == 'D') {

        date1.setDate(date1.getDate() - no);
    }
    else if (type == 'm' || type == 'M')
    {
        date1.setMonth(date1.getMonth() - no);
    }
    else 
    {
        date1.setYear(date1.getFullYear() - no);
    }
        
    return date1;

    },

    calculateManualIdv: function (idv, minIdv, MaxIdv, manualIdv) {
        var vehcleIdv;
        vehcleIdv = idv;
        if (manualIdv < minIdv) {
            vehcleIdv = minIdv;
        }
        if (manualIdv > MaxIdv) {
            vehcleIdv = MaxIdv;
        }
        if (manualIdv >= minIdv && manualIdv <= MaxIdv) {
            vehcleIdv = manualIdv;
        }
        return vehcleIdv;
    },

    GetEncryptVal: function (Val) {
        debugger
        var key = CryptoJS.enc.Utf8.parse('8080808080808080');
        var iv = CryptoJS.enc.Utf8.parse('8080808080808080');

        var encryptedAES = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(Val), key,
             {
                 keySize: 128 / 8,
                 iv: iv,
                 mode: CryptoJS.mode.CBC,
                 padding: CryptoJS.pad.Pkcs7
             });

        return encryptedAES;


    },

    PostData: function (Url, successfn) {

        $http({
            method: 'POST',
            url: Url,
            data: {}
        }).success(successfn);

    },

    AjaxPostRequestError: function (requiredFields) {
    debugger;
    $.ajax({

        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: requiredFields.url,
        data: JSON.stringify(requiredFields.data),
        //data: requiredFields.data,
        dataType: "json",
        success: requiredFields.successFunction,
        error: requiredFields.errorFunction
    });
}


}

