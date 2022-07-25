function NoAccess() {
    alert("You dont have access to create new country. Please contact your administrator.");
    return false;
}

const monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun",
                        "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
];

function InputNumber(e) {
    $("#" + e.id).keyup(function (event) {
        if (event.which >= 37 && event.which <= 40) return;
        $(this).val(function (index, value) {
            return value
            // Keep only digits and decimal points:
            .replace(/[^\d.-]/g, "")
            // Remove duplicated decimal point, if one exists:
            .replace(/^(\d*\.)(.*)\.(.*)$/, '$1$2$3')
            // Keep only two digits past the decimal point:
            .replace(/\.(\d{2})\d+/, '.$1')
            // Add thousands separators:
            .replace(/\B(?=(\d{3})+(?!\d))/g, ",")
        });
    });
}

function RemoveAllComma(x) {
    if (x != null && x !== 'undefined') {
        return x.replaceAll(",", "");
    }
}

// Date Format MM/dd/yyyy
function AddYear(date, value) {
    var eDate = new Date(date);
    var eYear = parseFloat(eDate.getFullYear()) + parseFloat(value);
    var eFullDate = new Date((eDate.getMonth() + 1).toString() + "/" + eDate.getDate().toString() + "/" + eYear.toString());
}

function InputNumberMinus(e) {
    $("#" + e.id).keyup(function (event) {
        //if (event.which >= 37 && event.which <= 40) return;
        if (event.which >= 37 && event.which <= 40 && event.which != 46 && event.which != 45 && event.which != 46 &&
  !(event.which >= 48 && event.which <= 57)) return;
        $(this).val(function (index, value) {
            return value
            // Keep only digits and decimal points:
            .replace(/[^\d.-]/g, "")
            // Remove duplicated decimal point, if one exists:
            .replace(/^(\d*\.)(.*)\.(.*)$/, '$1$2$3')
            // Keep only two digits past the decimal point:
            .replace(/\.(\d{2})\d+/, '.$1')
            // Add thousands separators:
            .replace(/\B(?=(\d{3})+(?!\d))/g, ",")
        });
    });
}



//Untuk input hanya angka di event keypress
function isNumber(evt, element) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (
        (charCode != 46 || $(element).val().indexOf('.') != -1) &&      // “.” CHECK DOT, AND ONLY ONE.
        (charCode < 48 || charCode > 57))
        return false;
    return true;
}

function AddCommaDecimal(numb) {
   return numb.toString().replace(/[^\d.-]/g, "")
                // Remove duplicated decimal point, if one exists:
                .replace(/^(\d*\.)(.*)\.(.*)$/, '$1$2$3')
                // Keep only two digits past the decimal point:
                .replace(/\.(\d{2})\d+/, '.$1')
                // Add thousands separators:
                .replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

//
function GetPeriod(period) {
  //  const monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun",
  //"Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
  //  ];

  //  period = monthNames[parseInt(period.substring(4, 6))] + " " + new Date().getFullYear();

  //  alert(period);

    return period;
}

function ExpandTreeView_(url_) {
    $('ul.nav-treeview a').filter(function () {
        return this.pathname == url_;
    }).parentsUntil(".nav-sidebar > .nav-treeview").css({ 'display': 'block' }).addClass('menu-open').prev('a').addClass('active');

    $('ul.nav-sidebar a').filter(function () {
        return this.pathname == url_;
    }).addClass('active');
}

function setAttributes(element, attributes) {
    Object.keys(attributes).forEach(attr => {
        element.setAttribute(attr, attributes[attr]);
    });
}


function CreateSelect(nama_, id_, select2D_) {
    var databal = "";
    databal += " <div class='form-group row mb-1'>";
    databal += "                        <label class='col-sm-4 control-label'>" + nama_ + "</label>";
    databal += "                         <div class='col-sm-8'>";
    databal += "                             <select class='form-control form-control-sm " + select2D_ + "' id='" + id_ + "'></select>";
    databal += "                         </div>";
    databal += "                     </div>";
    return databal;
}


function CreateEditeTextModal(type_,id_,nama_) {
    var databal = "";
    databal += " <div class='form-group row mb-1'>";
    databal += "                        <label class='col-sm-4 control-label'>" + nama_ +"</label>";
    databal += "                         <div class='col-sm-8'>";
    databal += "                             <input type='" + type_ + "' id='" + id_ +"' class='form-control form-control-sm' />";
    databal += "                         </div>";
    databal += "                     </div>";
    return databal;    
}

function CreateErrorPublic(idelem, msg) {
    var x = document.getElementById(idelem);
    var button = document.createElement('button');
    button.type = "Submit";
    button.innerHTML = msg;
    button.id = "btn" + idelem
    button.className = "btn btn-sm btn-danger"
    button.onclick = function () {
        document.getElementById(button.id).remove();
    };
    x.appendChild(button);
    insertAfterx(x, button);
    x.addEventListener("click", function () {
        document.getElementById(button.id).remove();
    });
}

function CreateErrorBosstrap(elem,msg) {
    var button = document.createElement('button');
    button.type = "Submit";
    button.innerHTML = msg;
    button.id = "btn" + idelem
    button.className = "btn btn-sm btn-danger"
    button.onclick = function () {
        document.getElementById(button.id).remove();
    };
    elem.appendChild(button);
    insertAfterx(elem, button);
    elem.addEventListener("click", function () {
        document.getElementById(button.id).remove();
    });
}

function insertAfterx(referenceNode, newNode) {
    referenceNode.parentNode.insertBefore(newNode, referenceNode.nextSibling);
}

function BtnLoading(elem) {
    $(elem).attr("data-original-text", $(elem).html());
    $(elem).prop("disabled", true);
    //$(elem).html('<i class="spinner-border spinner-border-sm"></i>');
    $(elem).html('<i class="spinner-border spinner-border-sm"></i> Loading...');
}

function BtnReset(elem) {
    $(elem).prop("disabled", false);
    $(elem).html($(elem).attr("data-original-text"));
}

function GetDateToday() {
    var d = new Date();
    var datestring = d.getFullYear() + "-" + (d.getMonth() + 1) + "-" + d.getDate() + " " + d.getHours() + ":" + d.getMinutes() + ":" + d.getSeconds();
    return datestring;
}

function copyToClipboard(text) {
    var sampleTextarea = document.createElement("textarea");
    document.body.appendChild(sampleTextarea);
    sampleTextarea.value = text; //save main text in it
    sampleTextarea.select(); //select textarea contenrs
    document.execCommand("copy");
    document.body.removeChild(sampleTextarea);
}
