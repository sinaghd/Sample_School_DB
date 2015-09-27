
function opendialogWin(act, sPage) {
    // Open dialog windows; open a child window
    var xMax = screen.width, yMax = screen.height;
    var childOpen, wW, wH;

    if (document.frmIdx.stdid.value == "" && act != "add") {
        alert("Please select a record.");
    } else {
        if (act != "add") { // view, pay or delete
            sPage = sPage + "&stdid=" + document.frmIdx.stdid.value;
        }

        if (act == "add") {
            wW = 598;
            wH = 750;
        } else if (act == "view") {
            wW = 700;
            wH = 720;
        } else if (act == "pay") {
            wW = 425;
            wH = 500;
        } else if (act == "transcript") {
            wW = 980;
            wH = 600;
        } else {
            wW = 598;
            wH = 900;
        }

        var xOffset = (xMax - wW) / 2, yOffset = (yMax - wH) / 2;
        
        childOpen = window.open(sPage, '', 'width=' + wW + ',height=' + wH + ',scrollbars=yes,screenX=' + xOffset + ',screenY=' + yOffset + ',top=' + yOffset + ',left=' + xOffset + '');
       
        window.blur();
        childOpen.focus();
        return false;
    }
}



function opendialogWin2(act, sPage) {
    // Open dialog window WITH menu bar; open a child window 
    var xMax = screen.width, yMax = screen.height;
    var childOpen, wW, wH;

    if (document.frmIdx.stdid.value == "" && act != "add") {
        alert("Please select a record.");
    } else {
        if (act != "add") { // view, pay or delete
            sPage = sPage + "&stdid=" + document.frmIdx.stdid.value;
        }

        if (act == "add") {
            wW = 598;
            wH = 750;
        } else if (act == "view") {
            wW = 700;
            wH = 720;
        } else if (act == "pay") {
            wW = 425;
            wH = 500;
        } else if (act == "transcript") {
            wW = 980;
            wH = 600;
        } else {
            wW = 598;
            wH = 900;
        }

        var xOffset = (xMax - wW) / 2, yOffset = (yMax - wH) / 2;
        
        childOpen = window.open(sPage, '', 'menubar=1,toolbar=1,width=' + wW + ',height=' + wH + ',scrollbars=yes,screenX=' + xOffset + ',screenY=' + yOffset + ',top=' + yOffset + ',left=' + xOffset + '');
        
        window.blur();
        childOpen.focus();
        return false;
    }
}



function checkClass(x) {
    alert(x.name);
}

function showReport(my, sPage) {
    var iArray;
    if (my != "") {
        x = my.value;
        iArray = x.split(",");
        month = iArray[0];
        year = iArray[1];

        sPage = sPage + "?month=" + month + "&year=" + year;
        document.frmIdx.action = sPage;
        document.frmIdx.submit();
    }
}



function deleteRecord(sPage) {
    if (document.frmIdx.stdid.value == "") {
        alert("Please select a record.");
    } else {
        var answer = confirm("Do you want to delete this record?");
        if (answer) {
            document.frmIdx.isDelete.value = "yes";
            document.frmIdx.action = sPage;
            document.frmIdx.submit();
        }
    }
}



var curSelected = null;
var previousColor = null;

function selectRow(row, stdid, bgcolor) {
    if (curSelected != null) {
        curSelected.style.backgroundColor = previousColor;
        curSelected.style.color = '#000000';
    }

    previousColor = bgcolor;
    curSelected = row;
    row.style.backgroundColor = '#316AC5';
    row.style.color = '#FFFFFF';
    document.frmIdx.stdid.value = stdid;
}



function Set(row, Cursor) {
    row.style.cursor = Cursor;
}



function logOut() {
    if (confirm("Are you sure you want to exit?") == true) {
        document.location = "logout.aspx";
        return true;
    }
} 