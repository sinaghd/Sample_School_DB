<%@ Language="C#" Inherits="DefaultPage.DefaultClass" src="default.aspx.cs" %>

<html>
    <head>
        <title>:: Login ::</title>
        <link href="style/style.css" rel="stylesheet" type="text/css">
    </head>
    <body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
        <table width="100%" height="100%" align="center" valign="middle" onload=>
            <tr align="center">
                <td>
                    <fieldset class="textform" style="width: 260px">
                        <legend class="headtext" style="color: blue">ADMINISTRATORS LOG IN&nbsp;</legend> 
                        <table width="235" cellpadding="0" cellspacing="0" border="0">
                            <!-- form -->
                            <form name="frmIdx" method="post" action="default.aspx">
                                <tr height="8"><td colspan="3"></td></tr>
                                <tr><td width="75" class="headtext" align="right">Username:</td><td width="10">&nbsp;</td><td width="150"><input type="text" name="username" maxlength="30" class="textform"></td></tr>
                                <tr><td width="75" class="headtext" align="right">Password:</td><td width="10">&nbsp;</td><td width="150"><input type="password" name="password" maxlength="30" class="textform"></td></tr>
                                <tr height="8"><td colspan="3"></td></tr>
                                <tr><td width="75" class="textform">&nbsp;</td><td width="10">&nbsp;</td><td width="150"><input type="submit" name="submit" value="Submit" class="textform" style="width: 65px">&nbsp;<input type="reset" name="Reset" value="Reset" class="textform" style="width: 65px"></td></tr>
                                <tr height="8"><td colspan="3"></td></tr>               
                            </form>
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
    </body>
</html>