using System;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Web.UI;

namespace DefaultPage
{
    public class DefaultClass : Page

    {
        private OdbcConnection TempConn;           
        
        private void errMsg()
        {
            // Error message for user who fails credentials check
            AddJS("ErrMsgAlert", "alert('Please check your username or password.';");
        }


        private void AddJS(string csname, string cscontent)
        {
            // Create amd execute Javascript block
            Type cstype = GetType();
            ClientScriptManager cs = Page.ClientScript;
            if (!cs.IsClientScriptBlockRegistered(cstype, csname))
            {
                cs.RegisterStartupScript(cstype, csname, cscontent, true);
            }
        }


        private void ConnectToDB()
        {
            // Connect to database
            string sConnection = String.Empty;
            sConnection = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            TempConn = new OdbcConnection();
            TempConn.ConnectionString = sConnection;
            TempConn.Open();
        }


        private DataSet TempRsFilled(string TempRsFilled_sql)
        {
            // Fill a dataset
            OdbcCommand TempRsFilled_Command = null;
            TempRsFilled_Command = new OdbcCommand();
            TempRsFilled_Command.CommandText = TempRsFilled_sql;
            OdbcDataAdapter TempRsFilled_DataAdapater = null;
            TempRsFilled_DataAdapater = new OdbcDataAdapter();
            TempRsFilled_DataAdapater.SelectCommand = TempRsFilled_Command;
            TempRsFilled_DataAdapater.SelectCommand.Connection = TempConn;
            DataSet TempRsFilled_Dataset = null;
            TempRsFilled_Dataset = new DataSet();
            TempRsFilled_DataAdapater.Fill(TempRsFilled_Dataset);
            return TempRsFilled_Dataset;
        }


        private void Page_Load(object sender, EventArgs e)
        {
            // On page load, do the folllowing...
            string username = String.Empty;            
            string password = String.Empty;         
            string passcode = "key:sample_key";
            string strSql = String.Empty;                    

            ConnectToDB();

            if (String.Format("{0}", Request.ServerVariables["REQUEST_METHOD"]) == "POST")
            {
                username = String.Format("{0}", Request.Form["username"]);
                password = String.Format("{0}", Request.Form["password"]);

                if (username != "" && password != "")
                {
                    // Check user's credentials

                    strSql = "SELECT username, authorize_id ";
                    strSql = strSql + "FROM iic_members WHERE username='" + username + "' ";
                    strSql = strSql + "AND AES_DECRYPT(password, '" + passcode + "') = '" + password + "' ";
                    strSql = strSql + "AND LCase(status)='active' ";

                    DataSet TempRs = null;
                    TempRs = TempRsFilled(strSql);

                    if (!(TempRs.Tables[0].Rows.Count == 0))
                    {
                        // If user's info is valid, set session variables

                        Session["username"] = username;
                        Session["Auth_Id"] = TempRs.Tables[0].Rows[0]["authorize_id"];
                        Session["TimeOut"] = 30;                        

                        Response.Redirect("ViewData.aspx");
                    }
                    else
                    {
                        errMsg();
                    }
                }
                else
                {
                    errMsg();
                }                
            }
        }
    }
}