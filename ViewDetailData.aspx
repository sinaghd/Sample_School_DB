<%@ Language="C#" Inherits="ViewDetailDataPage.ViewDetailDataClass" CodeFile="ViewDetailData.aspx.cs" %>

<html>
    <head>
        <title>:: View Detail Data ::</title>
        <link href="style/style.css" rel="stylesheet" type="text/css">
        <link href="style/style_extra.css" rel="stylesheet" type="text/css">
        <link href="style/tabcontent.css" rel="stylesheet" type="text/css">
        <script language="javascript" type="text/javascript" src="scripts/ViewDetailDataScript.js"> </script>
    </head>

    <body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" bgcolor="#E0E0E0">
        <!-- student picture -->
        <div style="border: #808080 1px solid; height: 150px; left: 465px; position: absolute; top: 13px; width: 200px; z-index: 2;"><asp:Image id="StdImage" runat="server" width="200" height="150"></asp:Image></div>

        <!-- student detail -->
        <table width="650"  border="0" cellpadding="0" cellspacing="0">
            <form name="frmIdx" action="ViewDetailData.asp" method="post">
            <input type="hidden" name="isDelete">
            <input type="hidden" ID="StudentID" runat="server" name="stdid">
            <input type="hidden" name="iRecord">
            <tr height="5"><td colspan="4"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="170" align="right" class="headtext">Name:</td><td width="10">&nbsp;</td><td ID="FirstAndLastName" runat="server" width="460" class="headtext" style="color: blue"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="170" align="right" class="headtext">Nickname:</td><td width="10">&nbsp;</td><td ID="StdNickname" runat="server" width="460" class="textform"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="170" align="right" class="headtext">Status:</td><td width="10">&nbsp;</td><td ID="StdStatus" runat="server" width="460" class="headtext"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="170" align="right" class="headtext">Address:</td><td width="10">&nbsp;</td><td ID="StdAddress" runat="server" width="460" class="textform"></td></asp:tr>
            <tr><td width="10">&nbsp;</td><td width="170" align="right" class="headtext">Phone:</td><td width="10">&nbsp;</td><td ID="StdPhone" runat="server" width="460" class="textform"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="170" align="right" class="headtext">Email:</td><td width="10">&nbsp;</td><td ID="StdEmail" runat="server" width="460" class="textform"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="170" align="right" class="headtext">Country of Birth:</td><td width="10">&nbsp;</td><td ID="StdCOB" runat="server" width="460" class="textform"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="170" align="right" class="headtext">Nationality:</td><td width="10">&nbsp;</td><td ID="StdNationality" runat="server" width="460" class="textform"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="170" align="right" class="headtext"><i>Emergency Contact:</i></td><td width="10">&nbsp;</td><td ID="StdEmergencyContact" runat="server" width="460" class="textform"><i></i></td></tr>
            <tr><td width="10">&nbsp;</td><td width="170" align="right" class="headtext"><i>Emergency Address:</i></td><td width="10">&nbsp;</td><td ID="StdEmergencyAddress" runat="server" width="460" class="textform"><i></i></td></tr>
            <tr><td width="10">&nbsp;</td><td width="170" align="right" class="headtext"><i>Emergency Number:</i></td><td width="10">&nbsp;</td><td ID="StdEmergencyNumber" runat="server" width="460" class="textform"><i></i></td></tr>
            <tr><td width="10">&nbsp;</td><td width="170" align="right" class="headtext">Program Start Date:</td><td width="10">&nbsp;</td><td ID="StdProgramStartDate" runat="server" width="460" class="textform"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="170" align="right" class="headtext">Program End Date:</td><td width="10">&nbsp;</td><td ID="StdProgramEndDate" runat="server" width="460" class="textform"></td></tr>   
            <tr><td width="10">&nbsp;</td><td width="170" align="right" class="headtext">Score:</td><td width="10">&nbsp;</td><td width="460" ID="StdScore" runat="server" class="textform"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="170" align="right" class="headtext">Level:</td><td width="10">&nbsp;</td><td width="460" ID="StdLevel" runat="server" class="textform"></td></tr>   
            <tr><td width="10">&nbsp;</td><td width="170" align="right" class="headtext">Next Tuition Date:</td><td width="10">&nbsp;</td><td ID="StdTuitionDate" runat="server" width="460" class="textform" style="color: red;"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="170" align="right" class="headtext">Weeks of Study:</td><td width="10">&nbsp;</td><td ID="StdWeeks" runat="server" width="460" class="textform" style="color: red;"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="170" align="right" class="headtext">Earned Vacation:</td><td width="10">&nbsp;</td><td ID="StdEarnedVacation" runat="server" width="460" class="textform" style="color: red;"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="170" align="right" class="headtext">Remaining Vacation:</td><td width="10">&nbsp;</td><td ID="StdRemainingVacation" runat="server" width="460" class="textform" style="color: red;"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="170" align="right" class="headtext">Payment Email:</td><td width="10">&nbsp;</td><td ID="StdNotifiedPayment" runat="server" width="460" class="textform" style="color: red;"></td></tr>    
        </table>
        <!-- tab index -->
        <table width="650" border="0" cellpadding="0" cellspacing="0" align="center">
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td>
                    <ul id="studentDetails" class="shadetabs">
                        <li><a href="#" rel="details7" class="selected">Tuition History</a></li>
                        <li><a href="#" rel="details1">Tuition Notes</a></li>
                        <li><a href="#" rel="details2">Class Hour</a></li>
                        <li><a href="#" rel="details3">Vacation</a></li>
                        <li><a href="#" rel="details4">Warning</a></li>
                        <li><a href="#" rel="details5">Comments</a></li>
                        <li><a href="#" rel="details6">Notes</a></li>
                    </ul>
                    <div style="border: 1px solid gray; height: 145px; width: 650px;">
                        <div id="details7" class="tabcontent" style="height: 143px; overflow: auto; width: 648px;">
                            <form name="frmIdx" method="post">
                                <table width="631" border="0" cellpadding="0" cellspacing="0">                  
                                    <input type="hidden" name="random_number">
                                    <tr align="center" style="background: #AFC7C7">
                                        <td width="70" class="headtext">Date</td>
                                        <td width="1"><img src="/images/blank.gif" width="1" height="14" style="background-color: white"></td>
                                        <td width="50" class="headtext">Detail</td>
                                        <td width="1"><img src="/images/blank.gif" width="1" height="14" style="background-color: white"></td>
                                        <td width="50" class="headtext">TOTAL</td>
                                        <td width="1"><img src="/images/blank.gif" width="1" height="14" style="background-color: white"></td>
                                        <td width="50" class="headtext">weeks</td>
                                        <td width="1"><img src="/images/blank.gif" width="1" height="14" style="background-color: white"></td>
                                        <td width="140" class="headtext">When to When</td>
                                        <td width="1"><img src="/images/blank.gif" width="1" height="14" style="background-color: white"></td>
                                        <td width="266" class="headtext">Note</td>
                                    </tr>
                                    <tr><td colspan="11"><img src="/images/blank.gif" width="100%" height="1" style="background-color: white"></td></tr>
                                    <asp:Table ID="StdTable1" runat="server"></asp:Table>
                                </table>
                            </form>
                        </div>            

                        <div id="details1" class="tabcontent"><asp:Label ID="LabelTuitionPaymentNotes" runat="server"></asp:Label></div>
                        <div id="details2" class="tabcontent"><asp:Label ID="LabelClassHoursHistory" runat="server"></asp:Label></div>
            
                        <div id="details3" class="tabcontent" style="height: 143px; overflow: auto; width: 648px;">
                            <table width="353" border="0" cellpadding="0" cellspacing="0">
                                <tr align="center" style="background: #AFC7C7">
                                    <td width="100" class="headtext">Start Date</td>
                                    <td width="1"><img src="/images/blank.gif" width="1" height="14" style="background-color: white"></td>
                                    <td width="100" class="headtext">End Date</td>
                                    <td width="1"><img src="/images/blank.gif" width="1" height="14" style="background-color: white"></td>
                                    <td width="100" class="headtext">Week(s)</td>
                                    <td width="1"><img src="/images/blank.gif" width="1" height="14" style="background-color: white"></td>
                                    <td width="50" class="headtext">Delete</td>
                                </tr>
                                <tr><td colspan="7"><img src="/images/blank.gif" width="100%" height="1" style="background-color: white"></td></tr>
                                <asp:Table ID="StdTable2" runat="server"></asp:Table>
                            </table>                       
                        </div>
            
                        <div id="details4" class="tabcontent" style="color: red"><asp:Label ID="LabelWarningLetterInfo" runat="server"></asp:Label></div>
                        <div id="details5" class="tabcontent" style="color: red"><asp:Label ID="LabelComments" runat="server"></asp:Label></div>
                        <div id="details6" class="tabcontent"><br><asp:Label ID="LabelAdministrativeNotes" runat="server"></asp:Label></div>
                    </div>
                </td>
            </tr>
            <tr height="5"><td></td><tr>
            <tr>
                <td align="center"><input type="button" name="btnClose" value="Close" style="width: 120px" class="textform" onclick=" javascript:window.parent.close(); "></td>
            </tr>
        </form>
        </table>

    </body>
</html>

