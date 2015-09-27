
function getLevel() {
    score = document.frmIdx.TestScoreHistory.value;
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