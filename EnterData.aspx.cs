using System;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnterDataPage
{
    public partial class EnterDataClass : Page
    {               
                 
        private OdbcConnection TempConn;
    
        private string dateFormat(string x)
        {
            // Change date format into YYYY-MM-DD
            short str1 = 0;
            short str2 = 0;
            short str3 = 0;
            // For MySQL
            if (x.Trim() != "")
            {
                str1 = (short) DateTime.Parse(x).Month;
                str2 = (short) DateTime.Parse(x).Day;
                str3 = (short) DateTime.Parse(x).Year;
                return str3 + "-" + str1 + "-" + str2;
            }
            return "0000-00-00";
        }


        private void ConnectToDB()
        {
            // Connect to Database
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



        private DropDownList DropDownListFilled(string ddl_sql, string ddl_id_key, string ddl_dsc_key)
        {
            // Fill a DropDownList object
            var ddl_temp = new DropDownList();
            DataSet TempRsDdl = null;
            TempRsDdl = TempRsFilled(ddl_sql);

            ddl_temp.DataTextField = ddl_id_key;
            ddl_temp.DataValueField = ddl_dsc_key;

            ddl_temp.DataSource = TempRsDdl;
            ddl_temp.DataBind();

            return ddl_temp;
        }



        private void TempDbExecute(string TempDbExecute_sql)
        {
            // Execute a SQL command
            OdbcCommand TempCommand_2 = null;
            TempCommand_2 = new OdbcCommand();
            TempCommand_2.CommandText = TempDbExecute_sql;
            TempCommand_2.Connection = TempConn;
            TempCommand_2.ExecuteNonQuery();
        }

        
        private void UploadBtn_Click(Object sender, EventArgs e)
        {
            // Call method to process posted data from server-side form
            ProcessPostBackData();
        }


        private void AddJS(string csname, string cscontent)
        {
            // Create and execute javascript block    
            Type cstype = GetType();
            ClientScriptManager cs = Page.ClientScript;
            if (!cs.IsClientScriptBlockRegistered(cstype, csname))
            {
                cs.RegisterStartupScript(cstype, csname, cscontent, true);
            }
        }


        private void closePopup()
        {
            // Create Javascript closePopup script from server
            var jstext = new StringBuilder();
            jstext.Append("alert('You have inserted data successfully.');");
            jstext.Append("window.parent.opener.location.reload('ViewData.aspx');");
            jstext.Append("window.parent.close();");

            AddJS("closePopupAlert", jstext.ToString());
        } 


        private void closeWindow()
        {
            // Create Javascript closeWindow script from server
            AddJS("closeWindowAlert", "alert('Please login again.'); window.parent.close();");
        } 


        private void DuplicateRecord()
        {
            // Create Javascript DuplicateRecord script from server
            AddJS("DuplicateRecordAlert", "alert('Duplicated record.'); window.parent.close();");
        }


        private void ProcessPostBackData()
        {
            // Process posted data from server-side form    
            string Address_str = String.Empty;
            string AdministrativeNotes_str = String.Empty;       
            string ClassHoursHistory_str = String.Empty;
            string Comments_str = String.Empty;
            string CountryOfBirth_str = String.Empty;
            short CurrentLevel_int;
            string Email_str = String.Empty;
            string EmergencyAddress_str = String.Empty;
            string EmergencyContact_str = String.Empty;
            string EmergencyNumber_str = String.Empty;
            string FileName_str = String.Empty;
            string FirstName_str = String.Empty;
            string LastName_str = String.Empty;
            string Nationality_str = String.Empty;
            string Nickname_str = String.Empty;
            string PhoneNumber_str = String.Empty;
            string Phone_str = String.Empty;
            string ProgramEndDate_str = String.Empty;
            string ProgramStartDate_str = String.Empty;
            string Status_str = String.Empty;
            string StudentID_str = String.Empty;
            string TestScoreHistory_str = String.Empty;
            string TuitionPaymentDate_str = String.Empty;
            string TuitionPaymentNotes_str = String.Empty;
            string UrgentNote_str = String.Empty;
            string VacationInfo_str = String.Empty;
            string WarningLetterInfo_str = String.Empty;
            string isUrgent_str = String.Empty;            
            string isClose = "No";
            string strSql = String.Empty;
            DataSet TempRs;

            if (Convert.ToString(LastName.Value) != "" && Convert.ToString(FirstName.Value) != "")
            {
                LastName_str = LastName.Value;
                FirstName_str = Convert.ToString(FirstName.Value);
                Nickname_str = Convert.ToString(Nickname.Value);
                Status_str = Convert.ToString(StatusDropDownList.SelectedValue);

                if (Convert.ToString(isUrgent.Value) == "on")
                {
                    isUrgent_str = "1";
                    UrgentNote_str = Convert.ToString(UrgentNote.Value);
                }
                else
                {
                    isUrgent_str = "0";
                    UrgentNote_str = "";
                }

                Address_str = Convert.ToString(Address.Value).Replace("'", "\\'");
                PhoneNumber_str = Convert.ToString(PhoneNumber.Value);
                Email_str = Convert.ToString(Email.Value);
                CountryOfBirth_str = Convert.ToString(CountryOfBirth.Value);
                Nationality_str = Convert.ToString(Nationality.Value);
                EmergencyContact_str = Convert.ToString(EmergencyContact.Value);
                EmergencyAddress_str = Convert.ToString(EmergencyAddress.Value).Replace("'", "\\'");
                EmergencyNumber_str = Convert.ToString(EmergencyNumber.Value).Replace("'", "\\'");
                if (!(String.IsNullOrEmpty(Convert.ToString(ProgramStartDate.Value))))
                {
                    ProgramStartDate_str = dateFormat(Convert.ToString(ProgramStartDate.Value));
                }
                if (!(String.IsNullOrEmpty(Convert.ToString(ProgramEndDate.Value))))
                {
                    ProgramEndDate_str = dateFormat(Convert.ToString(ProgramEndDate.Value));
                }
                TestScoreHistory_str = Convert.ToString(TestScoreHistory.Value);
                if (!(String.IsNullOrEmpty(Convert.ToString(CurrentLevelDropDownList.SelectedValue))))
                {
                    CurrentLevel_int = Convert.ToInt16(CurrentLevelDropDownList.SelectedValue);
                }
                if (!(String.IsNullOrEmpty(Convert.ToString(TuitionPaymentDate.Value))))
                {
                    TuitionPaymentDate_str = dateFormat(Convert.ToString(TuitionPaymentDate.Value));
                }
                TuitionPaymentNotes_str = Convert.ToString(TuitionPaymentNotes.Value).Replace("'", "\\'");
                ClassHoursHistory_str = Convert.ToString(ClassHoursHistory.Value).Replace("'", "\\'");
                VacationInfo_str = (Convert.ToString(VacationInfo.Value)).Replace("'", "\\'");
                WarningLetterInfo_str = Convert.ToString(WarningLetterInfo.Value).Replace("'", "\\'");
                Comments_str = Convert.ToString(Comments.Value).Replace("'", "\\'");
                AdministrativeNotes_str = Convert.ToString(AdministrativeNotes.Value).Replace("'", "\\'");

                strSql = "SELECT LastName, FirstName FROM iic_students_basic ";
                strSql = strSql + "WHERE LCase(Trim(LastName)) = '" + LastName_str.Trim().ToLower() + "' ";
                strSql = strSql + "AND LCase(Trim(FirstName)) = '" + FirstName_str.Trim().ToLower() + "' ";

                TempRs = TempRsFilled(strSql);

                if (TempRs.Tables[0].Rows.Count != 0)
                {
                    //Data already exista -- avoid duplicated data			

                    DuplicateRecord();

                    closeWindow();
                }
                else
                {
                    strSql =
                        "INSERT INTO iic_students_basic (LastName, FirstName, Nickname, Status, isUrgent, UrgentNote, Address, PhoneNumber, Email, CountryOfBirth, Nationality, EmergencyContact , EmergencyAddress, EmergencyNumber, EmergencyEmail, ";

                    if (ProgramStartDate_str != "")
                    {
                        strSql = strSql + "ProgramStartDate, ";
                    }
                    if (ProgramEndDate_str != "")
                    {
                        strSql = strSql + "ProgramEndDate, ";
                    }
                    strSql = strSql + "TestScoreHistory, CurrentLevel, ";
                    if (TuitionPaymentDate_str != "")
                    {
                        strSql = strSql + "TuitionPaymentDate, ";
                    }
                    strSql = strSql +
                             "TuitionPaymentNotes, ClassHoursHistory, VacationInfo, WarningLetterInfo, Comments, AdministrativeNotes, StudentImage";
                    strSql = strSql + ") VALUES (";
                    strSql = strSql + "'" + LastName_str + "', ";
                    strSql = strSql + "'" + FirstName_str + "', ";
                    strSql = strSql + "'" + Nickname_str + "', ";
                    strSql = strSql + Status_str + ", ";
                    strSql = strSql + isUrgent_str + ", ";
                    strSql = strSql + "'" + UrgentNote_str + "', ";
                    strSql = strSql + "'" + Address_str + "', ";
                    strSql = strSql + "'" + PhoneNumber_str + "', ";
                    strSql = strSql + "'" + Email_str + "', ";
                    strSql = strSql + "'" + CountryOfBirth_str + "', ";
                    strSql = strSql + "'" + Nationality_str + "', ";
                    strSql = strSql + "'" + EmergencyContact_str + "', ";
                    strSql = strSql + "'" + EmergencyAddress_str + "', ";
                    strSql = strSql + "'" + EmergencyNumber_str + "', ";
                    
                    if (ProgramStartDate_str != "")
                    {
                        strSql = strSql + "'" + ProgramStartDate_str + "', ";
                    }
                    if (ProgramEndDate_str != "")
                    {
                        strSql = strSql + "'" + ProgramEndDate_str + "', ";
                    }
                    strSql = strSql + "'" + TestScoreHistory_str + "', ";
                    strSql = strSql + "" + CurrentLevel_int.ToString() + ", ";

                    if (TuitionPaymentDate_str != "")
                    {
                        strSql = strSql + "'" + TuitionPaymentDate_str + "', ";
                    }
                    
                    strSql = strSql + "'" + ClassHoursHistory_str + "', ";
                    strSql = strSql + "'" + VacationInfo_str + "', ";
                    strSql = strSql + "'" + WarningLetterInfo_str + "', ";
                    strSql = strSql + "'" + Comments_str + "', ";
                    strSql = strSql + "'" + AdministrativeNotes_str + "', ";


                    FileName_str = "";

                    if (StudentPic.HasFile)
                    {
                        if (StudentPic.FileName != "")
                        {
                            StudentPic.SaveAs(Server.MapPath("\\images\\students") + "\\" + StudentPic.FileName);
                            FileName_str = StudentPic.FileName;
                        }
                    }

                    strSql = strSql + "'" + FileName_str + "')";
                    TempDbExecute(strSql);


                    isClose = "Yes";
                }
            }

            //Close Child Window
            if (isClose == "Yes")
            {
                closePopup();
            }
        }


        private void Page_Load(object sender, EventArgs e)
        {
            // On page load, do the following...
            string Auth_Id = String.Empty; 

            Auth_Id = String.Format("{0}", Session["Auth_Id"]);

            if (Auth_Id == "" || Auth_Id == DBNull.Value.ToString())
            {
                closeWindow();
            }
                        
            ConnectToDB();

            // Populate DropDownList objects on page
            StatusDropDownList = DropDownListFilled("SELECT * FROM iic_students_status", "status_id",
                "status_description");
            CurrentLevelDropDownList = DropDownListFilled("SELECT * FROM iic_students_level", "level_id",
                "level_description");
            
        }
    }
}
