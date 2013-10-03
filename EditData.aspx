<%@ Language="C#" Inherits="EditDataPage.EditDataClass" CodeFile="EditData.aspx.cs" %>

<html>
    <head>
        <title>:: Edit Data ::</title>
        <link href="style/style.css" rel="stylesheet" type="text/css">
        <script language="javascript" type="text/javascript" src="scripts/EditDataScript.js"> </script>
    </head>

    <body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" bgcolor="#E0E0E0">
        <table width="570" border="0" cellpadding="0" cellspacing="0">
            <form runat="server" ID="frmIdx" name="frmIdx" action="EditData.aspx" method="post" enctype="multipart/form-data">
            <input type="hidden" ID="StudentID" runat="server" name="stdid">
            <input type="hidden" ID="StudentImageHidden" runat="server" name="StudentImage">
            <input type="hidden" ID="isDisabledText" runat="server" name="isDisabled">
            <input type="hidden" name="isDelete">
            <input type="hidden" name="isEdit">
            <input type="hidden" name="iRecord">
            <tr height="8"><td colspan="4"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Last Name:</td><td width="10">&nbsp;</td><td width="380" class="textform"><input runat="server" ID="LastName_str" type="text" name="LastName" class="textform"><img src="" style="height: 1px; width: 10px;"><font class="headtext">First Name:</font><img src="/images/blank.gif" style="height: 1px; width: 10px;"><input runat="server" ID="FirstName_str" type="text" name="FirstName" class="textform"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Nickname:</td><td width="10">&nbsp;</td><td width="380" class="textform"><input runat="server" ID="Nickname_str" type="text" name="Nickname" class="textform"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Status:</td><td width="10">&nbsp;</td><td width="380" class="textform"><asp:DropDownList runat="server" ID="StatusDropDownList" style="width: 235px" class="textform"></asp:DropDownList>&nbsp;
            <input type="checkbox" name="isTransferout" class="headtext"><font class="headtext" style="color: red">Transfer Out</font></td></tr>
            <tr><td width="10">&nbsp;</td><td width="150" class="headtext" align="right"></td><td width="10">&nbsp;</td><td width="380" class="textform"><input type="checkbox" name="isUrgent" class="headtext" onClick=" enableNote(); "><font class="headtext" style="color: red">Urgent  :  </font><input runat="server" ID="UrgentNote_str" type="text" name="UrgentNote" style="width: 290px" class="textform" maxlength="40"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Address:</td><td width="10">&nbsp;</td><td width="380" class="textform"><input runat="server" ID="Address_str" type="text" name="Address" style="width: 367px" class="textform"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Phone:</td><td width="10">&nbsp;</td><td width="380" class="textform"><input runat="server" ID="PhoneNumber_str" type="text" name="PhoneNumber" style="width: 200px" class="textform"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Email:</td><td width="10">&nbsp;</td><td width="380" class="textform"><input runat="server" ID="Email_str" type="text" name="Email" style="width: 200px" class="textform"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Country of Birth:</td><td width="10">&nbsp;</td><td width="380" class="textform"><input runat="server" ID="CountryOfBirth_str" type="text" name="CountryOfBirth" class="textform"><img src="/images/blank.gif" style="height: 1px; width: 10px;"><font class="headtext">Nationality:</font><img src="/images/blank.gif" style="height: 1px; width: 10px;"><input runat="server" ID="Nationality_str" type="text" name="Nationality" class="textform"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="150" class="headtext" align="right" style="background-color: #CCCCCC">Emergency Contact:</td><td width="10" style="background-color: #CCCCCC">&nbsp;</td><td width="380" class="textform" style="background-color: #CCCCCC"><input runat="server" ID="EmergencyContact_str" type="text" name="EmergencyContact" style="width: 200px" class="textform"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="150" class="headtext" align="right" style="background-color: #CCCCCC">Emergency Address:</td><td width="10" style="background-color: #CCCCCC">&nbsp;</td><td width="380" class="textform" style="background-color: #CCCCCC"><input runat="server" ID="EmergencyAddress_str" type="text" name="EmergencyAddress" style="width: 367px" class="textform"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="150" class="headtext" align="right" style="background-color: #CCCCCC">Emergency Number:</td><td width="10" style="background-color: #CCCCCC">&nbsp;</td><td width="380" class="textform" style="background-color: #CCCCCC"><input runat="server" ID="EmergencyNumber_str" type="text" name="EmergencyNumber" style="width: 200px" class="textform"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="150" class="headtext" align="right" style="background-color: #CCCCCC">Emergency Email:</td><td width="10" style="background-color: #CCCCCC">&nbsp;</td><td width="380" class="textform" style="background-color: #CCCCCC"><input runat="server" ID="EmergencyEmail_str" type="text" name="EmergencyEmail" style="width: 200px" class="textform"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Program Start Date:</td><td width="10">&nbsp;</td><td width="380" class="textform"><input runat="server" ID="ProgramStartDate_str" type="text" name="ProgramStartDate" style="width: 75px" maxlength="10" class="textform"><img src="/images/blank.gif" style="height=; width: 10px; 1px"><font class="headtext">Program End Date:</font><img src="/images/blank.gif" style="height=; width: 10px; 1px"><input runat="server" ID="ProgramEndDate_str" type="text" name="ProgramEndDate" style="width: 75px" maxlength="10" class="textform"></td></tr>
            <tr><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Placement  Score:</td><td width="10">&nbsp;</td><td width="380" class="textform"><input runat="server" ID="TestScoreHistory_str" type="text" name="TestScoreHistory" style="width: 75px" maxlength="2" class="textform" onBlur="javascript:getLevel(this.value);"><img src="/images/blank.gif"  style="height=; width: 32px; 1px;"><font class="headtext">Exit Score:</font><img src="/images/blank.gif"  style="height=; width: 10px; 1px;"><input runat="server" ID="ExitScoreHistory_str" type="text" name="ExitScoreHistory" style="width: 75px" maxlength="2" class="textform"></td></tr>

            <tr><td width="10">&nbsp;</td><td width="150" class="headtext" align="right"><font class="headtext">Level:</font><td width="10">&nbsp;</td><td class="textform"><asp:DropDownList  runat="server" ID="CurrentLevelDropDownList" style="width: 136px" class="textform"></asp:DropDownList>
                                                                                                                                                   </td></tr>   
            <tr><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Payment Email:</td><td width="10">&nbsp;</td><td class="textform"><asp:Label ID="LabelNotifyPayment" runat="server"></asp:Label></td></tr>
            <tr><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Next Tuition Date:</td><td width="10">&nbsp;</td><td class="textform"><input runat="server" ID="TuitionPaymentDate_str" type="text" name="TuitionPaymentDate" style="width: 75px" maxlength="10" class="textform"></td></tr>
            <tr valign="top"><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Administrative Notes:<br>(If any)</td><td width="10">&nbsp;</td><td width="380" class="textform"><textarea runat="server" ID="AdministrativeNotes_str" style="height=; width: 400px; 50px;" name="AdministrativeNotes" class="textform"></textarea></td></tr>
            <tr valign="top"><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Student Tuition Notes:<br>(If any)</td><td width="10">&nbsp;</td><td width="380" class="textform"><textarea runat="server" ID="TuitionPaymentNotes_str" style="height=; width: 400px; 50px;" name="TuitionPaymentNotes" class="textform"></textarea></td></tr>

            <tr valign="top"><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Weeks of Study:</td><td width="10">&nbsp;</td><td width="380"  class="headtext"><asp:Label ID="LabelStudentWeeks" runat="server"></asp:Label></td></tr>
            <tr valign="top"><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Earned Vacation:</td><td width="10">&nbsp;</td><td width="380"  class="headtext"><asp:Label ID="LabelEarnedVacation" runat="server"></asp:Label></td></tr>
            <tr valign="top"><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Remaining Vacation:</td><td width="10">&nbsp;</td><td width="380"  class="headtext" style="color: blue;"><asp:Label ID="LabelRemainingVacation" runat="server"></asp:Label></td></tr>

            <!-- Vacation -->

            <tr><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Vacation:</td><td width="10">&nbsp;</td><td class="textform">Start:&nbsp;<input type="text" name="VacationStartDate" style="width: 75px" maxlength="10" class="textform">&nbsp;End:&nbsp;<input type="text" name="VacationEndDate" style="width: 75px" maxlength="10" class="textform">&nbsp;Week(s):&nbsp;<input type="text" name="VacationWeeks" style="width: 17px" maxlength="1" class="textform"></td></tr>
            <tr valign="top"><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Vacation History:</td><td width="10">&nbsp;</td>
                <td width="380" class="textform">            
                    <div id="details3" style="height: 100px; overflow: auto; width: 380px;">
                        <table width="364" border="0" cellpadding="0" cellspacing="0">
                            <tr align="center" style="background: #AFC7C7">
                                <td width="100" class="headtext">Start Date</td>
                                <td width="1"><img src="/images/blank.gif" width="1" height="14" style="background-color: white"></td>
                                <td width="100" class="headtext">End Date</td>
                                <td width="1"><img src="/images/blank.gif" width="1" height="14" style="background-color: white"></td>
                                <td width="60" class="headtext">Week(s)</td>
                                <td width="1"><img src="/images/blank.gif" width="1" height="14" style="background-color: white"></td>
                                <td width="50" class="headtext">Edit</td>
                                <td width="1"><img src="/images/blank.gif" width="1" height="14" style="background-color: white"></td>
                                <td width="50" class="headtext">Delete</td>
                            </tr>
                            <tr><td colspan="9"><img src="/images/blank.gif" width="100%" height="1" style="background-color: white"></td></tr>
                            <asp:Table ID="StdTable1" runat="server"></asp:Table>   
                        </table>                       
                    </div></td></tr>


            <!-- Medical Leave -->

            <tr><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Medical or Emergency Leave:</td><td width="10">&nbsp;</td><td class="textform">Start:&nbsp;<input type="text" name="MedLeaveStartDate" style="width: 75px" maxlength="10" class="textform">&nbsp;End:&nbsp;<input type="text" name="MedLeaveEndDate" style="width: 75px" maxlength="10" class="textform">&nbsp;Week(s):&nbsp;<input type="text" name="MedLeaveWeeks" style="width: 25px" maxlength="3" class="textform"></td></tr>
            <tr valign="top"><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Medical/Emergency Leave History:</td><td width="10">&nbsp;</td>
                <td width="380" class="textform">            
                    <div id="details4" style="height: 100px; overflow: auto; width: 380px;">
                        <table width="364" border="0" cellpadding="0" cellspacing="0">
                            <tr align="center" style="background: #AFC7C7">
                                <td width="100" class="headtext">Start Date</td>
                                <td width="1"><img src="/images/blank.gif" width="1" height="14" style="background-color: white"></td>
                                <td width="100" class="headtext">End Date</td>
                                <td width="1"><img src="/images/blank.gif" width="1" height="14" style="background-color: white"></td>
                                <td width="60" class="headtext">Week(s)</td>
                                <td width="1"><img src="/images/blank.gif" width="1" height="14" style="background-color: white"></td>
                                <td width="50" class="headtext">Edit</td>
                                <td width="1"><img src="/images/blank.gif" width="1" height="14" style="background-color: white"></td>
                                <td width="50" class="headtext">Delete</td>
                            </tr>
                            <tr><td colspan="9"><img src="/images/blank.gif" width="100%" height="1" style="background-color: white"></td></tr>
                            <asp:Table ID="StdTable2" runat="server"></asp:Table>  
                        </table>                       
                    </div>
                </td></tr>


            <!-- Student Progress -->
  
            <tr><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Student Progress:</td><td width="10">&nbsp;</td><td class="textform">Date (e.g. 2011-09-15):&nbsp;<input type="date" name="ProgressDate" style="width: 75px" maxlength="10">&nbsp;&nbsp;Level Entered:&nbsp;<input type="text" name="ProgressLevel" style="width: 17px" maxlength="1" class="textform"></td></tr>
            <tr valign="top"><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Student Progress History:</td><td width="10">&nbsp;</td>
                <td width="380" class="textform">            
                    <div id="details5" style="height: 100px; overflow: auto; width: 380px;">
                    <table width="364" border="0" cellpadding="0" cellspacing="0">
                    <tr align="center" style="background: #AFC7C7">
                        <td width="100" class="headtext">Date</td>
                        <td width="1"><img src="/images/blank.gif" width="1" height="14" style="background-color: white"></td>                    
                        <td width="60" class="headtext">Level Entered</td>
                        <td width="1"><img src="/images/blank.gif" width="1" height="14" style="background-color: white"></td>                    
                    </tr>
                    <tr><td colspan="9"><img src="/images/blank.gif" width="100%" height="1" style="background-color: white"></td></tr>
                    <asp:Table ID="StdTable3" runat="server"></asp:Table>   
                </td></tr>
        </table>                       
    </div>
    </td></tr>

        <tr valign="top"><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Class Hours History:</td><td width="10">&nbsp;</td><td width="380" class="textform"><textarea runat="server" ID="ClassHoursHistory_str" style="height=; width: 400px; 50px;" name="ClassHoursHistory" class="textform"></textarea></td></tr>
        <tr valign="top"><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Warning Letter Info:<br>(If any)</td><td width="10">&nbsp;</td><td width="380" class="textform"><textarea runat="server" ID="WarningLetterInfo_str" style="height=; width: 400px; 50px;" name="WarningLetterInfo" class="textform"></textarea></td></tr>    

        <tr valign="top"><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Comments:<br>(If any)</td><td width="10">&nbsp;</td><td width="380" class="textform"><textarea runat="server" ID="Comments_str" style="height=; width: 400px; 50px;" name="Comments" class="textform"></textarea></td></tr>

        <tr><td width="10">&nbsp;</td><td width="150" class="headtext" align="right">Image: </td><td width="10">&nbsp;</td><td width="380" class="textform"><asp:FileUpload id="StudentPic" runat="server" style="width: 300px;" class="textform"></asp:FileUpload>&nbsp;<input type="checkbox" name="isDeleteImage"><font class="headtext" style="color: red">DELETE</font></td></tr>
     
        <tr height="8"><td colspan="4"></td></tr>
        <tr><td width="10">&nbsp;</td><td width="150" class="headtext">&nbsp;</td><td width="10">&nbsp;</td><td width="380" class="textform"><asp:Button type="submit" name="btnSave" Text="Save Change" style="width: 120px" runat="server" onserverclick="UploadBtn_Click" class="textform"></asp:Button>&nbsp;<input type="button" name="btnCancel" value="Cancel" style="width: 120px" class="textform" onClick=" javascript:window.parent.close(); "></td></tr>         
      
        <tr height="8"><td colspan="4"></td></tr>
    </form>
    </table>

    </body>
</html>