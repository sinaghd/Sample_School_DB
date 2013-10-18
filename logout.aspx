<%@ Page Language="C#" %>
<%
	// Destroy session variables and redirect to default page
    Session.Abandon();
    Response.Redirect("default.aspx");
%>
