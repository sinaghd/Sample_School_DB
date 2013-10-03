function opendialogWin(sPage) {
    // Open dialog windows; open a child window
    var xMax = screen.width, yMax = screen.height;
    var childOpen;
    var wW;
    wW = 643;
    wH = 900;

    sPage += "?random_number=" + document.frmIdx.random_number.value;

    var xOffset = (xMax - wW) / 2, yOffset = (yMax - wH) / 2;
    childOpen = window.open(sPage, '', 'width=' + wW + ',height=' + wH + ',scrollbars=no,screenX=' + xOffset + ',screenY=' + yOffset + ',top=' + yOffset + ',left=' + xOffset + '');

    window.blur();
    childOpen.focus();
    return false;
}

var curSelected = null;
var previousColor = null;

function selectRow(row, rdn, bgcolor) {
    if (curSelected != null) {
        curSelected.style.backgroundColor = previousColor;
        curSelected.style.color = '#000000';
    }

    previousColor = bgcolor;
    curSelected = row;
    row.style.backgroundColor = '#316AC5';
    row.style.color = '#FFFFFF';
    document.frmIdx.random_number.value = rdn;
}

function Set(row, Cursor) {
    row.style.cursor = Cursor;
}

function delRecord(iAuthor, iRecord) {
    if (iAuthor != '1') {
        alert("Sorry, you are not allow to delete this record.");
    } else {
        var answer = confirm("Do you want to delete this record?");
        if (answer) {
            document.frmIdx.iRecord.value = iRecord;
            document.frmIdx.isDelete.value = "yes";
            document.frmIdx.submit();
        }
    }
}