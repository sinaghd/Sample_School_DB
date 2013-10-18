using System;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EditDataPage
{
    public partial class EditDataClass : Page
    {      
        private string Address = String.Empty;
        private string AdministrativeNotes = String.Empty;        
        private string ClassHoursHistory = String.Empty;
        private string Comments = String.Empty;
        private string CountryOfBirth = String.Empty;
        private short CurrentLevel;
        private string Email = String.Empty;
        private string EmergencyAddress = String.Empty;
        private string EmergencyContact = String.Empty;
        private string EmergencyEmail = String.Empty;
        private string EmergencyNumber = String.Empty;
        private string ExitScoreHistory = String.Empty;
        private string FirstName = String.Empty;
        private string LastName = String.Empty;
        private string MedLeaveEndDate = String.Empty;
        private string MedLeaveStartDate = String.Empty;
        private short MedLeaveWeeks;
        private string Nationality = String.Empty;
        private string Nickname = String.Empty;
        private string NotifyPayment = String.Empty;
        private string PhoneNumber = String.Empty;
        private string ProgramEndDate = String.Empty;
        private string ProgramStartDate = String.Empty;
        private string ProgressDate = String.Empty;
        private short ProgressLevel;
        private string Status = String.Empty;
        private string StudentImageFilename = String.Empty;    
        private string TestScoreHistory = String.Empty;
        private string TuitionPaymentDate = String.Empty;
        private string TuitionPaymentNotes = String.Empty;
        private string UrgentNote = String.Empty;
        private string VacationEndDate = String.Empty;
        private string VacationInfo = String.Empty;
        private string VacationStartDate = String.Empty;
        private short VacationWeeks;
        private string WarningLetterInfo = String.Empty;
        private OdbcConnection TempConn;        
        private double earnedvac;
        private string remainvac = String.Empty;
        private string isDisabled = String.Empty;
        private string isTransferout = String.Empty;
        private string isUrgent = String.Empty;
        private string refPopPage = String.Empty;
        private string stdid = String.Empty;
        private string stdweek = String.Empty;
        

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


        private void TempDbExecute(string TempDbExecute_sql)
        {
            // Execute a SQL command
            OdbcCommand TempCommand_2 = null;
            TempCommand_2 = new OdbcCommand();
            TempCommand_2.CommandText = TempDbExecute_sql;
            TempCommand_2.Connection = TempConn;
            TempCommand_2.ExecuteNonQuery();
        }


        private void queryRecord()
        {
            // Retrieve student data from database record
            string strSql = String.Empty;
            DataSet TempRs;
            strSql = "SELECT * FROM iic_students_basic WHERE StudentID=" + stdid;
            TempRs = TempRsFilled(strSql);

            foreach (DataRow iteration_row in TempRs.Tables[0].Rows)
            {
                LastName = Convert.ToString(iteration_row["LastName"]);
                FirstName = Convert.ToString(iteration_row["FirstName"]);
                Nickname = Convert.ToString(iteration_row["Nickname"]);
                StudentImageFilename = Convert.ToString(iteration_row["StudentImage"]);
                Status = Convert.ToString(iteration_row["Status"]);
                isUrgent = Convert.ToInt16(iteration_row["isUrgent"]).ToString();
                isTransferout = Convert.ToInt16(iteration_row["isTransferout"]).ToString();
                UrgentNote = Convert.ToString(iteration_row["UrgentNote"]);
                Address = Convert.ToString(iteration_row["Address"]);
                PhoneNumber = Convert.ToString(iteration_row["PhoneNumber"]);
                Email = Convert.ToString(iteration_row["Email"]);
                CountryOfBirth = Convert.ToString(iteration_row["CountryOfBirth"]);
                Nationality = Convert.ToString(iteration_row["Nationality"]);
                EmergencyContact = Convert.ToString(iteration_row["EmergencyContact"]);
                EmergencyAddress = Convert.ToString(iteration_row["EmergencyAddress"]);
                EmergencyNumber = Convert.ToString(iteration_row["EmergencyNumber"]);
                EmergencyEmail = Convert.ToString(iteration_row["EmergencyEmail"]);


                ProgramStartDate = "";
                if (DBNull.Value.Equals(iteration_row["ProgramStartDate"]) ||
                    Convert.ToString(iteration_row["ProgramStartDate"]) != "")
                {
                    ProgramStartDate = Convert.ToString(iteration_row["ProgramStartDate"]);
                }

                ProgramEndDate = "";
                if (DBNull.Value.Equals(iteration_row["ProgramEndDate"]) ||
                    Convert.ToString(iteration_row["ProgramEndDate"]) != "")
                {
                    ProgramEndDate = Convert.ToString(iteration_row["ProgramEndDate"]);
                }

                TestScoreHistory = Convert.ToString(iteration_row["TestScoreHistory"]);
                ExitScoreHistory = Convert.ToString(iteration_row["ExitScoreHistory"]);
                CurrentLevel = Convert.ToInt16(iteration_row["CurrentLevel"]);

                TuitionPaymentDate = "";
                if (DBNull.Value.Equals(iteration_row["TuitionPaymentDate"]) ||
                    Convert.ToString(iteration_row["TuitionPaymentDate"]) != "")
                {
                    TuitionPaymentDate = Convert.ToString(iteration_row["TuitionPaymentDate"]);
                }

                TuitionPaymentNotes = Convert.ToString(iteration_row["TuitionPaymentNotes"]).Trim();
                ClassHoursHistory = Convert.ToString(iteration_row["ClassHoursHistory"]).Trim();
                VacationInfo = Convert.ToString(iteration_row["VacationInfo"]).Trim();
                WarningLetterInfo = Convert.ToString(iteration_row["WarningLetterInfo"]).Trim();
                Comments = Convert.ToString(iteration_row["Comments"]).Trim();
                AdministrativeNotes = Convert.ToString(iteration_row["AdministrativeNotes"]).Trim();
                StudentImageFilename = Convert.ToString(iteration_row["StudentImage"]).Trim();
                NotifyPayment = Convert.ToString(iteration_row["Notify_Payment"]).Trim();
            }
        }


        private string dateFormat(string x)
        {
            // Convert date format to YYYY-MM-DD
            short str1 = 0;
            short str2 = 0;
            short str3 = 0;
            if (x.Trim() != "")
            {
                str1 = (short) DateTime.Parse(x).Month;
                str2 = (short) DateTime.Parse(x).Day;
                str3 = (short) DateTime.Parse(x).Year;
                return str3 + "-" + str1 + "-" + str2;
            }
            return "0000-00-00";
        }


        private string dateSlashFormat(string x)
        {
            // Convert date format to MM/DD/YYYY
            short str1 = 0;
            short str2 = 0;
            short str3 = 0;
            if (x.Trim() != "")
            {
                str1 = (short) DateTime.Parse(x).Month;
                str2 = (short) DateTime.Parse(x).Day;
                str3 = (short) DateTime.Parse(x).Year;
                return str1 + "/" + str2 + "/" + str3;
            }
            return "";
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


        private void UploadBtn_Click(Object sender, EventArgs e)
        {
            // Call method to process posted data from server-side form
            ProcessPostBackData();
        }


        private void ProcessPostBackData()
        {
            // Process posted data from server-side form
            string isClose = = "No";
            string iRecord = String.Empty;
            string isDelete = String.Empty;
            string isDeleteImage = String.Empty;
            string isEdit = String.Empty;
            string strSql = String.Empty;
            string uploadsDirVar = "\\images\\students";

            if (String.Format("{0}", Request.ServerVariables["REQUEST_METHOD"]) != "POST")
            {
                stdid = String.Format("{0}", Request.QueryString["stdid"]).Trim();
                queryRecord();
            }
            else
            {
                stdid = Convert.ToString(Request.Form["stdid"]);
                isDelete = Convert.ToString(Request.Form["isDelete"]);
                isEdit = Convert.ToString(Request.Form["isEdit"]);
                iRecord = Convert.ToString(Request.Form["iRecord"]);

                if (isDelete != "")
                {
                    // Delete Vacation
                    strSql = "DELETE FROM iic_vacation WHERE id='" + iRecord + "' AND StudentID='" + stdid + "'";
                    TempDbExecute(strSql);

                    AddJS("VacationDeletedPopupAlert", "alert('The vacation record has been deleted.');");

                    refPopPage = "EditData.aspx?stdid=" + stdid;
                    isClose = "No";
                    queryRecord();
                }
                else if (isEdit != "")
                {
                    // Edit Vacation

                    AddJS("VacationUpdatedPopupAlert", "The vacation record has been updated.');");

                    refPopPage = "EditData.aspx?stdid=" + stdid;
                    isClose = "No";
                    queryRecord();
                }
                else
                {
                    if (Convert.ToString(Request.Form["LastName"]) != "" &&
                        Convert.ToString(Request.Form["FirstName"]) != "")
                    {
                        isDisabled = Convert.ToString(Request.Form["isDisabled"]);
                        LastName = Convert.ToString(Request.Form["LastName"]);
                        FirstName = Convert.ToString(Request.Form["FirstName"]);
                        Nickname = Convert.ToString(Request.Form["Nickname"]);
                        Status = Convert.ToString(Request.Form["Status"]);

                        isUrgent = "0";
                        UrgentNote = "";
                        if (Convert.ToString(Request.Form["isUrgent"]) == "on")
                        {
                            isUrgent = "1";
                            UrgentNote = Convert.ToString(Request.Form["UrgentNote"]);
                        }

                        isTransferout = "0";
                        if (Convert.ToString(Request.Form["isTransferout"]) == "on")
                        {
                            isTransferout = "1";
                        }

                        Address = Convert.ToString(Request.Form["Address"]).Replace("'", "\\'");
                        PhoneNumber = Convert.ToString(Request.Form["PhoneNumber"]);
                        Email = Convert.ToString(Request.Form["Email"]);
                        CountryOfBirth = Convert.ToString(Request.Form["CountryOfBirth"]);
                        Nationality = Convert.ToString(Request.Form["Nationality"]);
                        EmergencyContact = Convert.ToString(Request.Form["EmergencyContact"]);
                        EmergencyAddress = Convert.ToString(Request.Form["EmergencyAddress"]).Replace("'", "\\'");
                        EmergencyNumber = Convert.ToString(Request.Form["EmergencyNumber"]).Replace("'", "\\'");
                        EmergencyEmail = Convert.ToString(Request.Form["EmergencyEmail"]);
                        ProgramStartDate = dateFormat(Convert.ToString(Request.Form["ProgramStartDate"]));
                        ProgramEndDate = dateFormat(Convert.ToString(Request.Form["ProgramEndDate"]));
                        TestScoreHistory = Convert.ToString(Request.Form["TestScoreHistory"]);
                        ExitScoreHistory = Convert.ToString(Request.Form["ExitScoreHistory"]);
                        if (Convert.ToString(Request.Form["CurrentLevel"]) != "")
                        {
                            CurrentLevel = Convert.ToInt16(Request.Form["CurrentLevel"]);
                        }
                        TuitionPaymentDate = dateFormat(Convert.ToString(Request.Form["TuitionPaymentDate"]));
                        TuitionPaymentNotes = Convert.ToString(Request.Form["TuitionPaymentNotes"]).Replace("'", "\\'");
                        ClassHoursHistory = Convert.ToString(Request.Form["ClassHoursHistory"]).Replace("'", "\\'");
                        VacationStartDate = dateFormat(Convert.ToString(Request.Form["VacationStartDate"]));
                        VacationEndDate = dateFormat(Convert.ToString(Request.Form["VacationEndDate"]));
                        if (Convert.ToString(Request.Form["VacationWeeks"]) != "")
                        {
                            VacationWeeks = Convert.ToInt16(Request.Form["VacationWeeks"]);
                        }
                        VacationInfo = Convert.ToString(Request.Form["VacationInfo"]).Replace("'", "\\'");
                        MedLeaveStartDate = dateFormat(Convert.ToString(Request.Form["MedLeaveStartDate"]));
                        MedLeaveEndDate = dateFormat(Convert.ToString(Request.Form["MedLeaveEndDate"]));
                        if (Convert.ToString(Request.Form["MedLeaveWeeks"]) != "")
                        {
                            MedLeaveWeeks = Convert.ToInt16(Request.Form["MedLeaveWeeks"]);
                        }
                        ProgressDate = dateFormat(Convert.ToString(Request.Form["ProgressDate"]));
                        if (Convert.ToString(Request.Form["ProgressLevel"]) != "")
                        {
                            ProgressLevel = Convert.ToInt16(Request.Form["ProgressLevel"]);
                        }
                        WarningLetterInfo = Convert.ToString(Request.Form["WarningLetterInfo"]).Replace("'", "\\'");
                        Comments = Convert.ToString(Request.Form["Comments"]).Replace("'", "\\'");
                        AdministrativeNotes = Convert.ToString(Request.Form["AdministrativeNotes"]).Replace("'", "\\'");
                        StudentImageFilename = Convert.ToString(Request.Form["StudentImage"]);

                        strSql = "UPDATE iic_students_basic SET ";
                        strSql = strSql + "LastName='" + LastName + "', ";
                        strSql = strSql + "FirstName='" + FirstName + "', ";
                        strSql = strSql + "Nickname='" + Nickname + "', ";
                        strSql = strSql + "Status='" + Status + "', ";
                        strSql = strSql + "isUrgent='" + isUrgent + "', ";
                        strSql = strSql + "isTransferout='" + isTransferout + "', ";
                        strSql = strSql + "UrgentNote='" + UrgentNote + "', ";
                        strSql = strSql + "Address='" + Address + "', ";
                        strSql = strSql + "PhoneNumber='" + PhoneNumber + "', ";
                        strSql = strSql + "Email='" + Email + "', ";
                        strSql = strSql + "CountryOfBirth='" + CountryOfBirth + "', ";
                        strSql = strSql + "Nationality='" + Nationality + "', ";
                        strSql = strSql + "EmergencyContact='" + EmergencyContact + "', ";
                        strSql = strSql + "EmergencyAddress='" + EmergencyAddress + "', ";
                        strSql = strSql + "EmergencyNumber='" + EmergencyNumber + "', ";
                        strSql = strSql + "EmergencyEmail='" + EmergencyEmail + "', ";
                        if (ProgramStartDate != "")
                        {
                            strSql = strSql + "ProgramStartDate='" + ProgramStartDate + "', ";
                        }
                        if (ProgramEndDate != "")
                        {
                            strSql = strSql + "ProgramEndDate='" + ProgramEndDate + "', ";
                        }

                        strSql = strSql + "TestScoreHistory='" + TestScoreHistory + "', ";
                        strSql = strSql + "ExitScoreHistory='" + ExitScoreHistory + "', ";
                        strSql = strSql + "CurrentLevel=" + CurrentLevel + ", ";

                        if (isDisabled == "")
                        {
                            strSql = strSql + "TuitionPaymentDate='" + TuitionPaymentDate + "', ";
                            strSql = strSql + "TuitionPaymentNotes='" + TuitionPaymentNotes + "', ";
                            strSql = strSql + "ClassHoursHistory='" + ClassHoursHistory + "', ";
                            strSql = strSql + "VacationInfo='" + VacationInfo + "', ";
                            strSql = strSql + "WarningLetterInfo='" + WarningLetterInfo + "', ";
                            strSql = strSql + "Comments='" + Comments + "', ";
                        }
                        
                        if (Convert.ToString(Request.Form["isDeleteImage"]) == "on")
                        {
                            strSql = strSql + "StudentImage='', ";
                            isDeleteImage = "1";
                        }
                        else
                        {
                            if (StudentPic.HasFile)
                            {
                                if (StudentPic.FileName != "")
                                {
                                    StudentImageFilename = StudentPic.FileName;
                                    strSql = strSql + "StudentImage='" + StudentImageFilename + "', ";
                                    // Save uploaded file to server
                                    StudentPic.SaveAs(Server.MapPath("\\images\\students") + "\\" + StudentImageFilename);
                                }
                            }
                        }

                        strSql = strSql + "AdministrativeNotes='" + AdministrativeNotes + "'";
                        strSql = strSql + " WHERE StudentID=" + stdid + "";

                        TempDbExecute(strSql);

                        // Insert Into Vacation Table
                        if (VacationStartDate != "")
                        {
                            strSql = "INSERT INTO iic_vacation (StudentID, ";
                            if (VacationStartDate != "")
                            {
                                strSql = strSql + "start_date, ";
                            }
                            if (VacationEndDate != "")
                            {
                                strSql = strSql + "end_date, ";
                            }
                            strSql = strSql + "weeks";
                            strSql = strSql + ") VALUES (";
                            strSql = strSql + "'" + stdid + "', ";
                            if (VacationStartDate != "")
                            {
                                strSql = strSql + "'" + VacationStartDate + "', ";
                            }
                            if (VacationEndDate != "")
                            {
                                strSql = strSql + "'" + VacationEndDate + "', ";
                            }
                            strSql = strSql + "" + VacationWeeks + ")";

                            TempDbExecute(strSql);
                        }

                        // Insert Into Medical Leave Table
                        if (MedLeaveStartDate != "")
                        {
                            strSql = "INSERT INTO iic_medical_leave (StudentID, ";
                            if (MedLeaveStartDate != "")
                            {
                                strSql = strSql + "start_date, ";
                            }
                            if (MedLeaveEndDate != "")
                            {
                                strSql = strSql + "end_date, ";
                            }
                            strSql = strSql + "weeks";
                            strSql = strSql + ") VALUES (";
                            strSql = strSql + "'" + stdid + "', ";
                            if (MedLeaveStartDate != "")
                            {
                                strSql = strSql + "'" + MedLeaveStartDate + "', ";
                            }
                            if (MedLeaveEndDate != "")
                            {
                                strSql = strSql + "'" + MedLeaveEndDate + "', ";
                            }
                            strSql = strSql + "" + MedLeaveWeeks + ")";

                            TempDbExecute(strSql);
                        }

                        // Insert Into Progress Table
                        if (ProgressDate != "")
                        {
                            strSql = "INSERT INTO iic_progress_table (StudentID, ";
                            if (ProgressDate != "")
                            {
                                strSql = strSql + "ProgressDate, ";
                            }
                            strSql = strSql + "ProgressLevel";
                            strSql = strSql + ") VALUES (";
                            strSql = strSql + "'" + stdid + "', ";
                            if (ProgressDate != "")
                            {
                                strSql = strSql + "'" + ProgressDate + "', ";
                            }
                            strSql = strSql + "" + ProgressLevel + ")";

                            TempDbExecute(strSql);
                        }

                        // Delete student's image from server
                        if (isDeleteImage == "1")
                        {
                            if (StudentImageFilename != "")
                            {
                                try
                                {
                                    var TheFile = new FileInfo(MapPath(uploadsDirVar) + "\\" + StudentImageFilename);
                                    if (TheFile.Exists)
                                    {
                                        File.Delete(MapPath(uploadsDirVar) + "\\" + StudentImageFilename);
                                    }
                                }

                                catch (Exception ex)
                                {
                                    Response.Write(ex.Message);
                                }
                            }
                        }

                        isClose = "Yes";
                    }
                    closeWindow();
                }

                //- - Close Child Window
                if (isClose == "Yes")
                {
                    closePopup();
                }
                else
                {
                    reloadPopup();
                }
            }
        }


        private void reloadPopup()
        {
            // Create Javascript reloadPopup script from server
            AddJS("ReloadPopupWindow", "window.parent.location.reload('" + refPopPage + "');");
        } 


        private void closePopup()
        {
            // Create Javascript closePopup script from server
            var jstext = new StringBuilder();
            jstext.Append("alert(\"You have updated data successfully.');");
            jstext.Append("window.parent.opener.location.reload('ViewData.aspx');");
            jstext.Append("window.parent.close();");

            AddJS("ClosePopupWindow", jstext.ToString());
        } //closePopup


        private void closeWindow()
        {
            // Create Javascript closeWindow script from server
            AddJS("ReloadPopupWindow", "alert('Please login again.'); window.parent.close();");
        } //closeWindow


        private void CalculateVacation()
        {
        // Calculate total number of vacation weeks, number of weeks earned, and number of weeks remaining

        // Determine study period
            int weekleft = 0;            
            DataSet TempRsStd = null;
            stdweek = "";

            string stdSql =
                "SELECT lastname, firstname, FLOOR( DATEDIFF( CURDATE( ) , PROGRAMSTARTDATE ) /7 ) AS weeks ";
            stdSql = stdSql + "FROM iic_students_basic ";
            stdSql = stdSql + "WHERE STATUS IN (1) ";
            stdSql = stdSql + "AND StudentID=" + stdid;

            TempRsStd = TempRsFilled(stdSql);

            foreach (DataRow iteration_row_3 in TempRsStd.Tables[0].Rows)
            {
                stdweek = Convert.ToString(iteration_row_3["weeks"]);
            }


            if (stdweek == "" || Convert.IsDBNull(stdweek))
            {
                stdweek = "0";
            }

            // Determine total weeks of vacation
            string vacweek = String.Empty;
            string vacSql = "SELECT SUM(weeks) as weeks FROM iic_vacation WHERE StudentID = " + stdid;
            DataSet TempRsVac = null;

            TempRsVac = TempRsFilled(vacSql);

            foreach (DataRow iteration_row_4 in TempRsVac.Tables[0].Rows)
            {
                vacweek = Convert.ToString(iteration_row_4["weeks"]);
            }


            if (vacweek == "" || Convert.IsDBNull(vacweek))
            {
                vacweek = "0";
            }

            // Calculate Earned Vacation
            earnedvac = 0;
            if (Convert.ToInt16(Double.Parse(stdweek)) >= 36)
            {
                for (int iCount = 1; iCount <= Convert.ToInt16(Double.Parse(stdweek)); iCount++)
                {
                    if (((short) iCount)%36 == 0)
                    {
                        earnedvac++;
                    }
                }

                earnedvac *= 5;
                weekleft = Convert.ToInt16(Double.Parse(stdweek))%36;
            }
            else if (Convert.ToInt16(Double.Parse(stdweek)) > 31)
            {
                for (int iCount = 1; iCount <= Convert.ToInt16(Double.Parse(stdweek)); iCount++)
                {
                    if (((short) iCount)%32 == 0)
                    {
                        earnedvac++;
                    }
                }

                earnedvac *= 4;
                weekleft = Convert.ToInt16(Double.Parse(stdweek))%32;
            }
            else if (Convert.ToInt16(Double.Parse(stdweek)) > 27)
            {
                for (int iCount = 1; iCount <= Convert.ToInt16(Double.Parse(stdweek)); iCount++)
                {
                    if (((short) iCount)%28 == 0)
                    {
                        earnedvac++;
                    }
                }

                earnedvac *= 3;
                weekleft = Convert.ToInt16(Double.Parse(stdweek))%28;
            }
            else if (Convert.ToInt16(Double.Parse(stdweek)) >= 20)
            {
                for (int iCount = 1; iCount <= Convert.ToInt16(Double.Parse(stdweek)); iCount++)
                {
                    if (((short) iCount)%20 == 0)
                    {
                        earnedvac++;
                    }
                }

                earnedvac *= 2;
                weekleft = Convert.ToInt16(Double.Parse(stdweek))%20;
            }
            else
            {
                earnedvac = 0;
            }

            if (earnedvac > 0)
            {
                if (((short) weekleft) > 31)
                {
                    earnedvac += 4;
                }
                else if (((short) weekleft) > 27)
                {
                    earnedvac += 3;
                }
                else if (((short) weekleft) >= 20)
                {
                    earnedvac += 2;
                }
            }

            // Calcuate Remaining Vacation
            remainvac = Convert.ToInt16(earnedvac - Double.Parse(vacweek)).ToString();
            if (remainvac == "" || Convert.IsDBNull(remainvac))
            {
                remainvac = "0";
            }
        }


        private DropDownList DropDownListFilled(string ddl_sql, string ddl_id_key, string ddl_dsc_key)
        {
            // Fill a DropDownList object with data
            var ddl_temp = new DropDownList();
            DataSet TempRsDdl = null;
            TempRsDdl = TempRsFilled(ddl_sql);

            ddl_temp.DataTextField = ddl_id_key;
            ddl_temp.DataValueField = ddl_dsc_key;

            ddl_temp.DataSource = TempRsDdl;
            ddl_temp.DataBind();

            return ddl_temp;
        }


        private TableCell CellWithContent(string CellContent, short CellWidth, short CellHeight, string CellClass)
        {
            // Fill a table cell with specified content
            var tc = new TableCell();
            if (CellWidth != 0)
            {
                tc.Width = CellWidth;
            }
            if (CellHeight != 0)
            {
                tc.Height = CellHeight;
            }
            if (CellClass != "")
            {
                tc.CssClass = CellClass;
            }
            tc.Controls.Add(new LiteralControl(CellContent.Trim()));
            return tc;
        }


        private TableRow TableOpeningRow()
        {
            // Create a standard opening table row
            var TempTR = new TableRow();            
            TempTR.Style["color"] = "#000000";
            return TempTR;
        }


        private TableRow TableClosingRow(short TempColSpan)
        {
            // Create a standard table closing row
            var TempTR = new TableRow();
            var TempTC = new TableCell();
            TempTC.ColumnSpan = TempColSpan;
            TempTC.Controls.Add(
                new LiteralControl(
                    "<img src='/images/blank.gif' width='100%' height='1' style='background-color:white'>"));
            TempTR.Cells.Add(TempTC);
            return TempTR;
        }


        private void PopulateForm()
        {
            // Populate HTML form with student data
            string imgEdit = "/images/record_edit.gif";
            string strSql = String.Empty;
            DataSet TempRs;
            TableRow StdTR = null;

            StudentID.Value = stdid;
            StudentImageHidden.Value = StudentImageFilename;
            isDisabledText.Value = isDisabled;

            LastName_str.Value = LastName;
            FirstName_str.Value = FirstName;
            Nickname_str.Value = Nickname;
            UrgentNote_str.Value = UrgentNote;
            Address_str.Value = Address;
            PhoneNumber_str.Value = PhoneNumber;
            Email_str.Value = Email;
            CountryOfBirth_str.Value = CountryOfBirth;
            Nationality_str.Value = Nationality;
            EmergencyContact_str.Value = EmergencyContact;
            EmergencyAddress_str.Value = EmergencyAddress;
            EmergencyNumber_str.Value = EmergencyNumber;
            EmergencyEmail_str.Value = EmergencyEmail;
            ProgramStartDate_str.Value = ProgramStartDate;
            ProgramEndDate_str.Value = ProgramEndDate;
            TestScoreHistory_str.Value = TestScoreHistory;
            ExitScoreHistory_str.Value = ExitScoreHistory;
            TuitionPaymentDate_str.Value = TuitionPaymentDate;
            AdministrativeNotes_str.Value = AdministrativeNotes;
            TuitionPaymentNotes_str.Value = TuitionPaymentNotes;
            ClassHoursHistory_str.Value = ClassHoursHistory;
            WarningLetterInfo_str.Value = WarningLetterInfo;
            Comments_str.Value = Comments;


            // Update drop-down lists
            StatusDropDownList = DropDownListFilled("SELECT * FROM iic_students_status", "status_id",
                "status_description");
            CurrentLevelDropDownList = DropDownListFilled("SELECT * FROM iic_students_level", "level_id",
                "level_description");


            // Calculate Vacation
            CalculateVacation();

            // Labels
            LabelNotifyPayment.Text = NotifyPayment;
            LabelStudentWeeks.Text = stdweek + " Week(s)";
            LabelEarnedVacation.Text = earnedvac + " Week(s)";
            LabelRemainingVacation.Text = remainvac + " Week(s)";

            // Populate vacation section of form
            strSql = "SELECT * FROM iic_vacation WHERE StudentID=" + stdid + " ORDER BY start_date DESC";
            TempRs = TempRsFilled(strSql);
            string FullBlankImg = "<img src='/images/blank.gif' width='1' height='1'>";
            string LengthyContentStr = String.Empty;

            foreach (DataRow iteration_row_5 in TempRs.Tables[0].Rows)
            {
                StdTR = TableOpeningRow();
                StdTR.Cells.Add(CellWithContent(iteration_row_5["start_date"].ToString(), 100, 0, "textform"));
                StdTR.Cells.Add(CellWithContent(FullBlankImg, 1, 1, ""));
                StdTR.Cells.Add(CellWithContent(iteration_row_5["end_date"].ToString(), 100, 0, "textform"));
                StdTR.Cells.Add(CellWithContent(FullBlankImg, 1, 1, ""));
                StdTR.Cells.Add(CellWithContent(iteration_row_5["weeks"].ToString(), 60, 0, "textform"));
                StdTR.Cells.Add(CellWithContent(FullBlankImg, 1, 1, ""));
                LengthyContentStr = "<img src=" + imgEdit + @" width='16' height='16' border='0' onClick=""editRecord('" +
                                    Session["Auth_Id"] + "', '" + iteration_row_5["id"] + @"'); return false;"" >";
                StdTR.Cells.Add(CellWithContent(LengthyContentStr, 50, 0, "textform"));
                LengthyContentStr = "<img src=" + imgEdit + @" width='16' height='16' border='0' onClick=""delRecord('" +
                                    Session["Auth_Id"] + "', '" + iteration_row_5["id"] + @"'); return false;"" >";
                StdTR.Cells.Add(CellWithContent(FullBlankImg, 1, 1, ""));
                StdTable1.Rows.Add(StdTR);

                StdTR = TableClosingRow(9);
                StdTable1.Rows.Add(StdTR);
            }

            // Populate medical leave section of form
            strSql = "SELECT * FROM iic_medical_leave WHERE StudentID=" + stdid + " ORDER BY start_date DESC";
            TempRs = TempRsFilled(strSql);

            foreach (DataRow iteration_row_6 in TempRs.Tables[0].Rows)
            {
                StdTR = TableOpeningRow();
                StdTR.Cells.Add(CellWithContent(iteration_row_6["start_date"].ToString(), 100, 0, "textform"));
                StdTR.Cells.Add(CellWithContent(FullBlankImg, 1, 1, ""));
                StdTR.Cells.Add(CellWithContent(iteration_row_6["end_date"].ToString(), 100, 0, "textform"));
                StdTR.Cells.Add(CellWithContent(FullBlankImg, 1, 1, ""));
                StdTR.Cells.Add(CellWithContent(iteration_row_6["weeks"].ToString(), 60, 0, "textform"));
                StdTable2.Rows.Add(StdTR);

                StdTR = TableClosingRow(9);
                StdTable2.Rows.Add(StdTR);
            }

            // Populate student progress section of form
            strSql = "SELECT * FROM iic_progress_table WHERE StudentID=" + stdid + " ORDER BY ProgressDate DESC";
            TempRs = TempRsFilled(strSql);

            foreach (DataRow iteration_row_7 in TempRs.Tables[0].Rows)
            {
                StdTR = TableOpeningRow();
                StdTR.Cells.Add(CellWithContent(iteration_row_7["ProgressDate"].ToString(), 100, 0, "textform"));
                StdTR.Cells.Add(CellWithContent(FullBlankImg, 1, 1, ""));
                StdTR.Cells.Add(CellWithContent(iteration_row_7["ProgressLevel"].ToString(), 100, 0, "textform"));
                StdTR.Cells.Add(CellWithContent(FullBlankImg, 1, 1, ""));
                StdTable3.Rows.Add(StdTR);

                StdTR = TableClosingRow(9);
                StdTable3.Rows.Add(StdTR);
            }
        }


        private void Page_Load(object sender, EventArgs e)
        {
            // On page load, do the following...
            string Auth_Id = String.Empty;

            ConnectToDB();

            Auth_Id = String.Format("{0}", Session["Auth_Id"]);

            if (Auth_Id == "" || Auth_Id == DBNull.Value.ToString())
            {
                closeWindow();
            }

            if (Auth_Id != "1")
            {
                isDisabled = "disabled";
            }                           
          
            if (String.Format("{0}", Request.ServerVariables["REQUEST_METHOD"]) != "POST")
            {
                stdid = String.Format("{0}", Request.QueryString["stdid"]).Trim();
                queryRecord();
            }

            PopulateForm();
        }
    }
}
