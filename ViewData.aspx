<%@ Language="C#" Inherits="ViewDataPage.ViewDataClass" CodeFile="ViewData.aspx.cs" %>

<html>

    <head>
        <title>:: View Data ::</title>
        <link href="style/style.css" rel="stylesheet" type="text/css">
        <link href="style/style_extra.css" rel="stylesheet" type="text/css">
        <script language="javascript" type="text/javascript" src="scripts/ViewDataScript.js"> </script>
    </head>

    <body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
        <!-- table -->
        <table width="977" border="0" cellpadding="0" cellspacing="0" align="center">
            <form name="frmIdx" method="post" runat="server">
                <input type="hidden" name="stdid">
                <input type="hidden" name="ilike">
                <input type="hidden" name="level">
                <input type="hidden" name="status">
                <input type="hidden" name="urgent">
                <input type="hidden" name="vacation">
                <input type="hidden" name="transferout">
                <input type="hidden" name="isDelete">
                <input type="hidden" name="orderby">
                <tr height="3"><td></td></tr>
                <tr>
                    <td>
                        <table width="977" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="680" class="headtext">&nbsp;
                                    <a href="javascript:document.frmIdx.ilike.value=''; document.frmIdx.submit();">All</a>          
                                    <asp:PlaceHolder ID="LastnameLinksPlaceHolder" runat="server"></asp:PlaceHolder>&nbsp;:&nbsp;
                                    <a href="javascript:document.frmIdx.urgent.value='1'; document.frmIdx.submit();">!!!</a>&nbsp;&nbsp;
                                    <a href="javascript:document.frmIdx.status.value='2'; document.frmIdx.submit();">PR</a>&nbsp;&nbsp;
                                    <a href="javascript:document.frmIdx.status.value='3, 4, 5'; document.frmIdx.submit();">INA</a>&nbsp;:&nbsp;
                                    <a href="javascript:document.frmIdx.vacation.value='1'; document.frmIdx.submit();">V/C</a>&nbsp;:&nbsp;
                                    <a href="javascript:document.frmIdx.transferout.value='1'; document.frmIdx.submit();">T/O</a>&nbsp;:&nbsp;
                                    <a href="javascript:document.frmIdx.status.value='6'; document.frmIdx.submit();">P/O</a>&nbsp;:&nbsp;
                                    <a href="javascript:document.frmIdx.status.value='0'; document.frmIdx.submit();">DEL</a>&nbsp;
                                </td>
                                <td  width="220" class="headtext" align="right">&nbsp;
                                    <a href="javascript:document.frmIdx.level.value=''; document.frmIdx.submit();">All</a>&nbsp;&nbsp;
                                    <a href="javascript:document.frmIdx.level.value='1'; document.frmIdx.submit();">L1</a>&nbsp;&nbsp;
                                    <a href="javascript:document.frmIdx.level.value='2'; document.frmIdx.submit();">L2</a>&nbsp;&nbsp;
                                    <a href="javascript:document.frmIdx.level.value='3'; document.frmIdx.submit();">L3</a>&nbsp;&nbsp;
                                    <a href="javascript:document.frmIdx.level.value='4'; document.frmIdx.submit();">L4</a>&nbsp;&nbsp;
                                    <a href="javascript:document.frmIdx.level.value='5'; document.frmIdx.submit();">L5</a>&nbsp;&nbsp;
                                    <a href="javascript:document.frmIdx.level.value='6'; document.frmIdx.submit();">L6</a>&nbsp;&nbsp;
                                    <a href="javascript:document.frmIdx.level.value='7'; document.frmIdx.submit();">L7</a>&nbsp;
                                </td>
                                <td width="77" class="headtext" align="right">&nbsp;<a href="javascript:logOut();">Log out</a>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="961" border="0" cellpadding="0" cellspacing="0">
                            <tr height="8"><td colspan="17"></td></tr>
                            <tr>
                                <td width="15" style="background: #CFECEC"></td>
                                <td width="15" style="background: #AFC7C7"></td>
                                <td class="textformsmall" width="48">&nbsp;Active</td>
                                <td width="15" style="background: #B5EAAA"></td>
                                <td class="textformsmall" width="163">&nbsp;Active - Permanent Resident</td>
                                <td width="15" style="background: #F9966B"></td>
                                <td class="textformsmall" width="127">&nbsp;Inactive - Transfer In</td>
                                <td width="15" style="background: #FAAFBE"></td>
                                <td class="textformsmall" width="107">&nbsp;Inactive - Abroad</td>
                                <td width="15" style="background: #FFE87C"></td>
                                <td class="textformsmall" width="203">&nbsp;Inactive - Pending Change of Status</td>
                                <td width="15" style=""></td>
                                <td class="textformsmall" width="48"></td>
                                <td width="15" style=""></td>
                                <td class="textformsmall" width="50"></td>
                                <td width="15" style=""></td>
                                <td class="textformsmall" width="80"></td>
                            </tr>
                            <tr height="8"><td colspan="17"></td></tr>
                            <tr>
                                <td width="15" style="background: #F75D59"></td>
                                <td colspan="2" class="textformsmall" width="48">&nbsp;Urgent</td>
                                <td width="15" style="background: #9999FF"></td>
                                <td class="textformsmall" width="163">&nbsp;Vacation</td>
                                <td width="15" style="background: #FFCC99"></td>
                                <td class="textformsmall" width="127">&nbsp;Transfer Out</td>
                                <td width="15" style="background: #CCCCCC"></td>
                                <td class="textformsmall" width="107">&nbsp;Deleted</td>
                                <td width="15" style="background: #34B91A"></td>
                                <td class="textformsmall" width="203">&nbsp;Active - Part-Time</td>
                                <td width="15" style=""></td>
                                <td class="textformsmall" width="48"></td>
                                <td width="15" style=""></td>
                                <td class="textformsmall" width="50"></td>
                                <td width="15" style=""></td>
                                <td class="textformsmall" width="95"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr height="8"><td></td></tr>
                <tr>
                    <td>
                        <table width="977" border="0" cellpadding="0" cellspacing="0">
                            <tr align="center" style="background-color: #999999">
                                <td width="29" height="22" class="headtext">No.</td>
                                <td width="1" height="22"><img src="/images/blank.gif" width="1" height="22" style="background-color: white"></td>
                                <td width="145" height="22" class="headtext">Last Name</td>
                                <td width="1" height="22"><img src="/images/blank.gif" width="1" height="22" style="background-color: white"></td>
                                <td width="145" height="22" class="headtext">First Name</td>
                                <td width="1" height="22"><img src="/images/blank.gif" width="1" height="22" style="background-color: white"></td>
                                <td width="22" height="22" class="headtext"><img src="/images/smiley-big.gif" style="height: 22px; width: 22px;" border="0"></td>
                                <td width="1" height="22"><img src="/images/blank.gif" width="1" height="22" style="background-color: white"></td>
                                <td width="78" height="22" class="headtext">Nickname</td>
                                <td width="1" height="22"><img src="/images/blank.gif" width="1" height="22" style="background-color: white"></td>
                                <td width="120" height="22" class="headtext">Current Level</td>
                                <td width="1" height="22"><img src="/images/blank.gif" width="1" height="22" style="background-color: white"></td>
                                <td width="250" height="22" class="headtext"><a href="javascript:document.frmIdx.orderby.value='Email'; document.frmIdx.submit();">Email</a></td>
                                <td width="1" height="22"><img src="/images/blank.gif" width="1" height="22" style="background-color: white"></td>            
                                <td width="90" height="22" class="headtext"><a href="javascript:document.frmIdx.orderby.value='ProgramEndDate'; document.frmIdx.submit();">End Date</a></td>     
                                <td width="1" height="22"><img src="/images/blank.gif" width="1" height="22" style="background-color: white"></td>            
                                <td width="90" height="22" class="headtext"><a href="javascript:document.frmIdx.orderby.value='TuitionPaymentDate'; document.frmIdx.submit();">Due Date</a></td>           
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="height: 597px; overflow: auto; width: 995px;">
                            <!-- dynamically generated table -->
                            <asp:Table id=TableToFill runat="server" GridLines="Both" width="977" border="0" cellpadding="0" cellspacing="0">         
                            </asp:Table>
                        </div>
                    </td>
                </tr>
                <tr><td height="5"></td></tr>
                <tr>
                    <td>            
                        <div style="float: left">   
                            <!-- buttons -->
                            <asp:Button ID="btnAdd"  runat="server" style="width: 120px" class="textform" Text="Add New..."></asp:Button>         
                            <asp:Button ID="btnViewDetial" runat="server" style="width: 120px" class="textform" Text="View Detail..."></asp:Button>
                            <asp:Button ID="btnEdit" runat="server" style="width: 120px" class="textform" Text="Edit..."></asp:Button>                  
                            <asp:Button ID="btnDelete" runat="server" style="width: 120px" class="textform" Text="Delete..."></asp:Button>         
                        </div>         
                    </td>
                </tr>
            </form>
        </table>
        <br>
    </body>
</html>
