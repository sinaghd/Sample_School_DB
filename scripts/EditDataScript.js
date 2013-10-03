function getLevel(score) {
    if (score > 91) {
        i = 7;
    } else if (score > 79) {
        i = 6;
    } else if (score > 69) {
        i = 5;
    } else if (score > 58) {
        i = 4;
    } else if (score > 47) {
        i = 3;
    } else if (score > 36) {
        i = 2;
    } else {
        i = 1;
    }

    document.frmIdx.CurrentLevel[i].selected = true;
}

function enableNote() {
    if (document.frmIdx.isUrgent.checked) {
        document.frmIdx.UrgentNote.disabled = false;
        document.frmIdx.UrgentNote.focus();
        ;
    } else {
        document.frmIdx.UrgentNote.disabled = true;
    }
}

function isUrgentCheck(x) {
    if (x == '1') {
        document.frmIdx.isUrgent.checked = true;
        document.frmIdx.UrgentNote.disabled = false;
    } else {
        document.frmIdx.isUrgent.checked = false;
        document.frmIdx.UrgentNote.disabled = true;
    }
}

function isTransferoutCheck(x) {
    if (x == '1') {
        document.frmIdx.isTransferout.checked = true;
    } else {
        document.frmIdx.isTransferout.checked = false;
    }
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

function editRecord(iAuthor, iRecord) {
    if (iAuthor != '1') {
        alert("Sorry, you are not allow to edit this record.");
    } else {
        var xMax = screen.width, yMax = screen.height;
        var childOpen, wW, wH;

        sPage = "EditVacation.asp";
        sPage = sPage + "?stdid=" +  <  %= stdid %  > +"&iRecord=" + iRecord;
        wW = 390;
        wH = 50;

        var xOffset = (xMax - wW) / 2, yOffset = (yMax - wH) / 2;
        childOpen = window.open(sPage, '', 'width=' + wW + ',height=' + wH + ',scrollbars=no,screenX=' + xOffset + ',screenY=' + yOffset + ',top=' + yOffset + ',left=' + xOffset + '');

        window.blur();
        childOpen.focus();
        return false;
    }
}